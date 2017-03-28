using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    class Variable : Type
    {
        string frame;
        string content;
        int hexAddres;
        static Random rnd;

        public Variable(string name, string frame, string content) : base(name)
        {
            Frame = frame;
            Content = content;
            hexAddres = rnd.Next();
            TotalOccupiedMemoryByte += (uint)Frame.Length + (uint)Content.Length + (uint)Name.Length + 4;
        }

        static Variable()
        {
            rnd = new Random(DateTime.Now.Millisecond);
        }

        public string Frame
        {
            get
            {
                return frame;
            }

            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Frame cannot be empty");
                }
                frame = value;
            }
        }

        public string Content
        {
            get
            {
                return content;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Frame cannot be empty");
                }
                content = value;
            }
        }

        public int HexAddres
        {
            get
            {
                return hexAddres;
            }
        }

        public override string ToString()
        {
            return string.Format("Variable {0} in {1} has \"{2}\" at 0x{3}", base.ToString(), Frame, Content, HexAddres.ToString("X").ToLower());
        }

        public static Variable Parse(string str)
        {
            var fields = str.Split(' ');
            if (fields.Length != 3)
            {
                throw new FormatException("Unknown format of input stirng");
            }
            return MakeVariableFromStringArray(fields);
        }

        private static Variable MakeVariableFromStringArray(string[] fields)
        {
            return new Variable(fields[0], fields[1], fields[2]);
        }

    }
}
