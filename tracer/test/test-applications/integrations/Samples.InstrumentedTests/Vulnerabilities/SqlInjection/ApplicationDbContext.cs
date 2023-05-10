#if !NETCOREAPP2_1
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.SQLite;
using System.Data.SQLite.EF6;

namespace Samples.InstrumentedTests.Iast.Vulnerabilities;
public class ApplicationDbSqlLiteContext : DbContext
{
    public class SQLiteConfiguration : DbConfiguration
    {
        public SQLiteConfiguration()
        {
            SetProviderFactory("System.Data.SQLite", SQLiteFactory.Instance);
            SetProviderFactory("System.Data.SQLite.EF6", SQLiteProviderFactory.Instance);
            SetProviderServices("System.Data.SQLite", (DbProviderServices)SQLiteProviderFactory.Instance.GetService(typeof(DbProviderServices)));
        }
    }

public ApplicationDbSqlLiteContext(string conn) :
            base(new SQLiteConnection()
            {
                ConnectionString = new SQLiteConnectionStringBuilder(conn) { ForeignKeys = true }.ConnectionString
            }, true)
    {
        DbConfiguration.SetConfiguration(new SQLiteConfiguration());
    }

    public ApplicationDbSqlLiteContext(SQLiteConnection conn) :
    base(conn, true)
    {
        DbConfiguration.SetConfiguration(new SQLiteConfiguration());
    }

    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Book>().ToTable("Books");
    }
}

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(string conn) : base(conn)//, throwIfV1Schema: false)
    {

    }

    public System.Data.Entity.DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Book>().ToTable("Books", "dbo");
    }
}
#endif
