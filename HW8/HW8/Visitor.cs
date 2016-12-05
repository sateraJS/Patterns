using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8
{
    public interface IVisitor
    {
        string OperationName { get; }
        void Visit(Rectangle figure);
        void Visit(Triangle figure);
        void Visit(Trapeze figure);
    }
    public class DrawVisitor : IVisitor
    {
        public string OperationName => "Draw";
        public int x;
        public int y;

        public DrawVisitor(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Visit(Rectangle figure)
        {
            Console.WriteLine(string.Format("Прямоугольник по координатам x={0} y={1}", x, y));
        }

        public void Visit(Triangle figure)
        {
            Console.WriteLine(string.Format("Треугольник по координатам x={0} y={1}", x, y));
        }
        public void Visit(Trapeze figure)
        {
            Console.WriteLine(string.Format("Трапеция по координатам x={0} y={1}", x, y));
        }
    }
    public class GetAreaVisitor : IVisitor
    {
        public string OperationName => "GetArea";

        public void Visit(Rectangle figure)
        {
            var side1 = Math.Sqrt(Math.Pow(figure.A.X - figure.B.X, 2) + Math.Pow(figure.A.Y - figure.B.Y, 2));
            var side2 = Math.Sqrt(Math.Pow(figure.A.X - figure.D.X, 2) + Math.Pow(figure.A.Y - figure.D.Y, 2));
            Console.WriteLine(string.Format("Площадь = {0}",side1 * side2));
        }

        public void Visit(Triangle figure)
        {
            var a = Math.Sqrt(Math.Pow(figure.A.X - figure.B.X, 2) + Math.Pow(figure.A.Y - figure.B.Y, 2));
            var b = Math.Sqrt(Math.Pow(figure.C.X - figure.B.X, 2) + Math.Pow(figure.C.Y - figure.B.Y, 2));
            var c = Math.Sqrt(Math.Pow(figure.A.X - figure.C.X, 2) + Math.Pow(figure.A.Y - figure.C.Y, 2));
            var p = (a + b + c) / 2;
            var s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            Console.WriteLine(string.Format("Площадь = {0}", s));
        }
        public void Visit(Trapeze figure)
        {
            var a = Math.Sqrt(Math.Pow(figure.A.X - figure.B.X, 2) + Math.Pow(figure.A.Y - figure.B.Y, 2));//основание 1
            var b = Math.Sqrt(Math.Pow(figure.C.X - figure.B.X, 2) + Math.Pow(figure.C.Y - figure.B.Y, 2));
            var c = Math.Sqrt(Math.Pow(figure.D.X - figure.C.X, 2) + Math.Pow(figure.D.Y - figure.C.Y, 2));//основание 2
            var d = Math.Sqrt(Math.Pow(figure.D.X - figure.A.X, 2) + Math.Pow(figure.D.Y - figure.A.Y, 2));
            var s = (c + a) * figure.H / 2; 
            Console.WriteLine(string.Format("Площадь = {0}", s));
        }
    }
    public class GetPerimetrVisitor : IVisitor
    {
        public string OperationName => "GetPerimetr";

        public void Visit(Rectangle figure)
        {
            var side1 = Math.Sqrt(Math.Pow(figure.A.X - figure.B.X, 2) + Math.Pow(figure.A.Y - figure.B.Y, 2));
            var side2 = Math.Sqrt(Math.Pow(figure.A.X - figure.D.X, 2) + Math.Pow(figure.A.Y - figure.D.Y, 2));
            Console.WriteLine(string.Format("Периметр = {0}", (side1 + side2)*2));
        }

        public void Visit(Triangle figure)
        {
            var a = Math.Sqrt(Math.Pow(figure.A.X - figure.B.X, 2) + Math.Pow(figure.A.Y - figure.B.Y, 2));
            var b = Math.Sqrt(Math.Pow(figure.C.X - figure.B.X, 2) + Math.Pow(figure.C.Y - figure.B.Y, 2));
            var c = Math.Sqrt(Math.Pow(figure.A.X - figure.C.X, 2) + Math.Pow(figure.A.Y - figure.C.Y, 2));
            Console.WriteLine(string.Format("Периметр = {0}", a + b + c));
        }
        public void Visit(Trapeze figure)
        {
            var a = Math.Sqrt(Math.Pow(figure.A.X - figure.B.X, 2) + Math.Pow(figure.A.Y - figure.B.Y, 2));
            var b = Math.Sqrt(Math.Pow(figure.C.X - figure.B.X, 2) + Math.Pow(figure.C.Y - figure.B.Y, 2));
            var c = Math.Sqrt(Math.Pow(figure.D.X - figure.C.X, 2) + Math.Pow(figure.D.Y - figure.C.Y, 2));
            var d = Math.Sqrt(Math.Pow(figure.D.X - figure.A.X, 2) + Math.Pow(figure.D.Y - figure.A.Y, 2));
            Console.WriteLine(string.Format("Периметр = {0}", a +b+c+d));
        }
    }
}
