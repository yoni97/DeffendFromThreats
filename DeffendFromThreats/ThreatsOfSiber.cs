using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeffendFromThreats
{
    public class ThreatsOfSiber
    {
        public int Volume { get; set; }
        public int Sophistication { get; set; }

        public string ThreatType { get; set; }

        public string Target { get; set; }

        public ThreatsOfSiber(int volume, int sophistication, string threatType, string target)
        {
            Volume = volume;
            Sophistication = sophistication;
            ThreatType = threatType;
            Target = target;
        }
    }
    
}
