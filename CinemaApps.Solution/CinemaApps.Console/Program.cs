﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApps.SystemConsole
{
    class Program
    {
        private static int MovieId;
        public static int GetId()
        {
            return ++MovieId;
        }
        static void Main(string[] args)
        {
            Data users = new Data();

            List<Model.User> Listusers = users.GetUser();
            List<Model.Movie> ListMovie = users.GetMovie();
            UserInterface.Execute(Listusers, ListMovie);

        }
    }
}
