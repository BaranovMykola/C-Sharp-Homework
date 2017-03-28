using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    abstract class Type : IComparable<Type>
    {
        private string name;
        protected static uint totalOccupiedMemoryByte;
        const uint totalMemoryBytes = 8*500;

        public Type(string name)
        {
            Name = name;
        }
        static Type()
        {
            totalOccupiedMemoryByte = 0;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public static uint TotalMemoryBytes
        {
            get
            {
                return totalMemoryBytes;
            }
        }

        public static uint TotalOccupiedMemoryByte
        {
            get
            {
                return totalOccupiedMemoryByte;
            }
            protected set
            {
                if(value > totalMemoryBytes)
                {
                    throw new OutOfMemoryException();
                }
                totalOccupiedMemoryByte = value;
            }
        }

        public override string ToString()
        {
            return Name;
        }

        virtual public uint FreeSpace()
        {
            return TotalMemoryBytes - TotalOccupiedMemoryByte;
        }

        public int CompareTo(Type other)
        {
            return Name.CompareTo(other.Name);
        }

        public static IEnumerable<Type> ReadFromFile(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            foreach (var item in lines)
            {
                var fields = item.Split(' ');
                if(fields[0] == "Breakpoint")
                {
                    var content = item.Replace("Breakpoint ", "");
                    yield return Breakpoint.Parse(content);
                }
                if (fields[0] == "Variable")
                {
                    var content = item.Replace("Variable ", "");
                    yield return Variable.Parse(content);
                }
            }
        }

        public static void WriteToFile(string fileName, IEnumerable<Type> data)
        {
            File.WriteAllText(fileName, string.Empty);
            using (StreamWriter file = new StreamWriter(fileName, true))
            {
                foreach (var item in data)
                {
                    file.Write(item + "\n");
                }
            }
        }
    };
}
