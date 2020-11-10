using System;
using System.Collections;
using System.Diagnostics;

namespace CompositeExample
{
    class MainApp
    {
        static void Main()
        {
            Developer senior = new RootDeveloper("Senior");
            Developer middle = new RootDeveloper("Middle");
            middle.Add(new LeafDeveloper("Junior A"));
            middle.Add(new LeafDeveloper("Junior B"));
            senior.Add(middle);

            senior.Display(1);

            Developer ceo = new RootDeveloper("CEO");
            Developer seniorA = new RootDeveloper("SeniorA");
            Developer seniorB = new RootDeveloper("SeniorB");
            Developer middleA = new RootDeveloper("MiddleA");
            Developer middleB = new RootDeveloper("MiddleB");

            ceo.Add(seniorA);
            ceo.Add(seniorB);

            seniorA.Add(middleA);
            seniorB.Add(middleB);

            middleA.Add(new LeafDeveloper("JuniorA1"));
            middleA.Add(new LeafDeveloper("JuniorA2"));
            middleA.Add(new LeafDeveloper("JuniorA3"));

            middleB.Add(new LeafDeveloper("JuniorB1"));

            ceo.Display(1);
            Console.Read();
        }
    }

    // Component
    abstract class Developer
    {
        protected string name;
        // Constructor
        public Developer(string name)
        {
            this.name = name;
        }

        public abstract void Add(Developer d); 
        public abstract void Remove(Developer d);
        public abstract void Display(int depth);
    }

    // Composite
    class RootDeveloper : Developer
    {   
        private ArrayList children = new ArrayList();
        // Constructor
        public RootDeveloper(string name)
            : base(name)
        {
        }

        public override void Add(Developer developer)
        {
            children.Add(developer);
        }

        public override void Remove(Developer developer)
        {
            children.Remove(developer);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);

            // Recursively display child nodes
            foreach (Developer developer in children)
            {
                developer.Display(depth + 2);
            }
        }
    }

    // LeafDeveloper
    class LeafDeveloper : Developer
    {
        // Constructor
        public LeafDeveloper(string name)
            : base(name)
        {
        }

        public override void Add(Developer d)
        {
            Console.WriteLine("Cannot add to a leaf");
        }

        public override void Remove(Developer d)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }

    }
}
