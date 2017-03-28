using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    class TypeProgram
    {
        static void Main(string[] args)
        {
            var lst = Type.ReadFromFile("Types.txt");
            foreach (var item in lst)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Free space: {0}%", 100-Math.Round(((double)Type.TotalOccupiedMemoryByte / Type.TotalMemoryBytes) * 100));

            var breakpoints =
                from item in lst
                where (item is Breakpoint)
                orderby item ascending
                select item;

            Console.WriteLine();
            Console.WriteLine("All breakpoints:");
            foreach (var item in breakpoints)
            {
                Console.WriteLine(item);
            }
            Type.WriteToFile("breakpoints.txt", breakpoints);
            Console.ReadKey();
        }
    }
}
