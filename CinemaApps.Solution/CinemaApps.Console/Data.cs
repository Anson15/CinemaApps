using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApps.SystemConsole
{
    public class Data
    {
        public List<Model.User> GetUser()
        {
            List<Model.User> Users = new List<Model.User>()
            {
                new Model.User(){Username="John",Password="123",Email="John@gmail.com" },
                new Model.User(){Username="Mike",Password="321",Email="Mike@gmail.com"}
            };
            return Users;
        }
        public List<Model.Movie> GetMovie()
        {
            List<Model.Movie> Movies = new List<Model.Movie>()
            {
                new Model.Movie(){MovieTitle="The Avengers",ReleaseDate=new DateTime(2020, 4, 12),Status="Coming Soon"},
                new Model.Movie(){MovieTitle="The Justice",ReleaseDate=new DateTime(2020,4,12),Status="Coming Soon"},
                new Model.Movie(){MovieTitle="The Matrix",ReleaseDate=new DateTime(2020,3,05),Status="Now Showing"},
                new Model.Movie(){MovieTitle="Lord Of The Rings",ReleaseDate=new DateTime(2020,3,09),Status="Now Showing"}
            };
            return Movies;
        }
    }
}

