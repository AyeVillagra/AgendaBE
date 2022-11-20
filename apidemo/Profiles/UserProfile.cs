using apidemo.DTOs;
using apidemo.Entities;
using AutoMapper; //mapea DTOs a entidades

namespace apidemo.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() // acá le digo qué mappers voy a usar
        {
            CreateMap<User, CreateAndUpdateUserDto>(); //defino la clase origen y la clase destino
        }
    }
}
