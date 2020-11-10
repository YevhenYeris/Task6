using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace NovorichnaYolka
{
    class Program
    {
        static void Main(string[] args)
        {
            Yalinka yalinka = new ConcreteYalika();
            ToysDecorator decoratorToys = new ToysDecorator();
            GarlandDecorator decoratorGarland = new GarlandDecorator();

            yalinka.LightTheYalinka();
            Console.WriteLine();

            decoratorToys.SetYalinka(yalinka);
            decoratorToys.LightTheYalinka();
            Console.WriteLine();

            decoratorGarland.SetYalinka(yalinka);
            decoratorGarland.LightTheYalinka();
            Console.WriteLine();

            decoratorGarland.SetYalinka(decoratorToys);
            decoratorGarland.LightTheYalinka();
        }
    }

    abstract class Yalinka
    {
        public abstract void LightTheYalinka();

        protected void makeToyMessage(string toy)
        {
            Console.WriteLine("На ялинцi " + toy + "!");
        }
    }

    class ConcreteYalika : Yalinka
    {
        string toy = "куля";

        public override void LightTheYalinka()
        {
            Console.WriteLine("На ялинцi " + toy + "!");
            LightGarland1();
        }

        private void LightGarland1()
        {
            Console.WriteLine("Гiрлянда горить!");
        }
    }

    abstract class Decorator : Yalinka
    {
        Yalinka yalinka;

        public void SetYalinka(Yalinka yalinka)
        {
            this.yalinka = yalinka;   
        }

        public override void LightTheYalinka()
        {
            if (this.yalinka != null)
            {
                this.yalinka.LightTheYalinka();
            }
        }
    }

    class ToysDecorator : Decorator
    {
        string toy1 = "червона кулька";
        string toy2 = "синя кулька";
        string toy3 = "зелена кулька";

        public override void LightTheYalinka()
        {
            base.LightTheYalinka();
            makeToyMessage(toy1);
            makeToyMessage(toy2);
            makeToyMessage(toy3);
        }

    }

    class GarlandDecorator : Decorator
    {
        public override void LightTheYalinka()
        {
            base.LightTheYalinka();
            LightGarlandGreen();
            LightGarlandPurple();
            LightGarlandYellow();
        }

        private void LightGarlandGreen()
        {
            Console.WriteLine("Зелена гiрлянда горить!");
        }
        private void LightGarlandYellow()
        {
            Console.WriteLine("Жовта гiрлянда горить!");
        }
        private void LightGarlandPurple()
        {
            Console.WriteLine("Фiолетова гiрлянда горить!");
        }
    }


}
