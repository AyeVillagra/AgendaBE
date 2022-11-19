using apidemo.DTOs;
using apidemo.Entities;

namespace apidemo.Data.Repository
{
    public class UserRepository
    {
        public static List<User> FakeUsers = new List<User>()
        {
            new User()
            {
                Email = "asasju@hsyso.com",
                Name = "Pablo",
                Password = "passwordsegura",
                Id = 1
            },
            new User()
            {
                Email = "juytgsju@hsyso.com",
                Name = "Aye",
                Password = "passwordinsegura",
                Id=2
            }

        };

        public List<User> GetAllUsers()
        {
            return FakeUsers;
        }

        public User? GetOne(int ID)
        {
            return FakeUsers.SingleOrDefault(x => x.Id == ID);
        }
        public bool CreateUser(UserForCreationDTO userDTO)
        {
            User user = new User()
            {
                Name = userDTO.Name,
                Password = userDTO.Password,
                Id = userDTO.Id,
                Email = userDTO.Email,
            };
            FakeUsers.Add(user);
            return true;
        }

        public User ValidarUsuario(string userName, string password) {
            var userActual = FakeUsers.Single(u => u.UserName == userName);
            if (userActual.Password == password)
            {
                return userActual;
            }
            return userActual;
        }
    }
}
