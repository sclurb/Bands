using Bands.Data;
using Bands.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using BandsConsole;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class TestForConsoleApp
    {
        [TestMethod]
        public void AddMultipleBandsReturnsCorrectNumberOfRowa()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("AddMultipleBands");
            using (var context = new BandContext(builder.Options))
            {
                var queryData = new QueryData(context);
                var nameList = new string[] { "Kix", "Van Halen", "LynardSkynard", "The Cult" };
                var result = queryData.AddMultipleBands(nameList);
                Assert.AreEqual(nameList.Length, result);
            }
        }

        [TestMethod]
        public void CanInsertSingleBand()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("InsertSingleBand");
            using(var context = new BandContext(builder.Options))
            {
                var queryData = new QueryData(context);
                queryData.InsertNewBand(new Band());
            }
            using (var context2 = new BandContext(builder.Options))
            {
                Assert.AreEqual(1, context2.Bands.Count());
            }
        }
    }
}
