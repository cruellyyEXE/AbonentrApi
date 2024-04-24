using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Context;

public class AbonentrContext : DbContext
{
    private static readonly IConfiguration Configuration = null!;

    public required DbSet<Core.Model.Abonent> Abonents { get; set; }
    public required DbSet<Core.Model.PhoneNumber> PhoneNumbers { get; set; }
    public required DbSet<Core.Model.PhoneNumberType> PhoneNumberTypes { get; set; }
    public required DbSet<Core.Model.Streets> Streets { get; set; }
    public required DbSet<Core.Model.Address> Addresses { get; set; }

    public static SqliteConnection Connection { get; } =
        new SqliteConnection(Configuration.GetConnectionString("sqlite"));

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(Configuration.GetConnectionString("sqlite")!);
    }
}