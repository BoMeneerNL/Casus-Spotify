using backgroundworker;
using System;
using System.Collections.Generic;
using System.Threading;

namespace clh
{
    public class Program
    {
        public static List<Afspeellijst> playlists = DataController.GetAllAfspeellijsten(1);

        public static int calculate_duration(string time)
        {

            string[] secondpush = time.Trim().Split(":");
            int minutes = int.Parse(secondpush[0]) * 60;
            return int.Parse(secondpush[1]) + minutes;
        }

        public static void Main()
        {
            Console.Title = "Casus Spotify";
            //Console.WriteLine(calculate_duration("1:46"));
            //return;
            string passthrou = "";
            while (true)
            {
                List<Song> Waitinglist = new();
                int CurrentTimeLeft;
                if (passthrou != "")
                {
                    Console.WriteLine(passthrou);
                    passthrou = "";
                }
                Console.WriteLine("Welcome to CasusSpotify");
                Console.WriteLine("What action do you want to do?");
                Console.WriteLine("1) See, play or edit my playlist(s)");
                Console.WriteLine("2) See, add or remove my friend(s)");
                Console.WriteLine("3) See and play playlist(s) of my friend(s)");
                Console.WriteLine("4) See all songs and albums");
                Console.WriteLine("5) Add song(s) to waiting list");
                Console.WriteLine("6) Play waiting list");
                Console.WriteLine("7) Exit CasusSpotify");
                Console.Write("> ");
                ConsoleKeyInfo input = Console.ReadKey();
                Console.WriteLine();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        while (true)
                        {
                            passthrou = "";
                            if (passthrou != "")
                                Console.WriteLine(passthrou);
                            Console.WriteLine("What do you want to do with your playlist(s)?");
                            Console.WriteLine("1) See a specific playlist");
                            Console.WriteLine("2) See all songs in all playlists");
                            Console.WriteLine("3) Add a song to an playlist");
                            Console.WriteLine("4) Remove a song from a playlist");
                            Console.WriteLine("5) Create a new playlist");
                            Console.WriteLine("6) Delete a playlist");
                            Console.WriteLine("7) Go back");
                            Console.Write("> ");
                            input = Console.ReadKey();
                            Console.WriteLine();
                            switch (input.Key)
                            {
                                case ConsoleKey.D1:
                                    if (DataController.GetCount("playlists_1") == 0)
                                    {
                                        Console.WriteLine("You currently don't have a playlist, do you want to create one? (y/n)");
                                        while (input.Key is not ConsoleKey.Y and not ConsoleKey.N)
                                        {
                                            Console.Write("> ");
                                            input = Console.ReadKey();
                                            Console.WriteLine();
                                        }
                                        if (input.Key == ConsoleKey.N) break;
                                        Console.WriteLine("How do you want to name the playlist?");
                                        Console.Write("> ");
                                        string NameNewPlaylist = Console.ReadLine();
                                        DataController.CreatePlaylist(NameNewPlaylist, 1);
                                        break;
                                    }
                                    else
                                    {
                                        int counter = 0;
                                        Console.Clear();
                                        Console.WriteLine("What playlist do you want to edit?");
                                        for (int i = 0; i < playlists.Count; i++)
                                        {
                                            Console.WriteLine($"{i + 1}) {playlists[i].Name}");
                                            counter++;
                                        }

                                        Console.Write("> ");
                                        string inp = Console.ReadLine();
                                        if (int.TryParse(inp, out _))
                                        {
                                            if (int.Parse(inp) <= counter && int.Parse(inp) > 0)
                                            {
                                                Afspeellijst hi = playlists[int.Parse(inp) - 1];
                                                Console.Clear();
                                                Console.WriteLine($"What do you want to do with the playlist: {hi.Name}?");
                                                Console.WriteLine("1) Add song(s)");
                                                Console.WriteLine("2) Remove song(s)");
                                                Console.WriteLine("3) Rename this playlist");
                                                Console.WriteLine("4) Delete this playlist");
                                                Console.Write("> ");
                                                input = Console.ReadKey();
                                                Console.WriteLine();
                                                switch (input.Key)
                                                {
                                                    case ConsoleKey.D1:

                                                        break;
                                                    case ConsoleKey.D2:

                                                        break;
                                                    case ConsoleKey.D3:

                                                        break;
                                                    case ConsoleKey.D4:
                                                        Console.WriteLine($"Are you sure you want to delete {hi.Name}? (y/n)");
                                                        Console.Write("> ");
                                                        input = Console.ReadKey();
                                                        Console.WriteLine();
                                                        if (input.Key == ConsoleKey.Y)
                                                        {
                                                            Console.WriteLine($"The playlist {hi.Name} will be deleted...");
                                                            DataController.DeletePlaylist(hi.PlaylistID);
                                                            Console.WriteLine($"The playlist {hi.Name} is deleted");
                                                        }
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("The number given could not be found linked to a playlist");
                                                Console.ResetColor();
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("FATAL ERROR: String unconvertable to INT");
                                            Environment.Exit(0);
                                        }
                                        playlists = DataController.GetAllAfspeellijsten(1);
                                    }
                                    break;
                                case ConsoleKey.D2:
                                    break;
                                case ConsoleKey.D3:

                                    break;
                                case ConsoleKey.D4:

                                    break;
                                case ConsoleKey.D5:
                                    Console.WriteLine("How do you want to call your new playlist");
                                    Console.Write("> ");
                                    DataController.CreatePlaylist(Console.ReadLine(), 1);
                                    Console.Clear();
                                    Console.WriteLine("The new playlist is created");
                                    break;

                            }
                            if (input.Key == ConsoleKey.D7)
                            {
                                Console.Clear();
                                input = new();
                                break;
                            }

                        }
                        break;
                    case ConsoleKey.D2:

                        break;
                    case ConsoleKey.D3:
                        passthrou = "Oops, none of your friends have playlists :(";
                        break;
                    case ConsoleKey.D4:

                        break;
                    case ConsoleKey.D5:

                        List<Song> csongs = DataController.GetAllSongs();
                        for (int i = 0; i < csongs.Count; i++)
                            Console.WriteLine($"{i + 1}) {csongs[i]}");

                        Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
                        Console.WriteLine("What song do you want to add to the waitinglist?");
                        Console.Write("> ");
                        string inpu = Console.ReadLine();
                        if (int.TryParse(inpu,out _)) {
                            int selector = int.Parse(inpu);

                        }
                        else
                        {

                        }
                        break;
                    case ConsoleKey.D6:
                        if (Waitinglist.Count > 0)
                        {
                            foreach (Song song in Waitinglist)
                            {
                                int duration = song.Duration;
                                CurrentTimeLeft = duration;
                                for (int i = duration; i > 0; i--)
                                {
                                    for (int j = 100; j > 0; j--)
                                    {
                                        if (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
                                        {
                                            Console.WriteLine($"{i},{j}");
                                            Thread.Sleep(10);
                                        }
                                        else
                                            Pause();

                                    }
                                    CurrentTimeLeft--;
                                }

                            }
                            Console.Clear();
                            Console.WriteLine("Waitlist is finished");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("The waitlist has no songs, try adding some.");
                        }
                        break;
                }
                if (input.Key == ConsoleKey.D7)
                    break;
            }
            Console.Clear();
            Console.WriteLine("Thanks for using CasusSpotify");
        }
        public static void Pause()
        {
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {

            }
        }
        public static void Login()
        {
            Console.WriteLine("Welcome to CasusSpotify, do you already have an account? (y/n)");
            string answer = Console.ReadLine();
            while (true)
            {
                if (answer == "y")
                {
                    while (true)
                    {
                        Console.WriteLine("If you don't have an account and want to register, use the username 'register'");
                        Console.WriteLine("::Login::");
                        Console.Write("Please enter your username: ");
                        string username = Console.ReadLine();
                        if (username == "register")
                        {
                            answer = "n";
                            break;
                        }
                        Console.Write("Please enter your password: ");
                        string password = Console.ReadLine();

                        DataController.credentials_check(username, password);
                    }

                }
                else if (answer == "n")
                {
                    Console.WriteLine("Do you want ro register an account? (y/n)");
                    string answer2 = Console.ReadLine();
                    if (answer2 == "y")
                    {
                        while (true)
                        {
                            Console.WriteLine("If you want to login instead of registering an new account, use the username 'login'");
                            Console.WriteLine("::Register::");
                            Console.Write("Please enter your new username: ");
                            string username = Console.ReadLine();
                            if (username == "login")
                            {
                                answer = "y";
                                break;
                            }
                            Console.Write("Please enter your new password: ");
                            string password = Console.ReadLine();
                            if (DataController.CreateAccount(username, password))
                            {
                                return;
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("Have a nice day.");
                        Environment.Exit(0);
                    }

                }
            }
        }
    }
}
