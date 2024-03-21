using AutoMapper;

using Tekton.ECommerce.Map.Core;

namespace Tekton.ECommerce.Api.Core.Infraestructure
{
    public class MapperConfigurationCfg
    {
        public MapperConfigurationCfg()
        {
            
        }

        public static MapperConfiguration Load()
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CoreMap());
                cfg.AddProfile(new CategoryMap());
                cfg.AddProfile(new ProductMap());

            });
            return mappingConfig;
        }
    }
}