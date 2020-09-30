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
            //var song = seederQuery.GetSong("How Many More Times");
            //seederQuery.MakeJoin(member1, song);
            //seederQuery.MakeJoin(member2, song);
            //seederQuery.MakeJoin(member3, song);
            //seederQuery.MakeJoin(member4, song);

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
