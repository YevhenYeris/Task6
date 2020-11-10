using System;
namespace FactoryMethodExample
{
    //Creator
    public abstract class TriangleCreator
    {
        public abstract Triangle CreateTriangle(int a, int b, int c);
    }

    //ConcreteCreator
    public class ConcreteTriangleCreator : TriangleCreator
    {
        public override Triangle CreateTriangle(int a, int b, int c)
        {
            int type = 0;

            if (a == b || b == c || a == c)
                type = 1;

            if (a == b && b == c)
                type = 2;

            if (a * a + b * b == c * c || a * a + c * c == b * b || c * c + b * b == a * a)
                type = 3;

            if (a + b < c || a + c < b || b + c < a)
                type = 4;

            switch (type)
            {
                case 1: return new IsoscelesTriangle();
                case 2: return new EquilateralTriangle();
                case 3: return new RightTriangle();
                case 4: throw new ArgumentException("Трикутник не існує");

                default: return new Triangle();
            }
        }
    }

    //Product
    public class Triangle
    {
        protected string formula = "p * sqrt(p * (p - a) * (p - b) * (p - c))";
        public void Area()
        {
            Console.WriteLine("Площа трикутника дорiвнює " + formula);
        }
    } 

    //ConcreteProductA
    public class EquilateralTriangle : Triangle
    {
        public EquilateralTriangle()
        {
            formula = "pow(a, 2) * sqrt(3) / 4";
        }
    }

    //ConcreteProductB
    public class IsoscelesTriangle : Triangle
    {
        public IsoscelesTriangle()
        {
            formula = "b * sqrt(4 * pow(a, 2) - pow(b, 2)) / 4";
        }
    }

    //ConcreteProductC
    public class RightTriangle : Triangle
    {
        public RightTriangle()
        {
            formula = "a * b / 2 (where a < c and b < c)";
        }
    }

    class MainApp
    {
        static void Main()
        {
            TriangleCreator creator = new ConcreteTriangleCreator();

            var triangle = creator.CreateTriangle(4, 5, 7);
            triangle.Area();

            triangle = creator.CreateTriangle(1, 1, 1);
            triangle.Area();

            triangle = creator.CreateTriangle(6, 8, 10);
            triangle.Area();

            triangle = creator.CreateTriangle(6, 6, 10);
            triangle.Area();

            Console.ReadKey();
        }
    }
}

