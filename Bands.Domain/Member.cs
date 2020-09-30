using System;
using System.Collections.Generic;
using System.Text;

namespace Bands.Domain
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }
        public List<SongMember> SongMembers { get; set; }
    }
}
