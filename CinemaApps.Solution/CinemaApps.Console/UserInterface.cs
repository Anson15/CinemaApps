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
        public static void Execute(List<Model.User> users, List<Model.Movie> movies)
        {
            Model.User user = null;
            Model.Movie movie = new Model.Movie();
            bool isTrue = true;


            System.Console.WriteLine("Welcome To Anson Cinema Ticket App.");
            System.Console.WriteLine("\n \t 1.View all movies");
            System.Console.WriteLine("\t 2.Login");
            System.Console.WriteLine("\t 3.Exit app");



            while (isTrue == true)
            {
                string opt = System.Console.ReadLine();

                switch (opt)
                {
                    case "1":


                        var table = new ConsoleTable("ID", "Movie Title", "Release Date", "Status");

                        foreach (var item in movies)
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
                        foreach (var User in users)
                        {
                            if (User.Username == username && User.Password == password)
                            {
                                user = User;
                                isTrue = false;
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

                                        foreach (var item in movies)
                                        {
                                            if (item.Status == "Now Showing")
                                            {
                                                Showingmovie.AddRow(item.MovieId, item.MovieTitle, item.ReleaseDate);
                                            }
                                        }

                                        Showingmovie.Write();

                                        System.Console.Write("Enter the selected movie ID : ");
                                        int Id = Convert.ToInt32(System.Console.ReadLine());

                                        while (Id != movie.MovieId)
                                        {
                                            System.Console.WriteLine("Movie Id Not Found please try again");
                                            Id = Convert.ToInt32(System.Console.ReadLine());
                                        }

                                        while (movie.Status != "Now Showing" && Id == movie.MovieId)
                                        {
                                            System.Console.WriteLine("Please enter a valid ID ");
                                            Id = Convert.ToInt32(System.Console.ReadLine());
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

