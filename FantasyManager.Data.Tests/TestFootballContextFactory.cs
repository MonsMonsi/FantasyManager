using FantasyManager.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FantasyManager.Core.Data.Tests
{
    public static class TestFootballContextFactory
    {
        public static FootballContext CreateTestFootballContext(string[] args = null)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "TestConfig.json");
            var connectionString = JsonSerializer.Deserialize<TestConfig>(File.ReadAllText(path)).TestConnectionString;

            var options = new DbContextOptionsBuilder<FootballContext>();
            options.UseSqlServer(connectionString);

            return new FootballContext(options.Options);
        }
    }
}
