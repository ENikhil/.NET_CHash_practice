using System;
using System.Runtime.CompilerServices;

namespace ConsoleApp1
{
    class Program
    {
        private static void Main(string[] args)
        {
            /*
            NumberGame();

            int[] num = { 1, 2, 3 };
            foreach (int i in num)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(NumberReturn(num));

            int[,] num =
            {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 },
            { 10, 11, 12 }
        };

            Console.WriteLine(num.Length); // Shows 12
            Console.WriteLine(num.GetLength(0)); // Shows 4
            Console.WriteLine(num.GetLength(1)); // Shows 3

            Extra ex = new Extra();

            ex.Hello();

            ex.Bye();

            Human h1 = new Human("Nikhil", 23), h2 = new Human("Hemanth", 25);
            h1.Intro();
            h2.Intro();
            
            Console.WriteLine(Human.species);

            Human[] h = new Human[2];
            h[0] = h1;
            h[1] = h2;

            Console.WriteLine(h[0].name);

            Human[] h_array = { new Human("Nikhil", 23), new Human("Hemanth", 25) };

            Console.WriteLine(h1.ToString());

            */


            List<String> food = new List<String>();
            food.Add("Apple");

            List<Human> human = new List<Human>();
            human.Add(new Human("Nikhil", 23));
            human.Insert(0, new Human("1Nikhil", 22));

            Console.WriteLine(food.IndexOf("Apple"));
            Console.WriteLine(food.Contains("Apple"));
        }

        private static void NumberGame()
        {
            Random random = new Random();
            Console.WriteLine("Welcome to the number guessing game!\n");
            int min, max, current_guess, total_guesses, max_guesses, current_gen;
            Boolean keep_playing = true;
            
            while (keep_playing)
            {
                Console.WriteLine("What do you want the minimum value for the game to be?");
                min = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("What do you want the maximum value for the game to be?");
                max = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("What do you want the maximum number of guesses for the game to be?");
                max_guesses = Convert.ToInt32(Console.ReadLine());

                current_guess = -1;
                total_guesses = 0;
                current_gen = random.Next(min, max + 1);
                
                Console.WriteLine("Guess a number between " + min + " - " + max + " : ");
                
                while (current_guess != current_gen && total_guesses<max_guesses)
                {
                    if (total_guesses!=0)
                    {
                        Console.Write("Guess again:\n");
                    }

                    current_guess = Convert.ToInt32(Console.ReadLine());

                    total_guesses+=1;

                    if (current_guess > current_gen)
                    {
                        Console.WriteLine("The current guess " + current_guess + ", is higher than the generated number.");
                    }
                    else if (current_guess < current_gen)
                    {
                        Console.WriteLine("The current guess " + current_guess + ", is lower than the generated number.");
                    }
                    else
                    {
                        Console.WriteLine("The current guess " + current_guess + ", is correct! You Won!");
                        break;
                    }
                }
                
                if (current_guess != current_gen)
                {
                    Console.WriteLine("You took too many guesses :(");
                }

                Console.WriteLine("Would you like to play again? (y/n)");

                char play_again = Convert.ToChar(Console.ReadLine());

                keep_playing = (play_again == 'y') ? true : false;

            }

            Console.WriteLine("Game Over!");
        }

        private static int NumberReturn(int[] numbers)
        {
            int curr = 0;
            foreach (int i in numbers)
            {
                curr += i;
            }
            return curr;
        }
    }

    class Human
    {
        public String name;
        public int age;

        public String Name // Custom implemented getter and setter
        {
            get
            {
                return name;
            }
            
            set
            {
                name = value;
            }
        }

        // public String Name { get; set; } Auto implemented getter and setter

        public static String species = "Homo sapien"; //A static member belongs to the class definition itself and no single class instance has ownership of it

        public Human(String name) // Constructor overloading is made possible with the use of multiple constructor functions with differing number of parameters
        {
            this.name = name;
        }

        public Human(String name, int age) // Constructor has the same name as the class name
        {
            this.name = name;
            this.age = age;
        }


        public void Intro()
        {
            Console.WriteLine("Hello, my name is " + name);
        }
    }

    abstract class Vehicle // Adding an abstract before a class definition makes it so that an instance of the class can't be created
    {
        public int speed = 0;
    }

    class Car : Vehicle
    {
        public int wheels = 4;

        public override string ToString()
        {
            return base.ToString() + "This be car";
        }

        public virtual void Intro ()
        {
            Console.WriteLine("Hello me be car");
        }
    }

    class Ford : Car
    {
        public override void Intro ()
        {
            Console.WriteLine("Hello me be ford");
        }
    }

    interface Woah // Made for classes that may want to inherit its properties
    {
        void Func();
    }
}
