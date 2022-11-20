using apidemo.Data.Repository.Interfaces;
using apidemo.DTOs;
using apidemo.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace apidemo.Data.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly AgendaApiContext _context;
        private readonly IMapper _mapper;

        public ContactRepository(AgendaApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public static List<Contact> Fakecontacts = new List<Contact>()
            {
            new Contact()
            {
                Name = "Juan",
                CelularNumber = 3452692,
                Id = 1
            },
            new Contact()
            {
                Name = "Pedro",
                TelephoneNumber = 24516790,
                Description = "Hermano",
                Id = 2
            }
            };
        public List<Contact> GetAll()
        {
            return _context.Contacts.ToList();
        }
        public void Create(CreateAndUpdateContact dto)
        {
            _context.Contacts.Add(_mapper.Map<Contact>(dto));
        }

        public void Update(CreateAndUpdateContact dto)
        {
            _context.Contacts.Update(_mapper.Map<Contact>(dto));
        }
        public void Delete(int id)
        {
            _context.Contacts.Remove(_context.Contacts.Single(c => c.Id == id));
        }


    }
}
