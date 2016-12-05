using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8
{
    class Program
    {
        static void Main(string[] args)
        {
            Figures[] figures = {
                new Rectangle()   { A = new Point() {X = 0, Y = 0 },
                                    B = new Point() {X = 2, Y = 0 },
                                    C = new Point() {X = 2, Y = -1 },
                                    D = new Point() {X = 0, Y = -1 },},
                new Triangle()    { A = new Point() {X = 0, Y = 0 },
                                    B = new Point() {X = 2, Y = 0 },
                                    C = new Point() {X = 1, Y = 1 }},
                new Trapeze()     { A = new Point() {X = 0, Y = 0 },
                                    B = new Point() {X = 9, Y = 0 },
                                    C = new Point() {X = 6, Y = 4 },
                                    D = new Point() {X = 2, Y = 4 },
                                    H = 4} };

            var drawVisitor = new DrawVisitor(0, 0);
            var getAreaVisitor = new GetAreaVisitor();
            var getPerimetrVisitor = new GetPerimetrVisitor();

            foreach (var figure in figures)
            {
                figure.Accept(drawVisitor);
                figure.Accept(getAreaVisitor);
                figure.Accept(getPerimetrVisitor);
            }
            Console.Read();
        }
    }
}
