using FantasyManager.Data;
using FantasyManager.Data.Writer;
using FantasyManager.Data.Writer.ResponseModels;
using FantasyManager.Domain.Entities;
using System.Text.Json;

namespace FantasyManager.Core.Data.Writer
{
    public class FromFilesToDatabase
    {
        private readonly FootballContextFactory _contextFactory;
        private readonly WriterConfig _config;

        public FromFilesToDatabase(FootballContextFactory contextFactory, WriterConfig config)
        {
            _config = config;
            _contextFactory = contextFactory;
            Write();
        }

        private void Write()
        {
            Leagues();
            Venues_Teams();
            Players();
        }

        private void Leagues()
        {
            var dirPath = Path.Combine(_config.FilePath, "Players");

            var dirInfo = new DirectoryInfo(dirPath);

            var fileInfo = dirInfo.GetFiles($"*{_config.CurrentSeason}*");

            foreach (var info in fileInfo)
            {
                var json = JsonSerializer.Deserialize<JsonPlayers.Root>(File.ReadAllText(info.ToString()),
                                                                            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                using (var context = _contextFactory.CreateDbContext())
                {
                    for (var i = 0; i < json.Response.Length; i++)
                    {
                        var league = json.Response[i].Statistics[0].League;

                        var leagueFromDb = context.Leagues.Find(league.Id);

                        if (leagueFromDb == null)
                        {
                            League leagueToDb = new()
                            {
                               Id = league.Id ?? 99009900,
                               Name = league.Name,
                               Country = league.Country,
                               Logo = league.Logo,
                               Flag = league.Flag, 
                            };

                            context.Leagues.Add(leagueToDb);
                            context.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("League found");
                        }
                    }
                }
            }
        }

        private void Venues_Teams()
        {
            var dirPath = Path.Combine(_config.FilePath, "TeamsVenues");

            var dirInfo = new DirectoryInfo(dirPath);

            var fileInfo = dirInfo.GetFiles($"*{_config.CurrentSeason}*");

            foreach (var info in fileInfo)
            {
                var json = JsonSerializer.Deserialize<JsonTeamsVenues.Root>(File.ReadAllText(info.ToString()),
                                                                            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                using (var context = _contextFactory.CreateDbContext())
                {
                    for (var i = 0; i < json.Response.Length; i++)
                    {
                        var venue = json.Response[i].Venue;

                        var venueFromDb = context.Venues.Find(venue.Id);

                        if (venueFromDb == null)
                        {
                            Venue venueToDb = new()
                            {
                                Id = venue.Id,
                                Name = venue.Name,
                                Address = venue.Address,
                                City = venue.City,
                                Capacity = venue.Capacity.ToString(),
                                Image = venue.Image,
                            };

                            context.Venues.Add(venueToDb);
                            context.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("Venue found");
                        }

                        var team = json.Response[i].Team;

                        var teamFromDb = context.Teams.Find(team.Id);

                        var leagueId = int.Parse(info.Name.Split('_')[1]);

                        if (teamFromDb == null)
                        {
                            Team teamToDb = new()
                            {
                               Id = team.Id,
                               Name = team.Name,
                               Logo = team.Logo,
                               LeagueId = leagueId,
                               VenueId = venue.Id,
                            };

                            context.Teams.Add(teamToDb);
                            context.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("Team found");
                        }
                    }
                }
            }
        }

        private void Players()
        {
            var dirPath = Path.Combine(_config.FilePath, "Players");

            var dirInfo = new DirectoryInfo(dirPath);

            var fileInfo = dirInfo.GetFiles($"*{_config.CurrentSeason}*");

            foreach (var info in fileInfo)
            {
                var json = JsonSerializer.Deserialize<JsonPlayers.Root>(File.ReadAllText(info.ToString()),
                                                                            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                using (var context = _contextFactory.CreateDbContext())
                {
                    for (var i = 0; i < json.Response.Length; i++)
                    {
                        var player = json.Response[i].Player;

                        var stats = json.Response[i].Statistics[0];

                        var playerFromDb = context.Players.Find(player.Id);

                        if (playerFromDb == null)
                        {
                            Player playerToDb = new()
                            {
                                Id = player.Id,
                                FirstName = player.Firstname,
                                LastName = player.Lastname,
                                Birth = new()
                                {
                                    Date = player.Birth.Date ?? "---",
                                    Country = player.Birth.Country,
                                    Place = player.Birth.Place ?? "---"
                                },
                                Nationality = player.Nationality,
                                Height = player.Height ?? "---",
                                Weight = player.Weight ?? "---",
                                Position = stats.Games.Position,
                                Photo = player.Photo,
                                Active = true,
                                TeamId = stats.Team.Id
                            };

                            context.Players.Add(playerToDb);
                            context.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("Player found");
                        }
                    }
                }
            };
        }
    }
}
