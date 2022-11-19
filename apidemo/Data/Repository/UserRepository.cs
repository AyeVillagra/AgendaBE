using apidemo.Data.Repository.Interfaces;
using apidemo.DTOs;
using apidemo.Entities;
using apidemo.Models.Enum;
using AutoMapper;


namespace apidemo.Data.Repository
{
    public class UserRepository : IUserRepository

    {
        private AgendaApiContext _context;
        private readonly IMapper _mapper;

        public UserRepository(AgendaApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public User? GetById(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.Id == userId);
        }

        public User? ValidarUsuario(AuthenticationRequestBody authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.UserName == authRequestBody.UserName && p.Password == authRequestBody.Password);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Create(CreateAndUpdateUserDto dto)
        {
            _context.Users.Add(_mapper.Map<User>(dto));
        }

        public void Update(CreateAndUpdateUserDto dto)
        {
            _context.Users.Update(_mapper.Map<User>(dto));
        }

        public void Delete(int id)
        {
            _context.Users.Remove(_context.Users.Single(u => u.Id == id));
        }

        public void Archive(int id)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.state = State.Archived;
                _context.Update(user);
            }            
        }
       
    }
}