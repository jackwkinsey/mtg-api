using Microsoft.EntityFrameworkCore;
using mtg_api.Models;

namespace mtg_api.Data
{
  public class CardContext : DbContext
  {
    public CardContext() { }

    public CardContext(DbContextOptions<CardContext> options)
      : base(options) { }
    public DbSet<Card> Cards { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Card>().HasKey(c => new { c.SetCode, c.CollectionNumber });
    }
  }
}