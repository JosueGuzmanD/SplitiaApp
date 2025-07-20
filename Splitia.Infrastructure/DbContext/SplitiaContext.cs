using Microsoft.EntityFrameworkCore;
using Splitia.Domain;
using Splitia.Infrastructure.Configuration;

namespace Splitia.Infrastructure.DbContext;

public class SplitiaContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Expenditure> Expenditures { get; set; }
    public DbSet<Income> Incomes { get; set; }
    public DbSet<Split> Splits { get; set; }

    public SplitiaContext(DbContextOptions<SplitiaContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ExpenditureConfiguration());
        modelBuilder.ApplyConfiguration(new IncomeConfiguration());
        modelBuilder.ApplyConfiguration(new SplitConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}