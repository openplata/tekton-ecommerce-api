using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using OP.FK_Framework.Dto.Response;
using Tekton.ECommerce.Api.Extensions;
using Tekton.ECommerce.Api.Core.Infraestructure;
using Tekton.ECommerce.Api.Core.Infrastructura.AutofacModules;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using OP.FK_Framework.Dto.JWTToken;
using Tekton.ECommerce.Api.Configurations;
using Tekton.ECommerce.Dto.DistributedCache;
using Tekton.ECommerce.Dto.ExternalApi;

namespace Tekton.ECommerce.Api
{
    public class Startup
    {
        public IConfiguration configuration { get; }
        public TokenConfigurationsDto tokenConfigurations { get; }

        private readonly string swaggerBasePath = "docs/specification";
        private readonly IWebHostEnvironment _env;
        public FluentValidationConfig FluentValidationConfig { get; }

        public Startup(IConfiguration _configuration, IWebHostEnvironment env)
        {
            configuration = _configuration;

            _env = env;
            tokenConfigurations = configuration.GetSection("TokenConfigurations").Get<TokenConfigurationsDto>();
            FluentValidationConfig = configuration.GetSection(nameof(FluentValidationConfig)).Get<FluentValidationConfig>();
            
        }

        public IServiceProvider ConfigureServices(IServiceCollection Services)
        {
            Services.Configure<TokenConfigurationsDto>(configuration.GetSection("TokenConfigurations"));
            Services.Configure<DistributedCacheConfiguration>(configuration.GetSection("DistributedCache"));

            #region Versionamiento Api

            Services.AddApiVersioning(setup =>
            {
                setup.DefaultApiVersion = new ApiVersion(1, 0);
                setup.AssumeDefaultVersionWhenUnspecified = true;
                setup.ReportApiVersions = true;
                
            });
            Services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });
            #endregion Versionamiento Api


            var valuesSection = configuration
                    .GetSection("Cors:AllowSpecificOrigins")
                    .GetChildren()
                    .ToList()
                    .Select(x => x.GetValue<string>("origin")).ToList();

            Services.AddCors(options =>
            {
                options.AddPolicy("_AllowSpecificOrigins",
                    builder => builder.WithOrigins(valuesSection.ToArray())
                                        .AllowAnyHeader()
                                        .AllowAnyMethod()
                                        );
                options.AddPolicy("_AllowAllOrigins",
                    builder => builder.AllowAnyOrigin()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod());
            });

            Services.AddCustomMvc();
            Services.AddCustomSwagger();
            Services.AddCustomApiController();
            Services.AddFluent();
            Services.AddCustomSecuritySwagger();
            Services.AddCustomIntegrations();            
            Services.AddOptions();

            Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  var secretkey = Encoding.UTF8.GetBytes(tokenConfigurations.SecretKey);
                  var encryptionkey = Encoding.UTF8.GetBytes(tokenConfigurations.Encryptkey);

                  var validationParameters = new TokenValidationParameters
                  {
                      ClockSkew = TimeSpan.Zero, // default: 5 min
                      RequireSignedTokens = true,

                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new SymmetricSecurityKey(secretkey),

                      RequireExpirationTime = true,
                      ValidateLifetime = true,

                      ValidateAudience = true, //default : false
                      ValidAudience = tokenConfigurations.Audience,

                      ValidateIssuer = true, // default : false,
                      ValidIssuer = tokenConfigurations.Issuer,

                      //   TokenDecryptionKey = new SymmetricSecurityKey(encryptionkey)
                  };

                  options.RequireHttpsMetadata = false;
                  options.SaveToken = true;
                  options.TokenValidationParameters = validationParameters;

                  options.Events = new JwtBearerEvents
                  {
                      OnChallenge = async context =>
                      {

                          context.HandleResponse();
                          context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                          context.Response.ContentType = "application/json";
                          context.Response.Headers.Append("WWW-Authenticate", "Bearer error=\"invalid_token\"");


                          var authorizationHeader = context.Request.Headers["authorization"];

                          string respuesta = "Usted no está autorizado (token inválido).";


                          string token = authorizationHeader == StringValues.Empty ? string.Empty : authorizationHeader.Single().Split(" ").Last();

                          if (token.Equals(""))
                          {
                              respuesta = "Usted no está autorizado (no se envió el token o token vacío).";
                          }
                          else
                          {
                              if (token.Length > 2000)
                              {
                                  respuesta = "Usted no está autorizado (el token debe tener como máximo 2000 caracteres).";
                              }
                          }


                          var response = new BaseResponse<string>();
                          response.Success = false;
                          response.Validations = new List<MessageResponse>();

                          response.Validations.Add(new MessageResponse(respuesta, "00"));
                          JObject jObject = new JObject();
                          //jObject["_param"] = HttpMethodEncryptationSecurity.TryEncrypt(JsonConvert.SerializeObject(response), false);
                          jObject["_param"] = JsonConvert.SerializeObject(response);
                          respuesta = jObject.ToString();

                          await context.Response.WriteAsync(respuesta, Encoding.UTF8);
                      }
                  };
              });

            var mappingConfig = MapperConfigurationCfg.Load();
            IMapper mapper = mappingConfig.CreateMapper();

            Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            Services.AddSingleton(mapper);

            ServicesAddScoped.Load(Services);

            #region Redis
            Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["DistributedCache:ConnectionString"];
                options.InstanceName = configuration["DistributedCache:Instance"];
            });
            #endregion

            var container = new ContainerBuilder();
            container.Populate(Services);
            container.RegisterModule(new MediatorModule(configuration));

            return new AutofacServiceProvider(container.Build());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IApiVersionDescriptionProvider provider)
        {
            var pathBase = configuration["PATH_BASE"];
            if (!string.IsNullOrEmpty(pathBase))
            {
                app.UsePathBase(pathBase);
            }

            /*
            if (env.IsProduction())
            {
                app.UseMiddleware<HttpMethodSecurityMiddleware>();
            }
            */
            app.UseSwagger(c =>
            {
                c.RouteTemplate = swaggerBasePath + "/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(
                options =>
                {
                    // build a swagger endpoint for each discovered API version
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/{swaggerBasePath}/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                        options.RoutePrefix = $"{swaggerBasePath}";
                        options.InjectStylesheet($"/swagger-ui/custom.css");
                        options.InjectJavascript($"/swagger-ui/custom.js", "text/javascript");
                        options.DocumentTitle = "Tekto API ::Juan Casiano::";
                    }
                });

            app.UseRouting();
            app.UseCors("CorsPolicy");
            ConfigureAuth(app);

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });
        }

        protected virtual void ConfigureAuth(IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }

    }
}