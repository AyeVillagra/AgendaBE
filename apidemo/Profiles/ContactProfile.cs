using apidemo.DTOs;
using apidemo.Entities;
using AutoMapper;

namespace apidemo.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, CreateAndUpdateContact>();
        }
    }
}
