using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace No8.Solution.Tests
{
    public class EpsonPrinterFactoryTests
    {
        [Test]
        public void CreateCanonPrinterTest()
        {
            CanonPrinterFactory factory = new CanonPrinterFactory();
            Assert.True(new CanonPrinter().Equals(factory.Create()));
        }
    }
}
