using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Examples
{
    class MainApp
    {
        public static void Main()
        {
            DrawerFacade drawer = new DrawerFacade();
            drawer.DrawXMasTree();
            drawer.DrawSnowman();

            drawer.DrawHouse();
            // Wait for user 
            Console.Read();
        }
    }

    // SuBsystem1
    class Circle
    {
        public void Draw()
        {
            Console.WriteLine(" Circle drawn!");
        }
    }

    // SuBsystem2
    class Triangle
    {
        public void Draw()
        {
            Console.WriteLine(" Triangle drawn!");
        }
    }

    // SuBsystem3
    class Rectangle
    {
        public void Draw()
        {
            Console.WriteLine(" Rectangle drawn!");
        }
    }

    // SuBsystem4
    class Square
    {
        public void Draw()
        {
            Console.WriteLine(" Square drawn!");
        }
    }

    // Facade
    class DrawerFacade
    {
        Circle circle;
        Triangle triangle;
        Square square;
        Rectangle rectangle;

        public DrawerFacade()
        {
            circle = new Circle();
            triangle = new Triangle();
            square = new Square();
            rectangle = new Rectangle();
        }

        public void DrawXMasTree()
        {
            Console.WriteLine("\nDrawing X-Mas tree ---- ");
            triangle.Draw();
            triangle.Draw();
            triangle.Draw();
            rectangle.Draw();
        }

        public void DrawSnowman()
        {
            Console.WriteLine("\nDrawing snowman ---- ");
            rectangle.Draw();
            circle.Draw();
            circle.Draw();
            circle.Draw();
        }

        public void DrawHouse()
        {
            Console.WriteLine("\nDrawing house ---- ");
            rectangle.Draw();
            triangle.Draw();
            square.Draw();
        }
    }
}