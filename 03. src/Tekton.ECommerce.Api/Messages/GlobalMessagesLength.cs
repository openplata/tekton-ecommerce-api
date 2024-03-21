namespace Tekton.ECommerce.Api.Messages
{
    public partial class GlobalMessages
    {
        public partial class Length
        {
            public partial class Core
            {
                public partial class CoreLength
                {
                    public const string CoreId = "Debe ingresar el [coreId].";
                    public const string Code = "El [code] debe tener máximo de 5 caracteres entre letra y/o dígito.";
                    public const string Ordering = "El [ordering] debe tener un máximo de 10 dígitos.";
                    public const string CoreName = "El [coreName] debe tener un mínimo de 3 caracteres y máximo 100 caracteres.";
                    public const string Color = "El [color] debe tener un máximo 50 caracteres.";
                    public const string Icon = "El [icon] debe tener un máximo 100 caracteres.";
                    public const string Data1 = "El [data1] debe tener un máximo 100 caracteres.";
                    public const string Data2 = "El [data2] debe tener un máximo 100 caracteres.";
                    public const string Additional = "El [additional] debe tener un máximo 100 caracteres.";
                    public const string Observation = "El [observation] debe tener un máximo 100 caracteres.";
                    public const string ParentId = "Debe ingresar el [parentId]";
                }

                public partial class CategoryLength
                {
                    public const string CategoryId = "Debe ingresar el [categoryId].";
                    public const string Code = "El [code] debe tener un máximo de 5 caracteres.";
                    public const string Ordering = "El [ordering] debe tener un máximo de 10 dígitos.";
                    public const string CategoryName = "El [categoryName] debe tener un mínimo de 3 caracteres y máximo 100 caracteres.";
                    public const string Color = "El [color] debe tener un máximo 50 caracteres.";
                    public const string Icon = "El [icon] debe tener un máximo 100 caracteres.";
                    public const string Data1 = "El [data1] debe tener un máximo 100 caracteres.";
                    public const string Data2 = "El [data2] debe tener un máximo 100 caracteres.";
                    public const string Additional = "El [additional] debe tener un máximo 100 caracteres.";
                    public const string Observation = "El [observation] debe tener un máximo 100 caracteres.";
                    public const string ParentId = "Debe ingresar el [parentId]";
                }

                public partial class ProductLength
                {
                    public const string ProductId = "Debe ingresar el [productId].";
                    public const string Code = "El [code] debe tener un máximo de 10 caracteres.";
                    public const string ExternalCode = "El [externalCode] debe tener un máximo de 50 caracteres.";
                    public const string ProductName = "El [productName] debe tener un mínimo de 3 caracteres y máximo 100 caracteres.";
                    public const string ProductDescription = "El [productDescripcion] debe tener un mínimo de 3 caracteres y máximo 500 caracteres.";

                    public const string Ordering = "El [ordering] debe tener un máximo de 10 dígitos.";

                    public const string Barcode = "El [barcode] debe tener un máximo de 50 caracteres.";

                    public const string BrandId = "Debe ingresar el [brandId]";
                    public const string CategoryId  = "Debe ingresar el [categoryId]";
                    public const string SubcategoryId = "Debe ingresar el [subcategoryId]";

                    public const string Color = "El [color] debe tener un máximo 50 caracteres.";
                    public const string Icon = "El [icon] debe tener un máximo 100 caracteres.";
                    public const string Data1 = "El [data1] debe tener un máximo 100 caracteres.";
                    public const string Data2 = "El [data2] debe tener un máximo 100 caracteres.";
                    public const string Additional = "El [additional] debe tener un máximo 100 caracteres.";
                    public const string Observation = "El [observation] debe tener un máximo 100 caracteres.";
                    
                }
            }

            public partial class Auth
            {
                public partial class Login
                {
                    public const string OwnerId = "Debe ingresar el [OwnerId].";
                    public const string Username = "El [Username] debe tener un mínimo de 3 caracteres y un máximo de 20 caracteres.";
                    public const string Password = "El [Password] debe tener un mínimo de 1 dígito y un máximo de 10 dígitos.";                    
                }
            }

        }
    }
}
