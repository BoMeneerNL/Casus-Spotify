﻿using Microsoft.Data.Sqlite;
using System;
using System.IO;
using System.Reflection;

namespace backgroundworker
{
    public class DataController
    {
        public static void credentials_check(string username, string password)
        {
            using (var connection = new SqliteConnection(@$"Data Source={Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\niet_spotify.databasefile"))
            {
                Console.WriteLine(username);
                Console.WriteLine(password);
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @" SELECT userid FROM user WHERE username = $username AND password = $password LIMIT 1";
                command.Parameters.AddWithValue("$username", username);
                command.Parameters.AddWithValue("$password", password);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader.GetString(0);
                        Console.WriteLine($"Hello, {name}!");
                    }
                }
            }
        }
        public static bool CreateAccount(string username,string password)
        {
            using (var connection = new SqliteConnection(@$"Data Source={Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\niet_spotify.databasefile"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"SELECT userid FROM user WHERE username = $username LIMIT 1";
                command.Parameters.AddWithValue("$username", username);

                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                        return false;
                
            }
            using (var connection = new SqliteConnection(@$"Data Source={Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\niet_spotify.databasefile"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO user (username, password) VALUES ($username, $password)";
                command.Parameters.AddWithValue("$username", username);
                command.Parameters.AddWithValue("$password", password);
                command.ExecuteNonQuery();
            }
            using (var connection = new SqliteConnection(@$"Data Source={Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\niet_spotify.databasefile"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"SELECT userid FROM user WHERE username = $username AND password = $password LIMIT 1";
                command.Parameters.AddWithValue("$username", username);
                command.Parameters.AddWithValue("$password", password);

                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                        return true;
                return false;

            }
        }

        public static int GetCount(string item)
        {
            int amount = 0;
            if (item.StartsWith("playlists_"))
            {
                int userid = int.Parse(item[10..]);
                using (var connection = new SqliteConnection(@$"Data Source={Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\niet_spotify.databasefile"))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"SELECT UserIDBound FROM playlists WHERE UserIDBound = $userid";
                    command.Parameters.AddWithValue("$userid", userid);
                    using (var reader = command.ExecuteReader())
                        while (reader.Read())
                            amount++;
                }
                return amount;
            }
            return amount;
        }

        public static void CreatePlaylist(string nameNewPlaylist, int userid)
        {
            using (var connection = new SqliteConnection(@$"Data Source={Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\niet_spotify.databasefile"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO playlists (UserIDBound, PlaylistName) VALUES ($userid, $playlistname)";
                command.Parameters.AddWithValue("$userid", userid);
                command.Parameters.AddWithValue("$playlistname", nameNewPlaylist);
                command.ExecuteNonQuery();
            }
        }
    }
}