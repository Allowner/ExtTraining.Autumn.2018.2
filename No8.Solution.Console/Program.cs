using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            PrinterManager manager = new PrinterManager();
            int key = -1;
            while (key != 0)
            {
                manager.PrintMenu();
                key = System.Console.Read();
                System.Console.ReadLine();
                key -= 50;
                if (key == -1)
                {
                    System.Console.WriteLine("\nEnter printer name");
                    string name = System.Console.ReadLine();
                    System.Console.WriteLine("Enter printer model");
                    string model = System.Console.ReadLine();
                    if (PrinterManager.Add(name, model))
                    {
                        System.Console.WriteLine("Printer added");
                    }
                    else
                    {
                        System.Console.WriteLine("Printer already exists");
                    }
                }
                else if (key > -1 && key < PrinterManager.Printers.Count)
                {
                    string name = PrinterManager.Printers.Keys.ElementAt(key);

                    manager.PrintPrinters(name);
                    key = System.Console.Read();
                    System.Console.ReadLine();
                    key -= 49;
                    if (key > -1 && key < PrinterManager.Printers[name].Count)
                    {
                        Printer printer = PrinterManager.Printers[name][key];
                        System.Console.WriteLine("Enter path to file: ");
                        string filePath = System.Console.ReadLine();
                        try
                        {
                            PrinterManager.Print(printer, filePath);
                        }
                        catch (FileNotFoundException exception)
                        {
                            System.Console.WriteLine(exception.Message);
                        }
                        
                        PrinterManager.Log($"Printed on {printer.Name} {printer.Model}");
                    }
                    else
                    {
                        System.Console.WriteLine("Invalid model input.");
                    }
                }
                else
                {
                    System.Console.WriteLine("Invalid command input.");
                }
            }

            System.Console.ReadKey();
        }
    }
}
