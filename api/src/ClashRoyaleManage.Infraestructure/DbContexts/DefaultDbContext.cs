using ClashRoyaleManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleManager.Infraestructure.DbContexts;

public class DefaultDbContext : DbContext
{
    public DefaultDbContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; }

    public DbSet<Card> Cards { get; set; }
}