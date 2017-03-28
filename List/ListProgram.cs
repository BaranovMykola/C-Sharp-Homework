using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class ListProgram
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4 };
            List.List<int> lst = new List.List<int>(arr);
            for (int i = 0; i < 5; i++)
            {
                lst.PushBack(i);
            }
            foreach (int item in lst)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
