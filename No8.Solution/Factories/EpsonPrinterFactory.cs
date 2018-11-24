//-----------------------------------------------------------------------
// <copyright file="EpsonPrinterFactory.cs" company="No company">
//     Copyright (c) Allowner. All rights reserved.
// </copyright>
// <author>Vsevolod Gordienko</author>
//-----------------------------------------------------------------------
using System;

namespace No8.Solution
{
    /// <summary>
    /// Factory for epson printers
    /// </summary>
    public class EpsonPrinterFactory : IPrinterFactory
    {
        /// <summary>
        /// Creates epson printer
        /// </summary>
        /// <returns>
        /// Epson printer
        /// </returns>
        public Printer Create()
        {
            return new EpsonPrinter();
        }
    }
}
