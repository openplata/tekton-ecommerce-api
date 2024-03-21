using AutoMapper;
using Tekton.ECommerce.Domain.Entity.Core.Product;
using Tekton.ECommerce.Dto.Core.Product;

namespace Tekton.ECommerce.Map.Core
{
    public class ProductMap : Profile
    {
        public ProductMap()
        {
            CreateMap<PostProductRequestDto, USP_PRODUCT_INS_Request>()
                .ForMember(dest => dest.CODE, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.EXTERNAL_CODE, opt => opt.MapFrom(src => src.ExternalCode))
                .ForMember(dest => dest.PRODUCT_NAME, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.PRODUCT_DESCRIPTION, opt => opt.MapFrom(src => src.ProductDescription))

                .ForMember(dest => dest.ORDERING, opt => opt.MapFrom(src => src.Ordering))

                .ForMember(dest => dest.BARCODE, opt => opt.MapFrom(src => src.Barcode))
                .ForMember(dest => dest.BRAND_ID, opt => opt.MapFrom(src => src.BrandId))
                .ForMember(dest => dest.CATEGORY_ID, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.SUBCATEGORY_ID, opt => opt.MapFrom(src => src.SubcategoryId))

                .ForMember(dest => dest.COLOR, opt => opt.MapFrom(src => src.Color))
                .ForMember(dest => dest.ICON, opt => opt.MapFrom(src => src.Icon))
                .ForMember(dest => dest.DATA1, opt => opt.MapFrom(src => src.Data1))
                .ForMember(dest => dest.DATA2, opt => opt.MapFrom(src => src.Data2))
                .ForMember(dest => dest.ADDITIONAL, opt => opt.MapFrom(src => src.Additional))
                .ForMember(dest => dest.OBSERVATION, opt => opt.MapFrom(src => src.Observation))
                .ForMember(dest => dest.STATUS, opt => opt.MapFrom(src => src.Status))
                ;

            CreateMap<USP_PRODUCT_INS_Result, PostProductResponseDto>()
                .ForMember(des => des.Status, opt => opt.MapFrom(src => src.STATUS))
                .ForMember(des => des.Message, opt => opt.MapFrom(src => src.MESSAGE))
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.ID));

            CreateMap<PutProductRequestDto, USP_PRODUCT_UPD_Request>()
                .ForMember(dest => dest.PRODUCT_ID, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.CODE, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.EXTERNAL_CODE, opt => opt.MapFrom(src => src.ExternalCode))
                .ForMember(dest => dest.PRODUCT_NAME, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.PRODUCT_DESCRIPTION, opt => opt.MapFrom(src => src.ProductDescription))

                .ForMember(dest => dest.ORDERING, opt => opt.MapFrom(src => src.Ordering))

                .ForMember(dest => dest.BARCODE, opt => opt.MapFrom(src => src.Barcode))
                .ForMember(dest => dest.BRAND_ID, opt => opt.MapFrom(src => src.BrandId))
                .ForMember(dest => dest.CATEGORY_ID, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.SUBCATEGORY_ID, opt => opt.MapFrom(src => src.SubcategoryId))

                .ForMember(dest => dest.COLOR, opt => opt.MapFrom(src => src.Color))
                .ForMember(dest => dest.ICON, opt => opt.MapFrom(src => src.Icon))
                .ForMember(dest => dest.DATA1, opt => opt.MapFrom(src => src.Data1))
                .ForMember(dest => dest.DATA2, opt => opt.MapFrom(src => src.Data2))
                .ForMember(dest => dest.ADDITIONAL, opt => opt.MapFrom(src => src.Additional))
                .ForMember(dest => dest.OBSERVATION, opt => opt.MapFrom(src => src.Observation))

                .ForMember(dest => dest.STATUS, opt => opt.MapFrom(src => src.Status))

                .ForMember(dest => dest.IS_ACTIVE, opt => opt.MapFrom(src => src.IsActive))
                ;

            CreateMap<USP_PRODUCT_UPD_Result, PutProductResponseDto>()
                .ForMember(des => des.Status, opt => opt.MapFrom(src => src.STATUS))
                .ForMember(des => des.Message, opt => opt.MapFrom(src => src.MESSAGE))
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.ID));

            CreateMap<GetProductByIdRequestDto, USP_PRODUCT_SEL_BY_ID_Request>()
                .ForMember(des => des.PRODUCT_ID, opt => opt.MapFrom(src => src.ProductId));

            CreateMap<USP_PRODUCT_SEL_BY_ID_Result, GetProductByIdResponseDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.PRODUCT_ID))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.CODE))
                .ForMember(dest => dest.ExternalCode, opt => opt.MapFrom(src => src.EXTERNAL_CODE))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.PRODUCT_NAME))
                .ForMember(dest => dest.ProductDescription, opt => opt.MapFrom(src => src.PRODUCT_DESCRIPTION))

                .ForMember(dest => dest.Ordering, opt => opt.MapFrom(src => src.ORDERING))

                .ForMember(dest => dest.Barcode, opt => opt.MapFrom(src => src.BARCODE))
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.BRAND_ID))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CATEGORY_ID))
                .ForMember(dest => dest.SubcategoryId, opt => opt.MapFrom(src => src.SUBCATEGORY_ID))

                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.COLOR))
                .ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.ICON))
                .ForMember(dest => dest.Data1, opt => opt.MapFrom(src => src.DATA1))
                .ForMember(dest => dest.Data2, opt => opt.MapFrom(src => src.DATA2))
                .ForMember(dest => dest.Additional, opt => opt.MapFrom(src => src.ADDITIONAL))
                .ForMember(dest => dest.Observation, opt => opt.MapFrom(src => src.OBSERVATION))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.STATUS))

                .ForMember(des => des.IsActive, opt => opt.MapFrom(src => src.IS_ACTIVE))
                .ForMember(des => des.CreationDate, opt => opt.MapFrom(src => src.CREATION_DATE))
                .ForMember(des => des.CreationUserId, opt => opt.MapFrom(src => src.CREATION_USER_ID))
                .ForMember(des => des.UpdateDate, opt => opt.MapFrom(src => src.UPDATE_DATE))
                .ForMember(des => des.UpdateUserId, opt => opt.MapFrom(src => src.UPDATE_USER_ID));

            CreateMap<GetProductAllByBrandIdRequestDto, USP_PRODUCT_SEL_ALL_BY_BRAND_ID_Request>()
                .ForMember(des => des.BRAND_ID, opt => opt.MapFrom(src => src.BrandId));

            CreateMap<USP_PRODUCT_SEL_ALL_BY_BRAND_ID_Result, GetProductAllByBrandIdResponseDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.PRODUCT_ID))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.CODE))
                .ForMember(dest => dest.ExternalCode, opt => opt.MapFrom(src => src.EXTERNAL_CODE))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.PRODUCT_NAME))
                .ForMember(dest => dest.ProductDescription, opt => opt.MapFrom(src => src.PRODUCT_DESCRIPTION))

                .ForMember(dest => dest.Ordering, opt => opt.MapFrom(src => src.ORDERING))

                .ForMember(dest => dest.Barcode, opt => opt.MapFrom(src => src.BARCODE))
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.BRAND_ID))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CATEGORY_ID))
                .ForMember(dest => dest.SubcategoryId, opt => opt.MapFrom(src => src.SUBCATEGORY_ID))

                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.COLOR))
                .ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.ICON))
                .ForMember(dest => dest.Data1, opt => opt.MapFrom(src => src.DATA1))
                .ForMember(dest => dest.Data2, opt => opt.MapFrom(src => src.DATA2))
                .ForMember(dest => dest.Additional, opt => opt.MapFrom(src => src.ADDITIONAL))
                .ForMember(dest => dest.Observation, opt => opt.MapFrom(src => src.OBSERVATION))

                .ForMember(des => des.IsActive, opt => opt.MapFrom(src => src.IS_ACTIVE))
                .ForMember(des => des.CreationDate, opt => opt.MapFrom(src => src.CREATION_DATE))
                .ForMember(des => des.CreationUserId, opt => opt.MapFrom(src => src.CREATION_USER_ID))
                .ForMember(des => des.UpdateDate, opt => opt.MapFrom(src => src.UPDATE_DATE))
                .ForMember(des => des.UpdateUserId, opt => opt.MapFrom(src => src.UPDATE_USER_ID));

            CreateMap<USP_PRODUCT_SEL_ALL_Result, GetProductAllResponseDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.PRODUCT_ID))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.CODE))
                .ForMember(dest => dest.ExternalCode, opt => opt.MapFrom(src => src.EXTERNAL_CODE))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.PRODUCT_NAME))
                .ForMember(dest => dest.ProductDescription, opt => opt.MapFrom(src => src.PRODUCT_DESCRIPTION))

                .ForMember(dest => dest.Ordering, opt => opt.MapFrom(src => src.ORDERING))

                .ForMember(dest => dest.Barcode, opt => opt.MapFrom(src => src.BARCODE))
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.BRAND_ID))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CATEGORY_ID))
                .ForMember(dest => dest.SubcategoryId, opt => opt.MapFrom(src => src.SUBCATEGORY_ID))

                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.COLOR))
                .ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.ICON))
                .ForMember(dest => dest.Data1, opt => opt.MapFrom(src => src.DATA1))
                .ForMember(dest => dest.Data2, opt => opt.MapFrom(src => src.DATA2))
                .ForMember(dest => dest.Additional, opt => opt.MapFrom(src => src.ADDITIONAL))
                .ForMember(dest => dest.Observation, opt => opt.MapFrom(src => src.OBSERVATION))

                .ForMember(des => des.IsActive, opt => opt.MapFrom(src => src.IS_ACTIVE))
                .ForMember(des => des.CreationDate, opt => opt.MapFrom(src => src.CREATION_DATE))
                .ForMember(des => des.CreationUserId, opt => opt.MapFrom(src => src.CREATION_USER_ID))
                .ForMember(des => des.UpdateDate, opt => opt.MapFrom(src => src.UPDATE_DATE))
                .ForMember(des => des.UpdateUserId, opt => opt.MapFrom(src => src.UPDATE_USER_ID));

        }
    }
}