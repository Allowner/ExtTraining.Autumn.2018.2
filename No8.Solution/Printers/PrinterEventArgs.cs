//-----------------------------------------------------------------------
// <copyright file="PrinterEventArgs.cs" company="No company">
//     Copyright (c) Allowner. All rights reserved.
// </copyright>
// <author>Vsevolod Gordienko</author>
//-----------------------------------------------------------------------
using System;

namespace No8.Solution
{
    /// <summary>
    /// Class that provides arguments for event
    /// </summary>
    public class PrinterEventArgs : EventArgs
    {
        private readonly string name;
        private readonly string model;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrinterEventArgs"/> class
        /// </summary>
        /// <param name="name">
        /// Name of printer
        /// </param>
        /// <param name="model">
        /// Printer model
        /// </param>
        public PrinterEventArgs(string name, string model)
        {
            this.name = name;
            this.model = model;
        }

        /// <summary>
        /// Gets printers name
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// Gets printers model
        /// </summary>
        public string Model
        {
            get { return this.model; }
        }
    }
}
