using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Circle
{
    struct Point : IEquatable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }
        
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public static double Distance(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }
        public override string ToString()
        {
            return "(" + X + ";" + Y + ")";
        }

        bool IEquatable<Point>.Equals(Point other)
        {
            return Equals(other, this);
        }

        public override bool Equals(object obj)
        {
            if(obj == null || base.GetType() != obj.GetType())
            {
                return false;
            }
            var rightPoint = (Point)obj;
            return X == rightPoint.X && Y == rightPoint.Y;
        }
    }

    class Circle : IComparer, IComparer<Circle>, IComparable
    {
        Point Center { get; set; }
        double radius;
        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", value, "Incorrect radius");
                }
                double oldRadius = Radius;
                radius = value;
                Change?.Invoke(this, oldRadius, Radius);
            }
        }

        public delegate double Calculation(double radius);
        public delegate void ChangedRadius(Circle sender, double Before, double After);
        public event ChangedRadius Change;

        public Circle(Point _center, double _radius)
        {
            Center = _center;
            radius = _radius;
        }
        public double Square()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
        public override string ToString()
        {
            return base.ToString() + " Center: " + Center.ToString() + " Radius: " + Radius.ToString();
        }
        int IComparer.Compare(object x, object y)
        {
            if (x.GetType() != y.GetType())
            {
                throw new ArgumentException("Unable to compare different types");
            }
            var xCircle = (Circle)x;
            var yCircle = (Circle)y;
            return xCircle.Radius.CompareTo(yCircle.Radius);
        }
        int IComparer<Circle>.Compare(Circle x, Circle y)
        {
            return ((IComparer)x).Compare(x, y);
        }
        public int CompareTo(object obj)
        {
            return Radius.CompareTo((obj as Circle).Radius);
        }
        public double Calculations(Calculation smth)
        {
            return smth(Radius);
        }
    }


    class CircleListener<T>
        where T : Circle
    {
        T Subscriber;
        
        public CircleListener(T subscriber)
        {
            Subscriber = subscriber;
            Subscriber.Change += CircleChanged;
        }
        void CircleChanged(Circle sender, double before, double after)
        {
            Console.WriteLine("Circle changed: {0} \t from {1} to {2}", sender, before, after);
        }
        void Detach()
        {
            Subscriber.Change -= CircleChanged;
        }
    }

    public enum Color { Red,Green, Blue }

    class ColorCircle : Circle
    {
        Color ColorType { get; set; }

        public ColorCircle(Point _center, double _radius, Color color) : base(_center, _radius)
        {
            ColorType = color;
        }
        public override string ToString()
        {
            return base.ToString() + " Color: " + ColorType.ToString();
        }
    }
}