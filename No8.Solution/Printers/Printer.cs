//-----------------------------------------------------------------------
// <copyright file="Printer.cs" company="No company">
//     Copyright (c) Allowner. All rights reserved.
// </copyright>
// <author>Vsevolod Gordienko</author>
//-----------------------------------------------------------------------
using System;
using System.IO;

namespace No8.Solution
{
    /// <summary>
    /// Abstract printer class
    /// </summary>
    public abstract class Printer : IEquatable<Printer>
    {
        /// <summary>
        /// Event on start printing
        /// </summary>
        public event EventHandler<PrinterEventArgs> Operation = delegate { };

        /// <summary>
        /// Event on end printing
        /// </summary>
        public event EventHandler<PrinterEventArgs> EndOperation = delegate { };

        /// <summary>
        /// Gets printers name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets printers model
        /// </summary>
        public string Model { get; internal set; }

        /// <summary>
        /// Compares printers on equality
        /// </summary>
        /// <param name="other">
        /// Other printer
        /// </param>
        /// <returns>
        /// True if equal, false if not
        /// </returns>
        public bool Equals(Printer other)
        {
            return this.Name == other.Name && this.Model == other.Model;
        }

        internal virtual void Print(FileStream fs)
        {
            this.OnNewOperation(this, new PrinterEventArgs(this.Name, this.Model));
            for (int i = 0; i < fs.Length; i++)
            {
                Console.WriteLine(fs.ReadByte());
            }

            this.OnEndOperation(this, new PrinterEventArgs(this.Name, this.Model));
        }

        protected virtual void OnNewOperation(object sender, PrinterEventArgs e)
        {
            this.Operation?.Invoke(this, e);
        }

        protected virtual void OnEndOperation(object sender, PrinterEventArgs e)
        {
            this.EndOperation?.Invoke(this, e);
        }
    }
}
