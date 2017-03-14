using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle
{
    class CircleProgramm
    {
        static void Main(string[] args)
        {
            Circle a = new Circle(new Point(3, 4), 5);
            Circle b = new Circle(new Point(0, 7), 6);
            Circle c = new Circle(new Point(3, 2), 8);
            ColorCircle d = new ColorCircle(new Point(8, 9), 10, Color.Blue);

            Circle[] arr = { a, b, c, d as Circle };
            CircleListener<Circle> listenerA = new CircleListener<Circle>(d);
            arr[3].Radius = 10;
            Array.Sort(arr);

            Console.WriteLine("Custom square of {0}: {1} and real square is {2}", arr[0], arr[0].Calculations(delegate (double R) { return Math.PI * R * R; }), arr[0].Square());

            foreach(var i in arr)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}

