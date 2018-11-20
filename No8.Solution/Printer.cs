using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution
{
    public abstract class Printer: IEquatable<Printer>
    {
        public string Name { get; internal set; }

        public string Model { get; internal set; }

        public event EventHandler<PrinterEventArgs> Operation = delegate { };
        public event EventHandler<PrinterEventArgs> EndOperation = delegate { };

        internal void Print(FileStream fs)
        {
            OnNewOperation(this, new PrinterEventArgs(Name, Model));
            for (int i = 0; i < fs.Length; i++)
            {
                Console.WriteLine(fs.ReadByte());
            }
            OnEndOperation(this, new PrinterEventArgs(Name, Model));
        }

        public bool Equals(Printer other)
        {
            return this.Name == other.Name && this.Model == other.Model;
        }

        protected virtual void OnNewOperation(object sender, PrinterEventArgs e)
        {
            Operation?.Invoke(this, e);
        }

        protected virtual void OnEndOperation(object sender, PrinterEventArgs e)
        {
            EndOperation?.Invoke(this, e);
        }
    }
}
