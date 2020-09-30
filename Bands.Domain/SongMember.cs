using System;
using System.Collections.Generic;
using System.Text;

namespace Bands.Domain
{
    public class SongMember
    {
        public int SongId { get; set; }
        public int MemberId { get; set; }
        public Song Song { get; set; }
        public Member Member { get; set; }
    }
}
