using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.Data.Writer
{
    public class WriterConfig
    {
        public string FilePath { get; set; }
        public string CurrentSeason { get; set; }
        public string Leagues { get; set; }
        public string APIKeyHeader { get; set; }
        public string APIKey { get; set; }
    }
}
