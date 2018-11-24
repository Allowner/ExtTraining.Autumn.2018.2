using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace No8.Solution.Tests
{
    [TestFixture]
    public class PrinterTests
    {
        [Test]
        public void EqualCanonsTest()
        {
            Assert.AreEqual(new CanonPrinter(), new CanonPrinter());
        }

        [Test]
        public void EqualPrintersTest()
        {
            Assert.AreEqual(new CanonPrinter(), new CustomPrinter("Canon", "123x"));
        }

        [Test]
        public void EqualCanonEpsonTest()
        {
            Assert.AreNotEqual(new CanonPrinter(), new EpsonPrinter());
        }
    }
}
