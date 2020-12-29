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
            CreateMap<User, UserResource>();
            CreateMap<Meta, MetaResource>()
                .ForMember(src => src.ResourceType,
                            opt => opt.MapFrom(src => src.ResourceType.ToDescriptionString()));
            CreateMap<Address, AddressResource>();
            CreateMap<Name, NameResource>();
            CreateMap<Email, EmailResource>()
                .ForMember(src => src.Type,
                            opt => opt.MapFrom(src => src.Type.ToDescriptionString()));
        }
    }
}
