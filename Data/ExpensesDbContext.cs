
using Data.Models;
using System.Data.Entity;
namespace Data
{
    public class ExpensesDbContext : DbContext
    {
        public ExpensesDbContext() : base("name=MyContext")
        {
        }
        public DbSet<Expenses> Expenses { get; set; }
    }
}
