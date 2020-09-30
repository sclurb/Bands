using System;
using System.Collections.Generic;
using System.Text;

namespace Bands.Domain
{
    public class Album
    {
        public int Id { get; set; }
        public string AlbumName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Song> Songs { get; set; }

    }
}
