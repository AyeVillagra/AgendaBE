using apidemo.DTOs;
using apidemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace apidemo.Data.Repository
{
    public class ContactRepository
    {

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
        public List<Contact> GetAllContacts()
        {
            return Fakecontacts;
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
