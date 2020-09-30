using Bands.Data;
using Bands.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Tests
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var context = new BandContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();
                var band = new Band();
                context.Bands.Add(band);
                Debug.WriteLine($"Before save: {band.Id}");
                context.SaveChanges();
                Debug.WriteLine($"After save: {band.Id}");

                Assert.AreNotEqual(0, band.Id);
            }

        }
    }
}
