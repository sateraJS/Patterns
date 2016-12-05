using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8
{
    public abstract class Figures
    {
        public abstract string Name { get; }

        public abstract void Accept(IVisitor visitor);
    }

    public class Rectangle : Figures
    {
        public override string Name => "Прямоугольник";
        public Point A { get; set; } 
        public Point B { get; set; }
        public Point C { get; set; }
        public Point D { get; set; }
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public class Triangle : Figures
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        public override string Name => "Треугольник";
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public class Trapeze : Figures
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        public Point D { get; set; }
        public double H { get; set; }
        public override string Name => "Трапеция";
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}
