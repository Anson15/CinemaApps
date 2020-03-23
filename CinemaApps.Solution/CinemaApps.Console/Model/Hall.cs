using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApps.SystemConsole.Model
{
    public class Hall
    {
        public int Id { get; set; }
        public string HallNo { get; set; }
        public int TotalRows { get; set; }
        public int TotalColumns { get; set; }
        public int TotalSeat => TotalRows * TotalColumns;

    }
}
