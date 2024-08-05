using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lottery.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery.Models;
using System.Runtime.Remoting.Contexts;

namespace Lottery.Services.Tests
{
    [TestClass()]
    public class DataStoreTests
    {
        private Context _mockContext;
        [TestMethod()]
        public void LoadDrawsTest()
        {
            var service = new DataStore(_mockContext);
            List<Draw> draws = service.LoadDraws();
            Assert.Fail();
        }
    }
}