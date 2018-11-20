using NLog;
using No8.Solution;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace No8
{
    public delegate void PrinterDelegate(string arg);

    public class PrinterManager
    {
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        static PrinterManager()
        {
            Printers = new Dictionary<string, List<Printer>>();
            Add(new CanonPrinterFactory());
            Add(new EpsonPrinterFactory());
        }

        public static Dictionary<string, List<Printer>> Printers { get; private set; }
        
        private static void Add(IPrinterFactory factory)
        {
            Printer printer = factory.Create();
            Printers[printer.Name] = new List<Printer>() { printer };
        }

        public static bool Add(string name, string model)
        {
            CustomPrinter printer;
            
            printer = new CustomPrinter(name, model);

            List<Printer> printers;
            Printers.TryGetValue(name, out printers);

            if (printers == null)
            {
                Printers[name] = new List<Printer>() { new CustomPrinter(name, model) };
                return true;
            }
            
            foreach (Printer p in printers)
            {
                if (p.Model == model)
                {
                    return false;
                }
            }

            Printers[name].Add(new CustomPrinter(name, model));
            
            return true;
        }

        public static void Print(Printer printer, string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(nameof(path));
            }

            Log("Print started");
            using (FileStream sr = new FileStream(path, FileMode.Open))
            {
                printer.Operation += PrintStartMessage;
                printer.EndOperation += PrintEndMessage;
                printer.Print(sr);
                printer.Operation -= PrintStartMessage;
                printer.EndOperation -= PrintEndMessage;
            }
            Log("Print finished");
        }

        public static void Log(string s)
        {
            logger.Info(s);
            /*using (StreamWriter sw = File.AppendText("myFile.txt"))
            {
                sw.WriteLine(s);
            }*/
        }

        public void PrintMenu()
        {
            Console.WriteLine("Select your choice:");
            Console.WriteLine("1:Add new printer");
            int i = 2;
            foreach (string printer in Printers.Keys)
            {
                Console.WriteLine($"{i}:Print on {printer}");
                i++;
            }
        }

        public void PrintPrinters(string name)
        {
            Console.WriteLine($"{name} models: ");

            int i = 1;
            foreach (Printer printer in Printers[name])
            {
                Console.WriteLine($"{i}:{printer.Model}");
                i++;
            }
        }

        private static void PrintStartMessage(object sender, PrinterEventArgs e)
        {
            Console.WriteLine($"Printer {e.Name} {e.Model} started to print.");
        }

        private static void PrintEndMessage(object sender, PrinterEventArgs e)
        {
            Console.WriteLine($"Printer {e.Name} {e.Model} finished printing.");
        }
    }
}