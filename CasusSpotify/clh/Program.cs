using System;
namespace clh
{
    public class Program
    {
        public static int calculate_duration(string time)
        {

            string[] secondpush = time.Trim().Split(":");
            int minutes = int.Parse(secondpush[0]) * 60;
            return int.Parse(secondpush[1]) + minutes;
        }

        public static void Main()
        {
            Console.Title = "Casus Spotify";
            //Console.WriteLine(calculate_duration("2:54"));
            //return;
            string passthrou = "";
            while (true)
            {
                if(passthrou != "")
                {
                    Console.WriteLine(passthrou);
                    passthrou = "";
                }
                Console.Clear();
                Console.WriteLine("Welcome to CasusSpotify");
                Console.WriteLine("What action do you want to do?");
                Console.WriteLine("1) See, play or edit my playlist(s)");
                Console.WriteLine("2) See, add or remove my friend(s)");
                Console.WriteLine("3) See and play playlist(s) of my friend(s)");
                Console.WriteLine("4) See all and it songs albums");
                Console.WriteLine("5) Exit CasusSpotify");
                Console.Write("> ");
                ConsoleKeyInfo input = Console.ReadKey();
                Console.WriteLine();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        while (true)
                        {
                            passthrou = "";
                            if(passthrou != "")
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
                            
                            switch (input.Key)
                            {
                                case ConsoleKey.D1:
                                    if (backgroundworker.DataController.GetCount("playlists_1") == 0) {
                                        Console.WriteLine("You currently don't have a playlist, do you want to create one? (y/n)");
                                        while(input.Key is not ConsoleKey.Y and not ConsoleKey.N) {
                                            Console.Write("> ");
                                            input = Console.ReadKey();
                                        }
                                        if (input.Key == ConsoleKey.N) break;
                                        Console.WriteLine("How do you want to name the playlist?");
                                        Console.Write("> ");
                                        string NameNewPlaylist = Console.ReadLine();
                                        backgroundworker.DataController.CreatePlaylist(NameNewPlaylist, 1);
                                        break;
                                    }
                                    break;
                                case ConsoleKey.D2:
                                    break;
                                case ConsoleKey.D3:
                                    
                                    break;
                                case ConsoleKey.D4:

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
                        
                        break;
                }
                if(input.Key == ConsoleKey.D5)
                    break;
            }
            Console.Clear();
            Console.WriteLine("Thanks for using CasusSpotify");
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

                        backgroundworker.DataController.credentials_check(username, password);
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
                            if (backgroundworker.DataController.CreateAccount(username, password))
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
