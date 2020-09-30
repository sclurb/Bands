using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace Bands.Domain
{
    public class Song
    {
        public int Id { get; set; }
        public string SongName { get; set; }
        //public List<Member> Writers { get; set; }
        public List<SongMember> SongMembers { get; set; }

    }
}
