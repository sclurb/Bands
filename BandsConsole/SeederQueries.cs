using Bands.Data;
using Bands.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BandsConsole
{
    public class SeederQueries
    {

        private BandContext _context = new BandContext();

        public SeederQueries()
        {
            //_context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        public SongMember MakeJoin(Member member, Song song)
        {
            var songMember = new SongMember
            {
                SongId = song.Id,
                MemberId = member.Id
            };
            _context.Add(songMember);
            _context.SaveChanges();
            return songMember;
        }

        public Member GetMember(string name)
        {
            var members = _context.Members.Where(m => m.Name == name);
            var member = members.FirstOrDefault();
            return member;
        }

        public Song GetSong(string name)
        {
            var songs = _context.Songs.Where(m => m.SongName == name);
            var song = songs.FirstOrDefault();
            return song;
        }

        public void AddBand()
        {
            var band1 = new Band
            {
                Name = "Led Zepplin",
                Location = "London, England",
                FormDate = new DateTime(1968, 01, 01),
                Members = new List<Member>
                {
                    new Member
                    {
                        Name = "Robert Plant",
                        JoinDate = new DateTime(1966, 05, 01)
                    },
                    new Member
                    {
                        Name = "Jimmy Page",
                        JoinDate = new DateTime(1966, 05, 01)
                    },
                    new Member
                    {
                        Name = "John Bonham",
                        JoinDate = new DateTime(1966, 05, 01)
                    },
                    new Member
                    {
                        Name = "John Paul Jones",
                        JoinDate = new DateTime(1966, 05, 01)
                    },
                },
                Albums = new List<Album>
                {
                    new Album
                    {
                        AlbumName = "Led Zepplin",
                        ReleaseDate = new DateTime(1969, 01, 12),
                        Songs = new List<Song>
                        {
                            new Song
                            {
                                SongName = "Good Time Bad Times",
                            },
                            new Song
                            {
                                SongName = "Babe I'm Going Tto Leave You"
                            },
                            new Song
                            {
                                SongName = "You Shook Me"
                            },
                            new Song
                            {
                                SongName = "Dazed and Confused"
                            },
                            new Song
                            {
                                SongName = "Your Time is Going to Come"
                            },
                            new Song
                            {
                                SongName = "Communication Breakdown"
                            },
                            new Song
                            {
                                SongName = "I Can't Quit You Baby"
                            },
                            new Song
                            {
                                SongName = "How Many More Times"
                            }

                        }
                    }
                }
            };
            var band2 = new Band
            {
                Name = "The Doors",
                Location = "Los Angeles, California",
                FormDate = new DateTime(1965, 02, 03)
            };

            _context.AddRange(band1, band2);
            _context.SaveChanges();

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

            if(bands != null)
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

        public void InsertNewAlbum(string bandName)
        {
            var members = new List<Member>
            {
                new Member
                {
                    Name = "Ray Manzarek",
                    JoinDate = new DateTime(1965, 06, 15)
                },
                new Member
                {
                    Name = "Jim Morrison",
                    JoinDate = new DateTime(1965, 06, 15)
                },
                new Member
                {
                    Name = "Robby Krieger",
                    JoinDate = new DateTime(1965, 06, 15)
                },
                new Member
                {
                    Name = "John Densmore",
                    JoinDate = new DateTime(1965, 06, 15)
                }
            };

            var album = (new Album
            {
                AlbumName = "The Doors",
                ReleaseDate = new DateTime(1967, 01, 04),
                Songs = new List<Song>
                    {
                        new Song
                        {
                            SongName = "Break on Through (To the Other Side)"
                        },
                        new Song
                        {
                            SongName = "Soul Kitchen"
                        },
                        new Song
                        {
                            SongName = "The Crystal Ship"
                        },
                        new Song
                        {
                            SongName = "Twentieth Century Fox"
                        },
                        new Song
                        {
                            SongName = "Alabama Song"
                        },
                        new Song
                        {
                            SongName = "Light My Fire"
                        },
                        new Song
                        {
                            SongName = "Back Door Man"
                        },
                        new Song
                        {
                            SongName = "I Looked at You"
                        },
                        new Song
                        {
                            SongName = "End of the Night"
                        },
                        new Song
                        {
                            SongName = "Take It as It Comes"
                        },
                        new Song
                        {
                            SongName = "The End"
                        }
                    }

            });
            var band = _context.Bands.Where(b => b.Name == bandName).FirstOrDefault();
            if(band != null)
            {
                band.Albums.Add(album);
            }
            _context.SaveChanges();

        }

    }
}
