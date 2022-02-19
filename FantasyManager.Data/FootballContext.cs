using FantasyManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FantasyManager.Data
{
    public class FootballContext : DbContext
    {
        private string _connectionString;

        #region DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<UserTeam> UserTeams { get; set; }
        public DbSet<UserTeamSquad> UserTeamSquads { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        #endregion

        public FootballContext(string connectonString) : base()
        {
            _connectionString = connectonString;
        }

        public FootballContext(DbContextOptions<FootballContext> options) : base(options)
        {

        }

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(p =>
            {
                p.OwnsOne(x => x.Birth, b =>
                {
                    b.Property(b => b.Date).HasColumnName("BirthDate").HasMaxLength(20).IsRequired();
                    b.Property(b => b.Place).HasColumnName("BirthPlace").HasMaxLength(100).IsRequired();
                    b.Property(b => b.Country).HasColumnName("BirthCountry").HasMaxLength(100).IsRequired();
                });
            });
        }
        #endregion
    }
}