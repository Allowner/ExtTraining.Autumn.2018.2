//-----------------------------------------------------------------------
// <copyright file="PrinterManager.cs" company="No company">
//     Copyright (c) Allowner. All rights reserved.
// </copyright>
// <author>Vsevolod Gordienko</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using No8.Solution;

namespace No8
{
    /// <summary>
    /// Manager that operate with printers
    /// </summary>
    public class PrinterManager
    {
        private ILog logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrinterManager"/> class
        /// </summary>
        /// <param name="logger">
        /// Instance to log information
        /// </param>
        public PrinterManager(ILog logger)
        {
            this.Printers = new Dictionary<string, List<Printer>>();
            this.logger = logger;
            this.Add(new CanonPrinterFactory());
            this.Add(new EpsonPrinterFactory());
        }

        private Dictionary<string, List<Printer>> Printers { get; set; }

        /// <summary>
        /// Adds new printer to other printers
        /// </summary>
        /// <param name="name">
        /// Name of the printer
        /// </param>
        /// <param name="model">
        /// Model of the printer
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if has null arguments.
        /// </exception>
        /// <returns>
        /// True if added successfully, false if not
        /// </returns>
        public bool Add(string name, string model)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            CustomPrinter printer;
            List<Printer> printers;
            this.Printers.TryGetValue(name, out printers);

            if (printers != null)
            {
                foreach (Printer p in printers)
                {
                    if (p.Model == model)
                    {
                        return false;
                    }
                }
            }

            printer = new CustomPrinter(name, model);
            printer.Operation += PrintStartMessage;
            printer.EndOperation += PrintEndMessage;
            if (printers == null)
            {
                this.Printers[name] = new List<Printer>() { printer };
            }
            else
            {
                this.Printers[name].Add(printer);
            }

            this.logger.Info("Printer added");
            return true;
        }

        /// <summary>
        /// Make some printer to print
        /// </summary>
        /// <param name="printer">
        /// Printer that will print
        /// </param>
        /// <param name="path">
        /// Source of printing file
        /// </param>
        /// <exception cref="FileNotFoundException">
        /// Thrown if file doesn't exist
        /// </exception>
        public void Print(Printer printer, string path)
        {
            if (!File.Exists(path))
            {
                this.logger.Error($"File not found at {path}");
                throw new FileNotFoundException(nameof(path));
            }

            this.logger.Info("Print started");
            using (FileStream sr = new FileStream(path, FileMode.Open))
            {
                printer.Print(sr);
            }

            this.logger.Info("Print finished");
            this.logger.Info($"Printed on {printer.Name} {printer.Model}");
        }

        /// <summary>
        /// Counts printer names
        /// </summary>
        /// <returns>
        /// Amount of printers
        /// </returns>
        public int GetPrintersNameAmount()
        {
            return this.Printers.Count;
        }

        /// <summary>
        /// Search for printers with such name
        /// </summary>
        /// <param name="name">
        /// Name of printer
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if name is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if name doesn't exist
        /// </exception>
        /// <returns>
        /// List of printers with such name
        /// </returns>
        public List<Printer> GetPrinterModels(string name)
        {
            List<Printer> printers = null;
            try
            {
                printers = new List<Printer>(this.Printers[name]);
            }
            catch (ArgumentNullException)
            {
                this.logger.Error("Printer name is not defined");
                throw new ArgumentNullException(nameof(name));
            }
            catch (KeyNotFoundException)
            {
                this.logger.Error("Printer name is not found");
                throw new ArgumentException($"No such printer {name}");
            }

            return printers;
        }

        /// <summary>
        /// Returns printers names
        /// </summary>
        /// <returns>
        /// List of names
        /// </returns>
        public List<string> GetPrintersNames()
        {
            List<string> printers = new List<string>(this.Printers.Keys);
            return printers;
        }

        /// <summary>
        /// Gets printers name by index
        /// </summary>
        /// <param name="index">
        /// Index in printers
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if index is invalid
        /// </exception>
        /// <returns>
        /// Name of printer
        /// </returns>
        public string GetPrinterNameByIndex(int index)
        {
            if (index < 0 || index >= this.Printers.Count)
            {
                this.logger.Error("Printer index is invalid");
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return this.Printers.Keys.ElementAt(index);
        }

        private static void PrintStartMessage(object sender, PrinterEventArgs e)
        {
            Console.WriteLine($"Printer {e.Name} {e.Model} started to print.");
        }

        private static void PrintEndMessage(object sender, PrinterEventArgs e)
        {
            Console.WriteLine($"Printer {e.Name} {e.Model} finished printing.");
        }

        private void Add(IPrinterFactory factory)
        {
            Printer printer = factory.Create();
            this.Printers[printer.Name] = new List<Printer>() { printer };
        }
    }
}