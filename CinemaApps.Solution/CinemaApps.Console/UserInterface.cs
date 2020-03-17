using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApps.SystemConsole
{
    public class UserInterface
    {
        private static Data data = new Data();
        public static void Execute()
        {
            data.GetMovie();
            data.GetUser();
            Model.User user = null;
            System.Console.WriteLine("Welcome To Anson Cinema Ticket App.");
            System.Console.WriteLine("\n \t 1.View all movies");
            System.Console.WriteLine("\t 2.Login");
            System.Console.WriteLine("\t 3.Exit app");


            while (true)
            {
                string opt = System.Console.ReadLine();

                switch (opt)
                {
                    case "1":


                        var table = new ConsoleTable("ID", "Movie Title", "Release Date", "Status");

                        foreach (var item in data.Movies)
                        {
                            table.AddRow(item.MovieId, item.MovieTitle, item.ReleaseDate, item.Status);
                        }

                        table.Write();

                        break;

                    case "2":
                        System.Console.Clear();

                        System.Console.Write("Username : ");
                        string username = System.Console.ReadLine();
                        System.Console.Write(" Password : ");
                        string password = System.Console.ReadLine();
                        foreach (var User in data.Users)
                        {
                            if (User.Username == username && User.Password == password)
                            {
                                user = User;
                            }
                        }

                        if (user == null)
                        {
                            System.Console.WriteLine("User not found");
                        }

                        else
                        {
                            while (true)
                            {
                                System.Console.WriteLine("Login successfully.");
                                System.Console.WriteLine("1.Select Movie");
                                System.Console.WriteLine("2.Logout");

                                string option = System.Console.ReadLine();

                                switch (option)
                                {
                                    case "1":
                                        var Showingmovie = new ConsoleTable("ID", "Movie Title", "Release Date");

                                        foreach (var movies in data.Movies)
                                        {
                                            if (movies.Status == Model.Movie.status.NowShowing)
                                            {
                                                Showingmovie.AddRow(movies.MovieId, movies.MovieTitle, movies.ReleaseDate);

                                            }
                                        }

                                        Showingmovie.Write();

                                        System.Console.Write("Enter the selected movie ID : ");
                                        int Id = Convert.ToInt32(System.Console.ReadLine());

                                        var checkMovie = data.Movies.Where(m => m.MovieId == Id && m.Status == Model.Movie.status.NowShowing).SingleOrDefault();
                                        if (checkMovie == null)
                                        {
                                            System.Console.WriteLine("no such movie");
                                        }
                                        else
                                        {
                                            System.Console.WriteLine($"You select {checkMovie.MovieTitle}");

                                        }

                                        break;
                                    case "2":

                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

