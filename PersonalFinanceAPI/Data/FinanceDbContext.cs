using System.Transactions;
using Microsoft.EntityFrameworkCore;

namespace PersonalFinance.Data;

public class FinanceDbContext : DbContext
{
    public FinanceDbContext(DbContextOptions<FinanceDbContext> options ) : base(options)
    {}
    
    public DbSet<Transaction> Transactions { get; set; }
}


