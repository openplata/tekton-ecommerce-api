using AutoMapper;
using Tekton.ECommerce.Domain.Entity.Core.Core;
using Tekton.ECommerce.Dto.Core.Core;

namespace Tekton.ECommerce.Map.Core
{
    public class CoreMap : Profile
    {
        public CoreMap()
        {
            CreateMap<PostCoreRequestDto, USP_CORE_INS_Request>()
                .ForMember(dest => dest.CODE, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.ORDERING, opt => opt.MapFrom(src => src.Ordering))
                .ForMember(dest => dest.CORE_NAME, opt => opt.MapFrom(src => src.CoreName))
                .ForMember(dest => dest.COLOR, opt => opt.MapFrom(src => src.Color))
                .ForMember(dest => dest.ICON, opt => opt.MapFrom(src => src.Icon))
                .ForMember(dest => dest.DATA1, opt => opt.MapFrom(src => src.Data1))
                .ForMember(dest => dest.DATA2, opt => opt.MapFrom(src => src.Data2))
                .ForMember(dest => dest.ADDITIONAL, opt => opt.MapFrom(src => src.Additional))
                .ForMember(dest => dest.OBSERVATION, opt => opt.MapFrom(src => src.Observation))
                .ForMember(dest => dest.PARENT_ID, opt => opt.MapFrom(src => src.ParentId));

            CreateMap<USP_CORE_INS_Result, PostCoreResponseDto>()
                .ForMember(des => des.Status, opt => opt.MapFrom(src => src.STATUS))
                .ForMember(des => des.Message, opt => opt.MapFrom(src => src.MESSAGE))
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.ID));

            CreateMap<PutCoreRequestDto, USP_CORE_UPD_Request>()
                .ForMember(dest => dest.CORE_ID, opt => opt.MapFrom(src => src.CoreId))
                .ForMember(dest => dest.CODE, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.ORDERING, opt => opt.MapFrom(src => src.Ordering))
                .ForMember(dest => dest.CORE_NAME, opt => opt.MapFrom(src => src.CoreName))
                .ForMember(dest => dest.COLOR, opt => opt.MapFrom(src => src.Color))
                .ForMember(dest => dest.ICON, opt => opt.MapFrom(src => src.Icon))
                .ForMember(dest => dest.DATA1, opt => opt.MapFrom(src => src.Data1))
                .ForMember(dest => dest.DATA2, opt => opt.MapFrom(src => src.Data2))
                .ForMember(dest => dest.ADDITIONAL, opt => opt.MapFrom(src => src.Additional))
                .ForMember(dest => dest.OBSERVATION, opt => opt.MapFrom(src => src.Observation))
                .ForMember(dest => dest.PARENT_ID, opt => opt.MapFrom(src => src.ParentId))
                .ForMember(dest => dest.IS_ACTIVE, opt => opt.MapFrom(src => src.IsActive))
                ;

            CreateMap<USP_CORE_UPD_Result, PutCoreResponseDto>()
                .ForMember(des => des.Status, opt => opt.MapFrom(src => src.STATUS))
                .ForMember(des => des.Message, opt => opt.MapFrom(src => src.MESSAGE))
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.ID));

            CreateMap<GetCoreByIdRequestDto, USP_CORE_SEL_BY_ID_Request>()
                .ForMember(des => des.CORE_ID, opt => opt.MapFrom(src => src.CoreId));

            CreateMap<USP_CORE_SEL_BY_ID_Result, GetCoreByIdResponseDto>()
                .ForMember(dest => dest.CoreId, opt => opt.MapFrom(src => src.CORE_ID))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.CODE))
                .ForMember(dest => dest.Ordering, opt => opt.MapFrom(src => src.ORDERING))
                .ForMember(dest => dest.CoreName, opt => opt.MapFrom(src => src.CORE_NAME))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.COLOR))
                .ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.ICON))
                .ForMember(dest => dest.Data1, opt => opt.MapFrom(src => src.DATA1))
                .ForMember(dest => dest.Data2, opt => opt.MapFrom(src => src.DATA2))
                .ForMember(dest => dest.Additional, opt => opt.MapFrom(src => src.ADDITIONAL))
                .ForMember(dest => dest.Observation, opt => opt.MapFrom(src => src.OBSERVATION))
                .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.PARENT_ID))                

                .ForMember(des => des.IsActive, opt => opt.MapFrom(src => src.IS_ACTIVE))
                .ForMember(des => des.CreationDate, opt => opt.MapFrom(src => src.CREATION_DATE))
                .ForMember(des => des.CreationUserId, opt => opt.MapFrom(src => src.CREATION_USER_ID))
                .ForMember(des => des.UpdateDate, opt => opt.MapFrom(src => src.UPDATE_DATE))
                .ForMember(des => des.UpdateUserId, opt => opt.MapFrom(src => src.UPDATE_USER_ID));

            CreateMap<GetCoreAllByParentIdRequestDto, USP_CORE_SEL_ALL_BY_PARENT_ID_Request>()
                .ForMember(des => des.PARENT_ID, opt => opt.MapFrom(src => src.ParentId));

            CreateMap<USP_CORE_SEL_ALL_BY_PARENT_ID_Result, GetCoreAllByParentIdResponseDto>()
                .ForMember(dest => dest.CoreId, opt => opt.MapFrom(src => src.CORE_ID))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.CODE))
                .ForMember(dest => dest.Ordering, opt => opt.MapFrom(src => src.ORDERING))
                .ForMember(dest => dest.CoreName, opt => opt.MapFrom(src => src.CORE_NAME))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.COLOR))
                .ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.ICON))
                .ForMember(dest => dest.Data1, opt => opt.MapFrom(src => src.DATA1))
                .ForMember(dest => dest.Data2, opt => opt.MapFrom(src => src.DATA2))
                .ForMember(dest => dest.Additional, opt => opt.MapFrom(src => src.ADDITIONAL))
                .ForMember(dest => dest.Observation, opt => opt.MapFrom(src => src.OBSERVATION))
                .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.PARENT_ID))

                .ForMember(des => des.IsActive, opt => opt.MapFrom(src => src.IS_ACTIVE))
                .ForMember(des => des.CreationDate, opt => opt.MapFrom(src => src.CREATION_DATE))
                .ForMember(des => des.CreationUserId, opt => opt.MapFrom(src => src.CREATION_USER_ID))
                .ForMember(des => des.UpdateDate, opt => opt.MapFrom(src => src.UPDATE_DATE))
                .ForMember(des => des.UpdateUserId, opt => opt.MapFrom(src => src.UPDATE_USER_ID));

            CreateMap<USP_CORE_SEL_ALL_Result, GetCoreAllResponseDto>()
                .ForMember(dest => dest.CoreId, opt => opt.MapFrom(src => src.CORE_ID))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.CODE))
                .ForMember(dest => dest.Ordering, opt => opt.MapFrom(src => src.ORDERING))
                .ForMember(dest => dest.CoreName, opt => opt.MapFrom(src => src.CORE_NAME))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.COLOR))
                .ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.ICON))
                .ForMember(dest => dest.Data1, opt => opt.MapFrom(src => src.DATA1))
                .ForMember(dest => dest.Data2, opt => opt.MapFrom(src => src.DATA2))
                .ForMember(dest => dest.Additional, opt => opt.MapFrom(src => src.ADDITIONAL))
                .ForMember(dest => dest.Observation, opt => opt.MapFrom(src => src.OBSERVATION))
                .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.PARENT_ID))

                .ForMember(des => des.IsActive, opt => opt.MapFrom(src => src.IS_ACTIVE))
                .ForMember(des => des.CreationDate, opt => opt.MapFrom(src => src.CREATION_DATE))
                .ForMember(des => des.CreationUserId, opt => opt.MapFrom(src => src.CREATION_USER_ID))
                .ForMember(des => des.UpdateDate, opt => opt.MapFrom(src => src.UPDATE_DATE))
                .ForMember(des => des.UpdateUserId, opt => opt.MapFrom(src => src.UPDATE_USER_ID));

        }
    }
}