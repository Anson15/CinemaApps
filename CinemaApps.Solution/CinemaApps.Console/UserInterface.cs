using CinemaApps.Console.Model;
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
            data.GetHall();
            data.GetMovieHall();
            data.GetMovieHallDetails();

            var check = true;
            while (check)
            {

                System.Console.WriteLine("Welcome To Anson Cinema Ticket App.");
                System.Console.WriteLine("\n \t 1.View all movies");
                System.Console.WriteLine("\t 2.Login");
                System.Console.WriteLine("\t 3.Exit app");
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

                        var check2 = true;

                        while (check2)
                        {
                            System.Console.Write("Username : ");
                            string username = System.Console.ReadLine();

                            System.Console.Write("Password : ");
                            string password = System.Console.ReadLine();

                            var checkUser = data.Users.Where(c => c.Username == username && c.Password == password).SingleOrDefault();

                            if (checkUser == null)
                            {
                                System.Console.WriteLine("User not found");

                            }
                            else
                            {
                                check2 = false;
                            }

                        };

                        var check3 = true;
                        while (check3)
                        {
                            System.Console.Clear();
                            System.Console.WriteLine("Login successfully.");
                            System.Console.WriteLine("1.Select Movie");
                            System.Console.WriteLine("2.Logout");

                            string option = System.Console.ReadLine();

                            switch (option)
                            {
                                case "1":
                                    System.Console.Clear();
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
                                        System.Console.Clear();
                                        System.Console.WriteLine($"You select {checkMovie.MovieTitle}");

                                        var selectedMovieHall = data.MovieHalls.Where(mh => mh.MovieId == checkMovie.MovieId);

                                        var MovieTable = new ConsoleTable("ID", "Time Showing");

                                        foreach (var movieTable in selectedMovieHall)
                                        {

                                            MovieTable.AddRow(movieTable.Id, movieTable.MovieDateTime);
                                        }

                                        MovieTable.Write();
                                    }

                                    System.Console.WriteLine("Select the Id: ");
                                    int checkId = Convert.ToInt32(System.Console.ReadLine());

                                    var checkHall = data.MovieHalls.Where(mh => mh.Id == checkId).SingleOrDefault();

                                    if (checkHall != null)
                                    {
                                        System.Console.Clear();

                                        System.Console.WriteLine($"The Time You Select is {checkHall.MovieDateTime}");

                                        var checkHallId = data.HallSeats.Where(hs => hs.TimeStartId == checkHall.Id).ToList();

                                        foreach (var item in checkHallId)
                                        {
                                            System.Console.Write($"{item.Seat} {item.SeatStatus} ");
                                        }

                                        System.Console.WriteLine("Please select your seat Example: 1,1 :");
                                        string SelectSeat = Convert.ToString(System.Console.ReadLine());

                                        var CheckSeatStatus = data.HallSeats.Where(s => s.Seat == SelectSeat).FirstOrDefault();

                                        if (CheckSeatStatus != null)
                                        {
                                            if (CheckSeatStatus.SeatStatus == HallSeat.SeatsDetail.Taken)
                                            {
                                                System.Console.WriteLine("Seat taken.");
                                            }
                                            else
                                            {
                                                System.Console.WriteLine("Selected successfully.");
                                                CheckSeatStatus.SeatStatus = HallSeat.SeatsDetail.Taken;
                                            }
                                        }

                                    }

                                    break;
                                case "2":
                                    check3 = false;
                                    break;
                                default:
                                    System.Console.WriteLine("Please select between 1-2");
                                    break;
                            }

                        }
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        System.Console.WriteLine("Please select option between 1-3");
                        break;
                }

            }
        }
    }
}


