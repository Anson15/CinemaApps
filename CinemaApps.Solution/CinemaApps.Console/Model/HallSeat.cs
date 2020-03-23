using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApps.Console.Model
{
    public class HallSeat
    {
        public int Id { get; set; }
        public int HallId { get; set; }

        public int TimeStartId { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public string Seat { get; set; }

        public SeatsDetail SeatStatus { get; set; }

        public enum SeatsDetail
        {
            Taken,Empty
        }
    }
}
