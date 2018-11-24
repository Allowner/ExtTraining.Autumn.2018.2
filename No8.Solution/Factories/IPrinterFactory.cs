//-----------------------------------------------------------------------
// <copyright file="IPrinterFactory.cs" company="No company">
//     Copyright (c) Allowner. All rights reserved.
// </copyright>
// <author>Vsevolod Gordienko</author>
//-----------------------------------------------------------------------
using System;

namespace No8.Solution
{
    /// <summary>
    /// Interface for printer factories
    /// </summary>
    public interface IPrinterFactory
    {
        /// <summary>
        /// Creates particular printer
        /// </summary>
        /// <returns>
        /// Particular printer
        /// </returns>
        Printer Create();
    }
}
