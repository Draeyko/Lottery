using NUnit.Framework;
using System;

namespace LotteryTests
{
    [TestFixture]
    public class TestSample
    {
        [SetUp]
        public void Setup()
        {
            // write your test fixture setup
        }

        [TearDown]
        public void TearDown()
        {
            // write your test fixture teardown 
        }

        [Test]
        public void Pass()
        {
            Console.WriteLine("test1");
            Assert.True(true);
        }

        [Test]
        public void Fail()
        {
            Assert.False(true);
        }

        [Test]
        [Ignore("another time")]
        public void Ignore()
        {
            Assert.False(true);
        }

        [Test]
        public void Inconclusive()
        {
            Assert.Inconclusive(nameof(Inconclusive));
        }
    }
}