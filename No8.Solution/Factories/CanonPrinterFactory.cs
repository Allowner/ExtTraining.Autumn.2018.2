//-----------------------------------------------------------------------
// <copyright file="CanonPrinterFactory.cs" company="No company">
//     Copyright (c) Allowner. All rights reserved.
// </copyright>
// <author>Vsevolod Gordienko</author>
//-----------------------------------------------------------------------
using System;

namespace No8.Solution
{
    /// <summary>
    /// Factory for canon printers
    /// </summary>
    public class CanonPrinterFactory : IPrinterFactory
    {
        /// <summary>
        /// Creates canon printer
        /// </summary>
        /// <returns>
        /// Canon printer
        /// </returns>
        public Printer Create()
        {
            return new CanonPrinter();
        }
    }
}
