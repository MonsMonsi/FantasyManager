using FantasyManager.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Text.Json;

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
