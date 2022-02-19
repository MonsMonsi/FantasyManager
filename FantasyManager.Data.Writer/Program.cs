using FantasyManager.Core.Data.Writer;
using FantasyManager.Data;
using FantasyManager.Data.Writer;
using System.Text.Json;

var path = Path.Combine(Environment.CurrentDirectory, "WriterConfig.json");

var config = JsonSerializer.Deserialize<WriterConfig>(File.ReadAllText(path));

var writer = new FromFilesToDatabase(new FootballContextFactory(), config);
