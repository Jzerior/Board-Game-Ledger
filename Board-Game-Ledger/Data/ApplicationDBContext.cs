using Board_Game_Ledger.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Board_Game_Ledger.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        :base(dbContextOptions)
        {
            
        }

        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<GameSession> GameSessions { get; set; }
        public DbSet<GameSessionPlayer> GameSessionPlayers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GameSessionPlayer>(x => x.HasKey(gsp => new { gsp.GameSessionId, gsp.PlayerId }));


            modelBuilder.Entity<GameSessionPlayer>()
                .HasOne(gsp => gsp.GameSession)
                .WithMany(gs => gs.GameSessionPlayers)
                .HasForeignKey(gsp => gsp.GameSessionId)
                .OnDelete(DeleteBehavior.Cascade); // jawnie!

            modelBuilder.Entity<GameSessionPlayer>()
                .HasOne(gsp => gsp.Player)
                .WithMany(p => p.Sessions)
                .HasForeignKey(gsp => gsp.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
