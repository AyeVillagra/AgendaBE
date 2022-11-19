using apidemo.DTOs;
using apidemo.Entities;


namespace apidemo.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        public User? ValidarUsuario(AuthenticationRequestBody authRequestBody);
        public User? GetById(int userId);
        public List<User> GetAll();
        public void Create(CreateAndUpdateUserDto dto);
        public void Update(CreateAndUpdateUserDto dto);
        public void Delete(int id);
    }
}

