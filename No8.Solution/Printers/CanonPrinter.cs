//-----------------------------------------------------------------------
// <copyright file="CanonPrinter.cs" company="No company">
//     Copyright (c) Allowner. All rights reserved.
// </copyright>
// <author>Vsevolod Gordienko</author>
//-----------------------------------------------------------------------
using System;

namespace No8.Solution
{
    /// <summary>
    /// Canon printer class
    /// </summary>
    public class CanonPrinter : Printer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CanonPrinter"/> class
        /// </summary>
        public CanonPrinter()
        {
            this.Name = "Canon";
            this.Model = "123x";
        }
    }
}
