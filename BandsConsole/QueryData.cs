using Bands.Data;
using Bands.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BandsConsole
{
    public class QueryData
    {

        private BandContext _context;
        public QueryData(BandContext context)
        {
            _context = context;
        }

        public QueryData()
        {
            _context = new BandContext();
        }

        public int InsertNewBand(Band band)
        {
            _context.Bands.Add(band);
            var result = _context.SaveChanges();
            return result;
        }

        public int AddMultipleBands(string[] nameList)
        {
            var bandList = new List<Band>();
            foreach (var name in nameList)
            {
                bandList.Add(new Band { Name = name });
            }
            _context.Bands.AddRange(bandList);
            var dbResult = _context.SaveChanges();
            return dbResult;
        }

        public List<Song> GetSongs(string name)
        {
            var bands = _context.Bands
                .Include(a => a.Albums)
                .ThenInclude(s => s.Songs)
                .FirstOrDefault(band => band.Name == "Led Zepplin");

            var songs = bands.Albums.Select(s => s.Songs)
                .FirstOrDefault();
                return songs;
        }

        public List<Song> GetSongsWithWriters(string name)
        {
            var songsWithWriters = _context.Bands
                .Include(a => a.Albums)
                .ThenInclude(sm => sm.Songs)
                .ThenInclude(s => s.SongMembers)
                .ThenInclude(m => m.Member)
                .FirstOrDefault(band => band.Name == name);

            var songList = songsWithWriters.Albums
                .Select(s => s.Songs)
                .FirstOrDefault();

            return songList;
        }

        public void GetBands()
        {
            var bands = _context.Bands.ToList();
            Console.WriteLine($"The number of bands in the database is {bands.Count}");

            foreach (var band in bands)
            {
                Console.WriteLine($"The band's name is: {band.Name}");
                Console.WriteLine($"{band.Name} was formed in {band.FormDate} in : {band.Location}");
            }
        }

        public Band GetBand(string name)
        {
            var bands = _context.Bands.OrderBy(b => b.Name).ToList();

            if (bands != null)
            {
                foreach (var band in bands.Where(b => b.Name.Contains(name)))
                {
                    return band;
                }
            }
            return new Band
            {
                Name = "Not Found"
            };

        }


    }
}


                //.Select(b => new
                // {
                //     Band = b,
                //     Songs = b.SongMembers.Select(sm => sm.Song),
                //     Writers = b.SongMembers.Select(w => w.Member)
                // })