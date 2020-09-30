using Bands.Data;
using Bands.Domain;
using System;
using System.Linq;

namespace BandsConsole
{
    class Program
    {
        private static SeederQueries seederQuery = new SeederQueries();
        private static QueryData queryData = new QueryData();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            
            //seederQuery.AddBand();
            seederQuery.GetBands();

            var result1 = seederQuery.GetBand("Led Zepplin");
            Console.WriteLine(result1.Name);

            var result2 = seederQuery.GetBand("Zepp");
            Console.WriteLine(result2.Name);

            //seederQuery.InsertNewAlbum("The Doors");

            //var member1 = seederQuery.GetMember("Robert Plant");
            //var member2 = seederQuery.GetMember("Jimmy Page");
            //var member3 = seederQuery.GetMember("John Paul Jones");
            //var member4 = seederQuery.GetMember("John Bonham");
            //var song1 = seederQuery.GetSong("Good Time Bad Times");
            //var song2 = seederQuery.GetSong("Babe I'm Going to Leave You");
            //var song3 = seederQuery.GetSong("You Shook Me");
            //var song4 = seederQuery.GetSong("Dazed and Confused");
            //var song5 = seederQuery.GetSong("Your Time is Going to Come");
            //var song6 = seederQuery.GetSong("Communication Breakdown");
            //var song7 = seederQuery.GetSong("I Can't Quit You Baby");
            //var song8 = seederQuery.GetSong("How Many More Times");
            //seederQuery.MakeJoin(member1, song1);
            //seederQuery.MakeJoin(member2, song1);
            //seederQuery.MakeJoin(member3, song1);
            //seederQuery.MakeJoin(member4, song1);
            //seederQuery.MakeJoin(member1, song2);
            //seederQuery.MakeJoin(member2, song2);
            //seederQuery.MakeJoin(member3, song2);
            //seederQuery.MakeJoin(member4, song2);
            //seederQuery.MakeJoin(member1, song3);
            //seederQuery.MakeJoin(member2, song3);
            //seederQuery.MakeJoin(member3, song3);
            //seederQuery.MakeJoin(member4, song3);
            //seederQuery.MakeJoin(member1, song4);
            //seederQuery.MakeJoin(member2, song4);
            //seederQuery.MakeJoin(member3, song4);
            //seederQuery.MakeJoin(member4, song4);
            //seederQuery.MakeJoin(member1, song5);
            //seederQuery.MakeJoin(member2, song5);
            //seederQuery.MakeJoin(member3, song5);
            //seederQuery.MakeJoin(member4, song5);
            //seederQuery.MakeJoin(member1, song6);
            //seederQuery.MakeJoin(member2, song6);
            //seederQuery.MakeJoin(member3, song6);
            //seederQuery.MakeJoin(member4, song6);
            //seederQuery.MakeJoin(member1, song7);
            //seederQuery.MakeJoin(member2, song7);
            //seederQuery.MakeJoin(member3, song7);
            //seederQuery.MakeJoin(member4, song7);
            //seederQuery.MakeJoin(member1, song8);
            //seederQuery.MakeJoin(member2, song8);
            //seederQuery.MakeJoin(member3, song8);
            //seederQuery.MakeJoin(member4, song8);

            Console.WriteLine("----");

            var songs = queryData.GetSongs("Ralph");

            foreach (var song in songs)
            {
                Console.WriteLine($"The name of the song is : {song.SongName}");

            }

            var songList = queryData.GetSongsWithWriters("Led Zepplin");

            Console.ReadKey();
        }


    }
}
