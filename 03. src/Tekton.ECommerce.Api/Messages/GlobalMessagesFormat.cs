namespace Tekton.ECommerce.Api.Messages
{
    public partial class GlobalMessages
    {
        public partial class Format
        {

            public partial class Core
            {
                public partial class CoreFormat
                {
                    public const string CoreId = "El [coreId] debe ser mayor a cero.";
                    public const string Code = "El [code] debe tener entre 3 y 5 caracteres entre letra y/o dígito.";
                    public const string Ordering = "El [ordering] debe tener entre 1 y 10 dígitos.";
                    public const string CoreName = "El [coreName] tiene caracteres inválidos.";
                    public const string Color = "El [color] tiene caracteres inválidos.";
                    public const string Icon = "El [icon] tiene caracteres inválidos.";
                    public const string Data1 = "El [data1] tiene caracteres inválidos.";
                    public const string Data2 = "El [data2] tiene caracteres inválidos.";
                    public const string Additional = "El [additional] tiene caracteres inválidos.";
                    public const string Observation = "El [observation] tiene caracteres inválidos.";
                    public const string ParentId = "El [parentId] del padre debe ser igual o mayor a cero.";
                }

                public partial class CategoryFormat
                {
                    public const string CategoryId = "El [categoryId] debe ser mayor a cero.";
                    public const string Code = "El [code] debe tener entre 3 y 5 caracteres entre letra y/o dígito.";
                    public const string Ordering = "El [ordering] debe tener entre 1 y 10 dígitos.";
                    public const string CategoryName = "El [categoryName] tiene caracteres inválidos.";
                    public const string Color = "El [color] tiene caracteres inválidos.";
                    public const string Icon = "El [icon] tiene caracteres inválidos.";
                    public const string Data1 = "El [data1] tiene caracteres inválidos.";
                    public const string Data2 = "El [data2] tiene caracteres inválidos.";
                    public const string Additional = "El [additional] tiene caracteres inválidos.";
                    public const string Observation = "El [observation] tiene caracteres inválidos.";
                    public const string ParentId = "El [parentId] del padre debe ser igual o mayor a cero.";
                }

                public partial class ProductFormat
                {
                    public const string ProductId = "El [coreId] debe ser mayor a cero.";
                    public const string Code = "El [code] debe tener entre 3 y 10 caracteres entre letra y/o dígito.";
                    public const string ExternalCode = "El [externalCode] debe tener entre 1 y 50 caracteres entre letra y/o dígito.";
                    public const string ProductName = "El [productName] tiene caracteres inválidos.";
                    public const string ProductDescription = "El [productDescription] tiene caracteres inválidos.";

                    public const string Ordering = "El [ordering] debe tener entre 1 y 10 dígitos.";

                    public const string Barcode = "El [barcode] debe tener entre 1 y 50 caracteres entre letra y/o dígito.";

                    public const string BrandId = "El [brandId] debe ser igual o mayor a cero.";
                    public const string CategoryId = "El [categoryId] debe ser igual o mayor a cero.";
                    public const string SubcategoryId = "El [subCategoryId] debe ser igual o mayor a cero.";

                    public const string Stock = "El [stock] debe ser igual o mayor a cero.";
                    public const string Price = "El [price] debe ser igual o mayor a cero.";

                    public const string Color = "El [color] tiene caracteres inválidos.";
                    public const string Icon = "El [icon] tiene caracteres inválidos.";
                    public const string Data1 = "El [data1] tiene caracteres inválidos.";
                    public const string Data2 = "El [data2] tiene caracteres inválidos.";
                    public const string Additional = "El [additional] tiene caracteres inválidos.";
                    public const string Observation = "El [observation] tiene caracteres inválidos.";
                    public const string Status = "El [status] debe tener 1 dígito, comprendido entre 0 y 1.";
                }

                public partial class ProductDiscountFormat
                {
                    public const string ProductId = "El [coreId] debe ser mayor a cero.";                    
                }

            }

            public partial class Auth
            {
                public partial class Login
                {
                    public const string OwnerId = "El [ownerId] debe ser mayor a cero.";
                    public const string Username = "El [username] debe tener entre 3 y 20 caracteres entre letra y/o dígito.";
                    public const string Password = "El [password] debe tener entre 1 y 10 caracteres entre letra y/o dígito.";
                }
            }

        }
    }
}