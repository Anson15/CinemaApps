using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApps.SystemConsole.Model
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public DateTime ReleaseDate { get; set; }
        public status Status { get; set; }

        public enum status
        {
            ComingSoon,NowShowing
        }
    }
}
