using deneme;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace deneme
{
    public class Kullanici : IEquatable<Kullanici>
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public int followers_count { get; set; }
        public int following_count { get; set; }
        public string Language { get; set; }
        public string Region { get; set; }
        public string[] Tweets { get; set; }

        public bool Equals(Kullanici other)
        {
            if (other == null)
                return false;

            return Username == other.Username;
        }

        public override int GetHashCode()
        {
            return Username.GetHashCode();
        }
    }

    class Program
    {
        static void Main()
        {
            Dictionary<Kullanici, string> map = new Dictionary<Kullanici, string>();
            // JSON dosyasının yolu
            string jsonFilePath = "/Users/melisportakal/desktop/twitter_data.json";

            // JSON dosyasındaki verileri oku
            string jsonContent = File.ReadAllText(jsonFilePath);

            // JSON verilerini C# nesnesine dönüştür
            var users = JsonConvert.DeserializeObject<List<Kullanici>>(jsonContent);

            if (users.Count > 0)
            {
                for (int i = 0; i < Math.Min(5, users.Count); i++)
                {
                    var currentUser = users[i];
                    map.Add(currentUser, currentUser.Username);
                    Console.WriteLine($"Username: {currentUser.Username}, Name: {currentUser.Name}, Followers: {currentUser.followers_count}, Following: {currentUser.following_count}, Language: {currentUser.Language}, Region: {currentUser.Region}, Tweets: {string.Join(", ", currentUser.Tweets)}");
                    // Diğer kullanıcı bilgilerini ve ilgili verileri de yazdırabilirsiniz.
                }
            }
            else
            {
                Console.WriteLine("JSON dosyasında hiç kullanıcı yok.");
            }

            foreach (var entry in map)
            {
                Console.WriteLine($"dil: {entry.Key.Language}, Değer (username): {entry.Value}");
            }

            Console.ReadLine();
        }
    }
}