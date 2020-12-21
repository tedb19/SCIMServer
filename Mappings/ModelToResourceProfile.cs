using AutoMapper;
using SCIMServer.Domain.Models;
using SCIMServer.Extensions;
using SCIMServer.Resources;

namespace SCIMServer.Mappings
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Group, GroupResource>();
            CreateMap<User, UserResource>()
                .ForMember(src => src.Status,
                            opt => opt.MapFrom(src => src.Status.ToDescriptionString()));
        }
    }
}
