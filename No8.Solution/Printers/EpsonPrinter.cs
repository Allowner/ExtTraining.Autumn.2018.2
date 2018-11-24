//-----------------------------------------------------------------------
// <copyright file="EpsonPrinter.cs" company="No company">
//     Copyright (c) Allowner. All rights reserved.
// </copyright>
// <author>Vsevolod Gordienko</author>
//-----------------------------------------------------------------------
using System;

namespace No8.Solution
{
    /// <summary>
    /// Epson printer class
    /// </summary>
    public class EpsonPrinter : Printer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EpsonPrinter"/> class
        /// </summary>
        public EpsonPrinter()
        {
            this.Model = "231";
            this.Name = "Epson";
        }
    }
}
