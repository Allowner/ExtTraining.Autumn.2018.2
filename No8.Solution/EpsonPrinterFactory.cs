﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution
{
    public class EpsonPrinterFactory : IPrinterFactory
    {
        public Printer Create()
        {
            return new EpsonPrinter();
        }
    }
}
