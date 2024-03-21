using AutoMapper;

namespace Tekton.ECommerce.Application
{
    public abstract class GenericApplication
    {
        protected readonly IMapper mapper;

        public GenericApplication(IMapper _mapper)
        {
            mapper = _mapper;
        }
    }
}