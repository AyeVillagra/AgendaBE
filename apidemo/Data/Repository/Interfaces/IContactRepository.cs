using apidemo.DTOs;
using apidemo.Entities;

namespace apidemo.Data.Repository.Interfaces
{
    public interface IContactRepository
        {
            public List<Contact> GetAll();
            public void Create(CreateAndUpdateContact dto);
            public void Update(CreateAndUpdateContact dto);
            public void Delete(int id);
        }
    }
}
