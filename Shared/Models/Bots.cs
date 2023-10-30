using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiBotIO.Shared.Models
{
    public class Bots
    {
        public int BotId { get; set; }
        public double SuspectRate { get; set; }
        public string BotName { get; set; }
        public string BotComment { get; set; }
        public string BotBio { get; set; }
    }
}
