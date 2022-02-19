using FantasyManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.Core.Data.Tests
{
    public static class TestObjectFactory
    {
        public static User CreateUser()
        {
            return new User()
            {
                Name = "Test",
                Password = "Test"
            };
        }

        public static UserTeam CreateUserTeam()
        {
            return new UserTeam()
            {
                Name = "Test"
            };
        }

        public static UserTeamSquad CreateUserTeamSquad()
        {
            return new UserTeamSquad()
            {
                PlayerId = 1
            };
        }

        public static League CreateLeague()
        {
            return new League()
            {
                Id = 1,
                Name = "Test",
                Country = "Test",
                Logo = "Test",
                Flag = "Test"
            };
        }

        public static Venue CreateVenue()
        {
            return new Venue()
            {
                Id = 1,
                Name="Test",
                Address = "Test",
                City = "Test",
                Capacity = "Test",
                Image = "Test"
            };
        }

        public static Team CreateTeam()
        {
            return new Team()
            {
                Id = 1,
                Name = "Test",
                Logo= "Test",
                LeagueId = 1,
                VenueId = 1,
            };
        }

        public static Player CreatePlayer()
        {
            return new Player()
            {
                Id= 1,
                FirstName = "Test",
                LastName = "Test",
                Birth = new Birth()
                {
                    Date = "Test",
                    Country = "Test",
                    Place = "Test"
                },
                Nationality = "Test",
                Height = "Test",
                Weight = "Test",
                Position = "Test",
                Photo = "Test",
                Active = true,
                TeamId = 1
            };
        }
    }
}
