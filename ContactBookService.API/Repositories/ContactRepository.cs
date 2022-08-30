using ContactBookService.API.Contexts;
using ContactBookService.API.Models;

namespace ContactBookService.API.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactContext _context;

        public ContactRepository(ContactContext _context)
        {
            this._context = _context;
        }

        public bool Add(Contact contact)
        {
            try
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Contact contact = Get(id);
                if (contact != null)
                {
                    contact.Delete();
                    _context.Update(contact);
                    _context.SaveChanges();
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public Contact Get(int id)
        {
            return _context.Contacts.Where(x => x.isDeleted == false).FirstOrDefault(x => x.Id == id);
        }

        public List<Contact> GetAll()
        {
            return _context.Contacts.Where(x => x.isDeleted == false).ToList();
        }

        public bool Update(Contact contact)
        {
            try
            {
                Contact FetchedContact = Get(contact.Id);
                if (contact != null)
                {
                    FetchedContact.Update(contact.FullName, contact.PhoneNumber);
                    _context.Update(FetchedContact);
                    _context.SaveChanges();
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }
    }
}