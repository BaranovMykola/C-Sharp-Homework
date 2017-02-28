using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixAndDecomposition
{
    class A
    {
        public string name { get; set; } = "fff";
    }
    class Program
    {
        static int[] decomposition(int number)
        {
            int[] arr = new int[0];
            int prime = 2;
            do
            {
                if(number%prime != 0)
                {
                    ++prime;
                    continue;
                }
                number /= prime;
                pushBack(ref arr, prime);
            }
            while (number > 1);
            return arr;
        }
        static void pushBack(ref int[] arr, int number)
        {
            Array.Resize<int>(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = number;
        }
        static int[] getNegativeCount(int[,] matrix, int m, int n)
        {
            int[] B = new int[n];
            for(int i=0;i<n;++i)
            {
                B[i] = 0;
                for(int j=0;j<m;++j)
                {
                    if(matrix[i,j] < 0)
                    {
                        ++B[i];
                    }
                }
            }
            return B;
        }
        static void Main(string[] args)
        {
            int[,] matrix = { {1,2,3 },
                                {3,-4,-5 },
                                {-6,7,8 },
                                {7,8,-9 } };
            var B = getNegativeCount(matrix, 3,4);
            int index = 0;
            foreach(var i in B)
            {
                Console.Write("{0}: {1}, ", index++, i);
            }
            Console.ReadKey();
        }
    }
}
