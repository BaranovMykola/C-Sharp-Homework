using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    class Breakpoint : Type
    {
        uint line;
        bool hitted;

        public Breakpoint(string name, uint line = 0, bool hitted = false) : base(name)
        {
            Line = line;
            Hitted = hitted;
            totalOccupiedMemoryByte += (uint)name.Length + 5;
        }

        public uint Line
        {
            get
            {
                return line;
            }

            set
            {
                line = value;
            }
        }

        public bool Hitted
        {
            get
            {
                return hitted;
            }
            private set
            {
                hitted = value;
            }
        }

        public void Hit()
        {
            Hitted = true;
        }

        public override string ToString()
        {
            return string.Format("Breakpoint {0} was{1} hitted at line {2}", base.ToString(), (Hitted) ? "" : "n't", Line);
        }

        public static Breakpoint Parse(string str)
        {
            var fields = str.Split(' ');
            if (fields.Length != 3)
            {
                throw new FormatException("Unknown format of input stirng");
            }
            return MakeBreakpointFromStringArray(fields);
        }

        private static Breakpoint MakeBreakpointFromStringArray(string[] fields)
        {
            return new Breakpoint(fields[0], uint.Parse(fields[1]), bool.Parse(fields[2]));
        }
    }
}
