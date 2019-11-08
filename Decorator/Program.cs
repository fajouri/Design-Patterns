using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace Decorator
{
    class DecoratorPattern
    {

        interface IComponent
        {
            string Operation();
        }

        class Component : IComponent
        {
            public string Operation()
            {
                return "I am walking";
            }
        }

        class DecoratorA : IComponent
        {
            private IComponent component;

            public DecoratorA(IComponent _component)
            {
                component = _component;
            }

            public string Operation()
            {
                var componentOperation = component.Operation();
                componentOperation += " and listening to Classic FM";
                return componentOperation;
            }
        }

        class DecoratorB: IComponent
        {
            private IComponent component;
            public string addedState = " past the Coffe Shop";

            public DecoratorB(IComponent _component)
            {
                component = _component;
            }

            public string Operation()
            {
                return component.Operation() + " to school";
            }

            public string AddedBehavior()
            {
                return " and I bought a cappuccino ";
            }
        }
        static void Display(string s, IComponent c)
        {
            Console.WriteLine(s +  c.Operation());
        }
        
        static void Main(string[] args)
        {
            Console.Write("Decorator Pattern\n");
            IComponent component = new Component();
            Display("1. Basic Component: ", component);
            Display("2. A-decorated: ", new DecoratorA(component));
            Display("3. B-decorated: ", new DecoratorB(component));
            Display("4. B-A-decorated: ", new DecoratorB(new DecoratorA(component)));
            var b = new DecoratorB(new Component());
            Display("5. A-B-decorated: ", new DecoratorA(b));
            Console.WriteLine(("\t\t\t"+b.addedState + b.AddedBehavior()));
            Console.ReadLine();

        }
    }

}
