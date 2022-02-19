using FantasyManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace FantasyManager.Core.Data.Tests
{
    public class FootballContextUnitTests : FootballContextFixture
    {
        private readonly User _user;
        private readonly UserTeam _userTeam;
        private readonly UserTeamSquad _userTeamSquad;
        private readonly League _league;
        private readonly Venue _venue;
        private readonly Team _team;
        private readonly Player _player;

        public FootballContextUnitTests()
        {
            _user = TestObjectFactory.CreateUser();
            _userTeam = TestObjectFactory.CreateUserTeam();
            _userTeamSquad = TestObjectFactory.CreateUserTeamSquad();
            _league = TestObjectFactory.CreateLeague();
            _venue = TestObjectFactory.CreateVenue();
            _team = TestObjectFactory.CreateTeam();
            _player = TestObjectFactory.CreatePlayer();
        }

        [Fact]
        public async Task Add_User_ReturnsSameUser()
        {
            await AddUserToDb();

            await using (var context = TestFootballContextFactory.CreateTestFootballContext())
            {
                var fromDb = await context.Users.FirstOrDefaultAsync();

                Assert.Equal(_user.Name, fromDb.Name);
                Assert.Equal(_user.Password, fromDb.Password);
            }
        }

        [Fact]
        public async Task Add_Player_ReturnsSamePlayer()
        {
            await AddLeagueToDb();
            await AddVenueToDb();
            await AddTeamToDb();
            await AddPlayerToDb();

            await using (var context = TestFootballContextFactory.CreateTestFootballContext())
            {
                var fromDb = await context.Players.FirstOrDefaultAsync();

                Assert.Equal(_player.Id, fromDb.Id);
                Assert.Equal(_player.FirstName, fromDb.FirstName);
                Assert.Equal(_player.LastName, fromDb.LastName);
                Assert.Equal(_player.Birth.Date, fromDb.Birth.Date);
                Assert.Equal(_player.Birth.Country, fromDb.Birth.Country);
                Assert.Equal(_player.Birth.Place, fromDb.Birth.Place);
                Assert.Equal(_player.Nationality, fromDb.Nationality);
                Assert.Equal(_player.Height, fromDb.Height);
                Assert.Equal(_player.Weight, fromDb.Weight);
                Assert.Equal(_player.Position, fromDb.Position);
                Assert.Equal(_player.Photo, fromDb.Photo);
                Assert.Equal(_player.Active, fromDb.Active);
                Assert.Equal(_player.TeamId, fromDb.TeamId);
            }
        }

        #region Add Entities to Db
        private async Task AddUserToDb()
        {
            await using (var context = TestFootballContextFactory.CreateTestFootballContext())
            {
                context.Users.Add(_user);
                await context.SaveChangesAsync();
            }
        }

        private async Task AddLeagueToDb()
        {
            await using (var context = TestFootballContextFactory.CreateTestFootballContext())
            {
                context.Leagues.Add(_league);
                await context.SaveChangesAsync();
            }
        }

        private async Task AddVenueToDb()
        {
            await using (var context = TestFootballContextFactory.CreateTestFootballContext())
            {
                context.Venues.Add(_venue);
                await context.SaveChangesAsync();
            }
        }

        private async Task AddTeamToDb()
        {
            await using (var context = TestFootballContextFactory.CreateTestFootballContext())
            {
                context.Teams.Add(_team);
                await context.SaveChangesAsync();
            }
        }

        private async Task AddPlayerToDb()
        {
            await using (var context = TestFootballContextFactory.CreateTestFootballContext())
            {
                context.Players.Add(_player);
                await context.SaveChangesAsync();
            }
        }
        #endregion
    }
}