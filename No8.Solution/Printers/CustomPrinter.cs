//-----------------------------------------------------------------------
// <copyright file="CustomPrinter.cs" company="No company">
//     Copyright (c) Allowner. All rights reserved.
// </copyright>
// <author>Vsevolod Gordienko</author>
//-----------------------------------------------------------------------
using System;

namespace No8.Solution
{
    /// <summary>
    /// Custom printer class
    /// </summary>
    public class CustomPrinter : Printer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomPrinter"/> class
        /// </summary>
        /// <param name="name">
        /// Name of printer
        /// </param>
        /// <param name="model">
        /// Printer model
        /// </param>
        public CustomPrinter(string name, string model)
        {
            this.Name = name;
            this.Model = model;
        }
    }
}
