using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Text.Json;

namespace FantasyManager.Data
{
    public class FootballContextFactory : IDesignTimeDbContextFactory<FootballContext>
    {
        public FootballContext CreateDbContext(string[] args = null)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Config.json");
            var connectionString = JsonSerializer.Deserialize<Config>(File.ReadAllText(path)).ConnectionString;

            var options = new DbContextOptionsBuilder<FootballContext>();
            options.UseSqlServer(connectionString);

            return new FootballContext(options.Options);
        }
    }
}
