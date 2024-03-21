using Microsoft.AspNetCore.Http;

namespace Tekton.ECommerce.Api.Messages
{
    public partial class GlobalMessages
    {
        public partial class Required
        {
            public partial class Core
            {
                public partial class CoreRequired
                {
                    public const string CoreId = "Debe ingresar el [coreId].";
                    public const string Code = "Debe ingresar el [code].";
                    //public const string Ordering { get; set; }
                    public const string CoreName = "Debe ingresar el [coreName].";
                    //public const string Color { get; set; }
                    //public const string Icon { get; set; }
                    //public const string Data1 { get; set; }
                    //public const string Data2 { get; set; }
                    //public const string Additional { get; set; }
                    //public const string Observation { get; set; }
                    public const string ParentId = "Debe ingresar el [parentId]";
                    public const string IsActive = "Debe ingresar el [isActive]";
                }

                public partial class CategoryRequired
                {
                    public const string CategoryId = "Debe ingresar el [categoryId].";
                    public const string Code = "Debe ingresar el [code].";
                    //public const string Ordering { get; set; }
                    public const string CategoryName = "Debe ingresar el [categoryName].";
                    //public const string Color { get; set; }
                    //public const string Icon { get; set; }
                    //public const string Data1 { get; set; }
                    //public const string Data2 { get; set; }
                    //public const string Additional { get; set; }
                    //public const string Observation { get; set; }
                    public const string ParentId = "Debe ingresar el [parentId]";
                    public const string IsActive = "Debe ingresar el [isActive]";
                }

                public partial class ProductRequired
                {
                    public const string ProductId = "Debe ingresar el [productId].";
                    public const string Code = "Debe ingresar el [code].";
                    //public const string Ordering { get; set; }
                    public const string ProductName = "Debe ingresar el [productName].";
                    public const string ProductDescription = "Debe ingresar el [productDescription].";

                    public const string BrandId = "Debe ingresar el [brandId]";
                    public const string CategoryId = "Debe ingresar el [categoryId]";
                    public const string SubcategoryId = "Debe ingresar el [subcategoryId]";

                    public const string Stock = "Debe ingresar el [stock].";
                    public const string Price = "Debe ingresar el [price].";

                    //public const string Color { get; set; }
                    //public const string Icon { get; set; }
                    //public const string Data1 { get; set; }
                    //public const string Data2 { get; set; }
                    //public const string Additional { get; set; }
                    //public const string Observation { get; set; }

                    public const string Status = "Debe ingresar el [status].";
                    public const string IsActive = "Debe ingresar el [isActive]";
                }

                public partial class ProductDiscountRequired
                {
                    public const string ProductId = "Debe ingresar el [productId].";
                }
            }

            public partial class Auth
            {
                public partial class Login
                {
                    public const string OwnerId = "Debe ingresar el [ownerId].";
                    public const string Username = "Debe ingresar el [username].";                    
                    public const string Password = "Debe ingresar el [password].";                    
                }
            }
        }
    }
}