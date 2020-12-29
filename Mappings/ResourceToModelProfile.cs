using AutoMapper;
using SCIMServer.Domain.Models;
using SCIMServer.Resources;

namespace SCIMServer.Mappings
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveGroupResource, Group>();
            CreateMap<SaveUserResource, User>();
            CreateMap<NameResource, Name>();
            CreateMap<AddressResource, Address>();
            CreateMap<SaveMetaResource, Meta>();
            CreateMap<EmailResource, Email>();
        }
    }

}
