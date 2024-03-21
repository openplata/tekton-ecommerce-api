namespace Tekton.ECommerce.SQLServer.Configuration.Constants
{
    public static class UspNameConstants
    {
        private const string SYSTEM_Schema = "bst_system";
        private const string CORE_Schema = "bst_core";
        
        public static class system
        {
            public static class CHANGELOG
            {
                public const string USP_CHANGELOG_SEL_PAGINATED = SYSTEM_Schema + ".USP_CHANGELOG_SEL_PAGINATED";
            }
        }

        public static class core
        {
            
            public static class CORE
            {
                public const string USP_CORE_INS = CORE_Schema + ".USP_CORE_INS";
                public const string USP_CORE_SEL_BY_ID = CORE_Schema + ".USP_CORE_SEL_BY_ID";
                public const string USP_CORE_UPD = CORE_Schema + ".USP_CORE_UPD";
                public const string USP_CORE_SEL_ALL = CORE_Schema + ".USP_CORE_SEL_ALL";
                public const string USP_CORE_SEL_ALL_BY_PARENT_ID = CORE_Schema + ".USP_CORE_SEL_ALL_BY_PARENT_ID";
            }

            public static class CATEGORY
            {
                public const string USP_CATEGORY_INS = CORE_Schema + ".USP_CATEGORY_INS";
                public const string USP_CATEGORY_SEL_BY_ID = CORE_Schema + ".USP_CATEGORY_SEL_BY_ID";
                public const string USP_CATEGORY_UPD = CORE_Schema + ".USP_CATEGORY_UPD";
                public const string USP_CATEGORY_SEL_ALL = CORE_Schema + ".USP_CATEGORY_SEL_ALL";
                public const string USP_CATEGORY_SEL_ALL_BY_PARENT_ID = CORE_Schema + ".USP_CATEGORY_SEL_ALL_BY_PARENT_ID";
            }

            public static class PRODUCT
            {
                public const string USP_PRODUCT_INS = CORE_Schema + ".USP_PRODUCT_INS";
                public const string USP_PRODUCT_SEL_BY_ID = CORE_Schema + ".USP_PRODUCT_SEL_BY_ID";
                public const string USP_PRODUCT_UPD = CORE_Schema + ".USP_PRODUCT_UPD";
                public const string USP_PRODUCT_SEL_ALL = CORE_Schema + ".USP_PRODUCT_SEL_ALL";
                public const string USP_PRODUCT_SEL_ALL_BY_BRAND_ID = CORE_Schema + ".USP_PRODUCT_SEL_ALL_BY_BRAND_ID";
            }
        }

        
    }
}