using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution
{
    public class PrinterEventArgs : EventArgs
    {
        private readonly string name;
        private readonly string model;
        
        public string Name { get { return name; } }

        public string Model { get { return model; } }

        public PrinterEventArgs(string name, string model)
        {
            this.name = name;
            this.model = model;
        }
    }
}
