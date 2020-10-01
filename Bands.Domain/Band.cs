using System;
using System.Collections.Generic;
using System.Text;

namespace Bands.Domain
{
    public class Band
    {
        public Band()
        {
            Albums = new List<Album>();
        }

        public int Id { get; set; }
       // public int BandId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime FormDate { get; set; }
        public List<Member> Members { get; set; }
        public List<SongMember> SongMembers { get; set; }
        public List<Album> Albums { get; set; }
    }
}
