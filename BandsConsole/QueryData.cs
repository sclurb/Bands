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

        private BandContext _context = new BandContext();
        public QueryData()
        {

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
            var songsWithWriters = _context.Bands.Where(band => band.Name == name)
                .Select(b => new
                {
                    Band = b,
                    //Songs = b.SongMembers.Select(sm => sm.Song)
                    Writers = b.SongMembers.Select(w => w.Member)
                })
                .FirstOrDefault();

            var songList = new List<Song>();
            return songList;
        }
    }
}
