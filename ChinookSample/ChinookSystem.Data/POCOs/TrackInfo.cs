using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.Data.POCOs
{
    public class TrackInfo
    {
        public string Title { get; set; }
        public int NumberOfTracks { get; set; }
        public decimal TotalTrackPrice { get; set; }
        public double AveragetrackLengthInSeconds { get; set; }
    }
}
