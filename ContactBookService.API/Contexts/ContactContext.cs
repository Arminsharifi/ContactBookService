using ContactBookService.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactBookService.API.Contexts
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public ContactContext(DbContextOptions options) : base(options)
        {
        }
    }
}