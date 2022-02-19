using System.Threading.Tasks;
using Xunit;

namespace FantasyManager.Core.Data.Tests
{
    public class FootballContextFixture : IAsyncLifetime
    {
        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        public async Task InitializeAsync()
        {
            await CleanDatabase();
        }

        static async Task CleanDatabase()
        {
            using var context = TestFootballContextFactory.CreateTestFootballContext();
            
            context.Users.RemoveRange(context.Users);
            context.UserTeams.RemoveRange(context.UserTeams);
            context.UserTeamSquads.RemoveRange(context.UserTeamSquads);
            context.Seasons.RemoveRange(context.Seasons);
            context.Leagues.RemoveRange(context.Leagues);
            context.Venues.RemoveRange(context.Venues);
            context.Teams.RemoveRange(context.Teams);
            context.Players.RemoveRange(context.Players);

            await context.SaveChangesAsync();
            
        }
    }
}
