using Bands.Data;
using Bands.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Tests
{
    [TestClass]
    public class InMemoryTests
    {
        [TestMethod]
        public void CanInsertBandIntoDatabase()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("CanInsertBand");
            using (var context = new BandContext(builder.Options))
            {

                var band = new Band();
                context.Bands.Add(band);

                Assert.AreEqual(EntityState.Added, context.Entry(band).State);
            }

        }
    }
}
