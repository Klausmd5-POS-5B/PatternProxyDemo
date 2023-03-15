namespace PersonDbLib;
public class PersonContext : DbContext
{
  public PersonContext() { }
  public PersonContext(DbContextOptions<PersonContext> options) : base(options) { }

  public DbSet<Person> Persons { get; set; } = null!;
  public DbSet<Company> Companies { get; set; } = null!;

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseSqlServer(@"Server=(LocalDB)\mssqllocaldb;attachdbfilename=C:\temp\ProxyDemoPersons.mdf;Database=ProxyDemoPersons;integrated security=True;MultipleActiveResultSets=True");
    }
  }
}
