using Microsoft.EntityFrameworkCore;
using SubscriptionAPITest.Models;

namespace SubscriptionAPITest.DbContexts;

public class SubscriptionsDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("Server=viaduct.proxy.rlwy.net;Database=railway;Port=27533;Uid=root;Pwd=JOSCWEXpLmWUXcyDFgTVtYlPmhZcsMzj;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasMany(p => p.Subscriptions)
            .WithOne(s => s.Person)
            .HasForeignKey(s => s.PersonId)
            .IsRequired();

        modelBuilder.Entity<Subscription>()
            .HasOne(s => s.Person)
            .WithMany(p => p.Subscriptions)
            .HasForeignKey(s => s.PersonId)
            .IsRequired();

        modelBuilder.Entity<Person>().Navigation(p => p.Subscriptions).AutoInclude();
    }
}