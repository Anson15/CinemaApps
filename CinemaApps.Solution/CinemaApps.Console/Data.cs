using CinemaApps.SystemConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApps.SystemConsole
{
    public class Data
    {
        public ICollection<User> Users { get; set; }
        public ICollection<Movie> Movies { get; set; }
        public ICollection<Mo>

        public Data()
        {
            Users = new List<User>();
            Movies = new List<Movie>();
        }

        public void GetUser()
        {
            Users.Add(new User() { UserId = Guid.NewGuid(), Username = "John", Password = "123" });
            Users.Add(new User() { UserId = Guid.NewGuid(), Username = "Cena", Password = "321" });
        }

        public void GetMovie()
        {
            Movies.Add(new Movie() { MovieTitle = "The Justice League", ReleaseDate = new DateTime(), Status = Movie.status.ComingSoon });
            Movies.Add(new Movie() { MovieTitle = "The Avenger", ReleaseDate = new DateTime(), Status = Movie.status.ComingSoon });
            Movies.Add(new Movie() { MovieTitle = "The Matrix", ReleaseDate = new DateTime(), Status = Movie.status.NowShowing });
            Movies.Add(new Movie() { MovieTitle = "Lord Of The Rings", ReleaseDate = new DateTime(), Status = Movie.status.NowShowing });
        }

        public  void GetHall()
        {
            
        }
    }
}

