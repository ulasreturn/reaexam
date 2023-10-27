using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data.Postgres.EntityFramework;

public class PostgresContext : DbContext
{
    private readonly IConfiguration _configuration;


    public PostgresContext(DbContextOptions<PostgresContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
        

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserTokenConfiguration());
        //modelBuilder.ApplyConfiguration(new HastaConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
    modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
    modelBuilder.ApplyConfiguration(new BankAccountConfiguration());
    //modelBuilder.ApplyConfiguration(new TedaviConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionsConfiguration());




    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (_configuration["EnvironmentAlias"] == "DEV")
        {
            optionsBuilder.LogTo(Console.Write);
        }
    }
    public DbSet<Transactions> Transactions => Set<Transactions>();
    public DbSet<Comment> Comment => Set<Comment>();
    //public DbSet<Tedavi> Tedaviler => Set<Tedavi>();
  public DbSet<BankAccount> BankAccount => Set<BankAccount>();
  //public DbSet<Hasta> Hastalar => Set<Hasta>();
   public DbSet<Employee> Employee => Set<Employee>();
  public DbSet<User> User => Set<User>();
    public DbSet<UserToken> UserTokens => Set<UserToken>();

}

