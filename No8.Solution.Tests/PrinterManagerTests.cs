using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using No8.Solution.Logger;
using NUnit.Framework;

namespace No8.Solution.Tests
{
    [TestFixture]
    public class PrinterManagerTests
    {
        public static ILog logger = new LoggerNLog("TestLogger");
        public static PrinterManager manager = new PrinterManager(logger);

        [Test]
        public void GetPrinterNameByIndexNegativeIndex_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => manager.GetPrinterNameByIndex(-1));
        }

        [Test]
        public void GetPrinterNameByIndexBigIndex_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => manager.GetPrinterNameByIndex(5));
        }

        [Test]
        public void GetPrinterNameByIndex_ReturnPrinterName()
        {
            string name = manager.GetPrinterNameByIndex(0);
            Assert.AreEqual(name, "Canon");
        }

        [Test]
        public void GetPrintersNames_ReturnNamesList()
        {
            PrinterManager manager = new PrinterManager(logger);
            List<string> list = manager.GetPrintersNames();
            Assert.True(list.SequenceEqual<string>(new List<string>() { "Canon", "Epson" }));
        }

        [Test]
        public void GetPrinterModels_ReturnPrinterList()
        {
            PrinterManager manager = new PrinterManager(logger);
            manager.Add("Canon", "new");
            List<Printer> canons = manager.GetPrinterModels("Canon");
            Assert.True(canons.SequenceEqual<Printer>(new List<Printer>() {
                new CanonPrinter(), new CustomPrinter("Canon", "new")}));
        }

        [Test]
        public void GetPrinterModels_WithNullName_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => manager.GetPrinterModels(null));
        }

        [Test]
        public void GetPrinterModels_WithInvalidName_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => manager.GetPrinterModels("invalid"));
        }

        [Test]
        public void GetPrinterAmount_ReturnNumber()
        {
            Assert.AreEqual(manager.GetPrintersNameAmount(), 3);
        }

        [Test]
        public void PrintNotExisting_ThrowsFileNotFoundException()
        {
            CanonPrinter printer = new CanonPrinter();
            Assert.Throws<FileNotFoundException>(() => manager.Print(printer, "path"));
        }

        [Test]
        public void Add_ExistingPrinter_ReturnFalse()
        {
            PrinterManager manager = new PrinterManager(logger);
            Assert.False(manager.Add("Canon", "123x"));
        }

        [Test]
        public void Add_PrinterWithSameName_ReturnTrue()
        {
            PrinterManager manager = new PrinterManager(logger);
            Assert.True(manager.Add("Canon", "125x"));
        }

        [Test]
        public void Add_Printer_ReturnTrue()
        {
            Assert.True(manager.Add("Seva", "new"));
        }

        [Test]
        public void Add_Printer_WithNullName_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => manager.Add(null, "invalid"));
        }

        [Test]
        public void Add_Printer_WithNullModel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => manager.Add("invalid", null));
        }
    }
}
