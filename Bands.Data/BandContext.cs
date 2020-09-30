using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Bands.Domain;

namespace Bands.Data
{
    public class BandContext : DbContext
    {
        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public  DbSet<Member> Members { get; set; }

        private string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = BandTestData;";

        public BandContext()
        {

        }

        public BandContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SongMember>().HasKey(s => new { s.MemberId, s.SongId});
        }
    }
}
