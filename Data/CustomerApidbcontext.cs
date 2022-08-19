using Microsoft.EntityFrameworkCore;
using webApi.Models;

namespace webApi.Data
{
    public class CustomerApidbcontext : DbContext
    {
        public CustomerApidbcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> customer { get; set; }
    }
}
