using CinemaApps.Console.Model;
using CinemaApps.SystemConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static CinemaApps.Console.Model.HallSeat;

namespace CinemaApps.SystemConsole
{
    public class Data
    {
        public ICollection<User> Users { get; set; }
        public ICollection<Movie> Movies { get; set; }
        public ICollection<Hall> Halls { get; set; }
        public ICollection<MovieHall> MovieHalls { get; set; }
        public ICollection<HallSeat> HallSeats { get; set; }

        public Data()
        {
            Users = new List<User>();
            Movies = new List<Movie>();
            Halls = new List<Hall>();
            MovieHalls = new List<MovieHall>();
            HallSeats = new List<HallSeat>();
        }

        public void GetUser()
        {
            Users.Add(new User() { UserId = Guid.NewGuid(), Username = "John", Password = "123" });
            Users.Add(new User() { UserId = Guid.NewGuid(), Username = "Cena", Password = "321" });
        }

        public void GetMovie()
        {
            Movies.Add(new Movie() { MovieId = 101, MovieTitle = "The Justice League", ReleaseDate = new DateTime(2020,4,5), Status = Movie.status.ComingSoon });
            Movies.Add(new Movie() { MovieId = 102, MovieTitle = "The Avenger", ReleaseDate = new DateTime(2020,4,1), Status = Movie.status.ComingSoon });
            Movies.Add(new Movie() { MovieId = 103, MovieTitle = "The Matrix", ReleaseDate = new DateTime(2020,3,10), Status = Movie.status.NowShowing });
            Movies.Add(new Movie() { MovieId = 104, MovieTitle = "Lord Of The Rings", ReleaseDate = new DateTime(2020,3,7), Status = Movie.status.NowShowing });
        }

        public void GetHall()
        {
            Halls.Add(new Hall() { Id = 3, HallNo = "1", TotalRows = 5, TotalColumns = 10 });
            Halls.Add(new Hall() { Id = 4, HallNo = "2", TotalRows = 4, TotalColumns = 10 });
        }

        public void GetMovieHall()
        {
            MovieHalls.Add(new MovieHall() { HallId = 3, MovieId = 103, MovieDateTime = new DateTime(2020, 3, 18, 13, 30, 0), Id = 301 });
            MovieHalls.Add(new MovieHall() { HallId = 3, MovieId = 103, MovieDateTime = new DateTime(2020, 3, 18, 16, 30, 0), Id = 302 });
            MovieHalls.Add(new MovieHall() { HallId = 3, MovieId = 103, MovieDateTime = new DateTime(2020, 3, 18, 19, 30, 0), Id = 303 });
            MovieHalls.Add(new MovieHall() { HallId = 4, MovieId = 104, MovieDateTime = new DateTime(2020, 3, 18, 11, 30, 0), Id = 304 });
            MovieHalls.Add(new MovieHall() { HallId = 4, MovieId = 104, MovieDateTime = new DateTime(2020, 3, 18, 17, 30, 0), Id = 305 });
            MovieHalls.Add(new MovieHall() { HallId = 4, MovieId = 104, MovieDateTime = new DateTime(2020, 3, 18, 20, 30, 0), Id = 306 });
        }

        public void GetMovieHallDetails()
        {
            SeatsDetail seats;
            Random rdm = new Random();
            
            foreach (var item in MovieHalls)
            {
                int Totalrow = 0;
                int totalCol = 0;

                if (item.HallId == 3)
                {
                    totalCol = 10;
                    Totalrow = 5;
                }
                else
                {
                    totalCol = 10;
                    Totalrow = 4;
                }

                //randomly set the seat status
                for (int i = 1; i <= Totalrow; i++)
                {
                    for (int j = 1; j <= totalCol; j++)
                    {
                        
                        Thread.Sleep(1);
                        int s = rdm.Next(0, 2);

                        if (s == 0)
                        {
                            seats = SeatsDetail.Empty;
                        }
                        else
                        {
                            seats = SeatsDetail.Taken;
                        }
                        HallSeats.Add(new HallSeat() {Id=1,TimeStartId=item.Id, HallId = item.HallId, Rows = i, Columns = j, Seat = i.ToString() + "," + j.ToString(), SeatStatus = seats });
                    }
                }
            }
        }
    }
}

