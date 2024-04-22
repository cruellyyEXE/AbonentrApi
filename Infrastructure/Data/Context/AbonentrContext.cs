using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class AbonentrContext : DbContext
{
    public DbSet<Core.Model.Abonent> Abonents { get; set; }
    public DbSet<Core.Model.PhoneNumber> PhoneNumbers { get; set; }
    public DbSet<Core.Model.PhoneNumberType> PhoneNumberTypes { get; set; }
    public DbSet<Core.Model.Streets> Streets { get; set; }
    public DbSet<Core.Model.Address> Addresses { get; set; }

    protected override async void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=sample;Mode=Memory;Cache=Shared");
    }
}