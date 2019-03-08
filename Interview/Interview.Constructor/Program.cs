using System;

namespace Interview.Constructor
{
    public class Program
    {
        // What is the output of the short program below? Explain your answer.
        static void Main(string[] args)
        {
            Console.WriteLine((new Capybara()).GetType());
            Console.WriteLine((new Cat()).GetType());
        }
    }

    public abstract class Animal
    {
        public Animal()
        {
            Console.WriteLine($"Hello, world, from a new instance of {nameof(Animal)}");
        }

        static Animal()
        {
            Console.WriteLine($"Hello, world, from the type {nameof(Animal)}");
        }
    }

    public sealed class Capybara: Animal
    {
        public Capybara()
        {
            Console.WriteLine($"Hello, world, from a new instance of {nameof(Capybara)}");
        }

        static Capybara()
        {
            Console.WriteLine($"Hello, world, from the type {nameof(Capybara)}");
        }
    }

    public sealed class Cat: Animal
    {
        public Cat()
        {
            Console.WriteLine($"Hello, world, from a new instance of {nameof(Cat)}");
        }

        static Cat()
        {
            Console.WriteLine($"Hello, world, from the type {nameof(Cat)}");
        }
    }
}
