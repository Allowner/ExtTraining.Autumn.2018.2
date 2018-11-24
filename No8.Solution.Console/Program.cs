using No8.Solution.Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace No8.Solution.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ILog logger = new LoggerNLog("Logger");
            PrinterManager manager = new PrinterManager(logger);
            int key = 0;
            while (key != -2)
            {
                PrintMenu(manager);
                key = System.Console.Read();
                System.Console.ReadLine();
                key -= 50;
                if (key == -1)
                {
                    AddPrinter(manager);
                }
                else if (key >= 0 && key < manager.GetPrintersNameAmount())
                {
                    string name = manager.GetPrinterNameByIndex(key);
                    List<Printer> printers = manager.GetPrinterModels(name);
                    PrintPrinters(name, printers);
                    key = System.Console.Read();
                    System.Console.ReadLine();
                    key -= 49;
                    if (key >= 0 && key < printers.Count)
                    {
                        Print(key, printers, manager);
                    }
                    else
                    {
                        System.Console.WriteLine("Invalid model input.");
                    }
                }
                else if (key != -2)
                {
                    System.Console.WriteLine("Invalid command input.");
                }
            }
        }

        public static void PrintMenu(PrinterManager manager)
        {
            System.Console.WriteLine("Select your choice:");
            System.Console.WriteLine("1:Add new printer");
            int i = 2;
            foreach (string printer in manager.GetPrintersNames())
            {
                System.Console.WriteLine($"{i}:Print on {printer}");
                i++;
            }
            System.Console.WriteLine($"0:Quit");
        }

        public static void PrintPrinters(string name, List<Printer> models)
        {
            System.Console.WriteLine($"{name} models: ");

            int i = 1;
            foreach (Printer printer in models)
            {
                System.Console.WriteLine($"{i}:{printer.Model}");
                i++;
            }
        }

        public static void Print(int number, List<Printer> printers, PrinterManager manager)
        {
            Printer printer = printers[number];
            System.Console.WriteLine("Enter path to file: ");
            string filePath = System.Console.ReadLine();
            try
            {
                manager.Print(printer, filePath);
            }
            catch (FileNotFoundException exception)
            {
                System.Console.WriteLine(exception.Message);
            }
        }

        public static void AddPrinter(PrinterManager manager)
        {
            System.Console.WriteLine("\nEnter printer name");
            string name = System.Console.ReadLine();
            System.Console.WriteLine("Enter printer model");
            string model = System.Console.ReadLine();
            if (manager.Add(name, model))
            {
                System.Console.WriteLine("Printer added");
            }
            else
            {
                System.Console.WriteLine("Printer already exists");
            }
        }
    }
}
