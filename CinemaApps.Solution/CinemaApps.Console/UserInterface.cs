using CinemaApps.Console.Model;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

                System.Console.WriteLine("Welcome To TGV Cinema Ticket App.");
                System.Console.WriteLine("\n \t 1.View all movies");
                System.Console.WriteLine("\t 2.Login");
                System.Console.WriteLine("\t 3.Exit app");
                string opt = System.Console.ReadLine();

                switch (opt)
                {
                    case "1":

                        System.Console.Clear();

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
                            //Find user name and password
                            var checkUser = data.Users.Where(c => c.Username == username && c.Password == password).SingleOrDefault();

                            //Check the username and password if is null or just a space it will check

                            if (checkUser != null)
                            {
                                check2 = false;
                            }
                            else if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || checkUser == null)
                            {
                                System.Console.WriteLine("User not found");

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
                                    //find the movie that the status is now showing
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
                                            //for hall id =3,it will like spacing when the loop get 1,10
                                            if (item.Seat == "1,10" || item.Seat == "2,10" || item.Seat == "3,10" || item.Seat == "4,10" || item.Seat == "5,10")
                                            {
                                                System.Console.WriteLine("\n");
                                            }

                                        }
                                        var checkseat = true;
                                        while (checkseat)
                                        {
                                            System.Console.WriteLine("Please select your seat Example: 1,1 :");

                                            string SelectSeat = Convert.ToString(System.Console.ReadLine());

                                            var CheckSeatStatus = data.HallSeats.Where(s => s.Seat == SelectSeat).FirstOrDefault();


                                            if (CheckSeatStatus != null)
                                            {
                                                if (CheckSeatStatus.SeatStatus == HallSeat.SeatsDetail.Taken)
                                                {
                                                    System.Console.WriteLine("Seat taken.");
                                                    checkseat = true;
                                                }
                                                else
                                                {
                                                    System.Console.WriteLine("Selected successfully.");
                                                    CheckSeatStatus.SeatStatus = HallSeat.SeatsDetail.Taken;
                                                    Thread.Sleep(1000);
                                                    checkseat = false;
                                                    
                                                }
                                            }

                                        }
                                    }

                                    break;
                                case "2":
                                    check3 = false;
                                    break;
                                default:
                                    System.Console.Clear();
                                    System.Console.WriteLine("Please select between 1-2");
                                    break;
                            }

                        }
                        break;
                    case "3":
                        System.Console.WriteLine("Thank you for using TGV Cinema Ticket App");
                        Environment.Exit(0);
                        break;
                    default:
                        System.Console.Clear();
                        System.Console.WriteLine("Please select option between 1-3");
                        break;
                }

            }
        }
    }
}


