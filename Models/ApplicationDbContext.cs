using Microsoft.EntityFrameworkCore;
using Expense_Tracker.Models;

namespace Expense_Tracker.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options) { 
        

        }
       

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Transaction> Categories { get; set; }
        public DbSet<Expense_Tracker.Models.Category>? Category { get; set; }


    }

       
}
