using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleManager.Infraestructure.DbContexts
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            HasKey(modelBuilder);
            HasRelationships(modelBuilder);

            modelBuilder.Entity<Battle>()
                .Property(e => e.Date)
                .HasConversion(e => e.ToUniversalTime(), e => DateTime.SpecifyKind(e, DateTimeKind.Utc));
            
            modelBuilder.Entity<Battle>()
                .Property(e => e.Duration)
                .HasConversion(e => e.ToUniversalTime(), e => DateTime.SpecifyKind(e, DateTimeKind.Utc));
        }

        private void HasKey(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Battle>().HasKey(b => new { b.Player1Id, b.Date} );
            modelBuilder.Entity<Card>().HasKey(c => c.Id);
            modelBuilder.Entity<Cargo>().HasKey(c => c.Id);
            modelBuilder.Entity<Challenge>().HasKey(c => c.Id);
            modelBuilder.Entity<Clan>().HasKey(c=> c.Id);
            modelBuilder.Entity<ClanWar>().HasKey(c => new { c.IdClan, c.IdWar });
            modelBuilder.Entity<Player>().HasKey(p => p.Id);
            modelBuilder.Entity<PlayerCard>().HasKey(pc => new {pc.IdPlayer, pc.IdCard});
            modelBuilder.Entity<PlayerChallenge>().HasKey(pc => new {pc.IdPlayer, pc.IdChallenge});
            modelBuilder.Entity<PlayerClan>().HasKey(pc => new {pc.IdPlayer, pc.IdClan});
            modelBuilder.Entity<SpellCard>().HasKey(s => s.CardId);
            modelBuilder.Entity<StructureCard>().HasKey(s => s.CardId);
            modelBuilder.Entity<TroopCard>().HasKey(t => t.CardId);
            modelBuilder.Entity<TypeClan>().HasKey(tc => tc.Id);
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<War>().HasKey(w => w.Id);
        }

        private void HasRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Battle>()
                .HasOne(b => b.Player1)
                .WithMany(p => p.Battles1)
                .HasForeignKey(b => b.Player1Id);

            modelBuilder.Entity<Battle>()
                .HasOne(b => b.Player2)
                .WithMany(p => p.Battles2)
                .HasForeignKey(b => b.Player2Id);
            
            modelBuilder.Entity<PlayerCard>()
                .HasOne(pc => pc.Player)
                .WithMany(p => p.PlayerCards)
                .HasForeignKey(pc => pc.IdPlayer);

            modelBuilder.Entity<PlayerCard>()
                .HasOne(pc => pc.Card)
                .WithMany(c => c.PlayerCards)
                .HasForeignKey(pc => pc.IdCard);
            
            modelBuilder.Entity<PlayerCard>()
                .HasOne(pc => pc.Clan)
                .WithMany(c => c.PlayerCards)
                .HasForeignKey(pc => pc.IdClan);
            
            modelBuilder.Entity<PlayerChallenge>()
                .HasOne(pc => pc.Player)
                .WithMany(p => p.PlayerChallenges)
                .HasForeignKey(pc => pc.IdPlayer);
            
            modelBuilder.Entity<PlayerChallenge>()
                .HasOne(pc => pc.Challenge)
                .WithMany(c => c.PlayerChallenges)
                .HasForeignKey(pc => pc.IdChallenge);
            
            modelBuilder.Entity<PlayerClan>()
                .HasOne(pc => pc.Player)
                .WithMany(p => p.PlayerClans)
                .HasForeignKey(pc => pc.IdPlayer);
            
            modelBuilder.Entity<PlayerClan>()
                .HasOne(pc => pc.Clan)
                .WithMany(c => c.PlayerClans)
                .HasForeignKey(pc => pc.IdClan);
            
            modelBuilder.Entity<PlayerClan>()
                .HasOne(pc => pc.Cargo)
                .WithMany(c => c.PlayerClans)
                .HasForeignKey(pc => pc.IdCargo);
            
            modelBuilder.Entity<Card>()
                .HasOne(c => c.SpellCard)
                .WithOne(sc => sc.Card)
                .HasForeignKey<SpellCard>(sc => sc.CardId);
            
            modelBuilder.Entity<Card>()
                .HasOne(c => c.StructureCard)
                .WithOne(sc => sc.Card)
                .HasForeignKey<StructureCard>(sc => sc.CardId);
            
            modelBuilder.Entity<Card>()
                .HasOne(c => c.TroopCard)
                .WithOne(sc => sc.Card)
                .HasForeignKey<TroopCard>(sc => sc.CardId);
            
            modelBuilder.Entity<Clan>()
                .HasOne(c => c.TypeClan)
                .WithMany(t => t.Clans)
                .HasForeignKey(c => c.IdType);
            
            modelBuilder.Entity<ClanWar>()
                .HasOne(cw => cw.Clan)
                .WithMany(c => c.ClanWars)
                .HasForeignKey(cw => cw.IdClan);
            
            modelBuilder.Entity<ClanWar>()
                .HasOne(cw => cw.War)
                .WithMany(w => w.ClanWars)
                .HasForeignKey(cw => cw.IdWar);
        }

        public DbSet<Battle> Battles { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<ClanWar> ClanWars { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerCard> PlayerCards { get; set; }
        public DbSet<PlayerChallenge> PlayerChallenges { get; set; }
        public DbSet<PlayerClan> PlayerClans { get; set; }
        public DbSet<SpellCard> SpellCards { get; set; }
        public DbSet<StructureCard> StructureCards { get; set; }
        public DbSet<TroopCard> TroopCards { get; set; }
        public DbSet<TypeClan> TypeClans { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<War> Wars { get; set; }
    }
}