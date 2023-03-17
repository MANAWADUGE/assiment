using CRUD_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_API.Data
{
    public class ContactApiDbContext : DbContext
    {
        public ContactApiDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ContactsModel> Contacts { get; set; }
    }
}
