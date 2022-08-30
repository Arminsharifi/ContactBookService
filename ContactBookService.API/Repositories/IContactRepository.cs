using ContactBookService.API.Models;

namespace ContactBookService.API.Repositories
{
    public interface IContactRepository
    {
        List<Contact> GetAll();
        Contact Get(int id);
        bool Add(Contact customer);
        bool Delete(int id);
        bool Update(Contact customer);
    }
}