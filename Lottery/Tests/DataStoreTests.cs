//using NUnit.Framework;
//using Lottery.Services;
//using System.Collections.Generic;
//using Lottery.Models;
//using static Android.Provider.Contacts.Intents;
//using Lottery.Services;

//namespace Lottery
//{
//    [TestFixture]
//    public class DataStoreTests
//    {
//        [Test]
//        public void LoadDraws_ShouldReturnListOfDraws()
//        {
//            var service = new DataStore();
//            List<Draw> draws = service.LoadDraws();

//            Assert.IsNotNull(draws);
//            Assert.IsNotEmpty(draws);
//        }

//        [Test]
//        public void LoadDraws_ShouldHandleInvalidJson()
//        {
//            // Replace with a path to an invalid JSON file
//            var service = new DataStore();
//            List<Draw> draws = service.LoadDraws();

//            Assert.IsNull(draws);
//        }
//    }
//}
