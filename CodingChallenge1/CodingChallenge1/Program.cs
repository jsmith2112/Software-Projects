using System;


namespace AnimalPolymorphism
{
    // Abstract Animal class
    public abstract class Animal
    {
        //Getters and Setters for Name and Age
        public string Name { get; set; }
        public int Age { get; set; }

        // Protected field for energy level initialized to 100
        private int _energy = 100;

        // Method to decrease energy
        protected void DecreaseEnergy(int amount)
        {
            _energy -= amount;
        }

        // Abstract method for making sound
        public abstract void MakeSound();
    }

    // Interfaces for running and swimming
    public interface ICanRun
    {
        void Run();
    }

    public interface ICanSwim
    {
        void Swim();
    }

    // Concrete Classes inheriting from Animal and implementing interfaces
    public class Dog : Animal, ICanRun
    {
        // Override MakeSound method
        public override void MakeSound()
        {
            Console.WriteLine("Woof!");
        }

        // Implement Run method from ICanRun interface
        public void Run()
        {
            // get name from base class
            Console.WriteLine($"{Name} is running!");
        }
    }

    public class Fish : Animal, ICanSwim
    {
        // Override MakeSound method
        public override void MakeSound()
        {
            Console.WriteLine("Blub blub!");
        }

        // Implement Swim method from ICanSwim interface
        public void Swim()
        {
            Console.WriteLine($"{Name} is swimming!");
        }
    }

    public class Duck : Animal, ICanRun, ICanSwim
    {
        // Override MakeSound method
        public override void MakeSound()
        {
            Console.WriteLine("Quack!");
        }

        // Implement Run method from ICanRun interface
        public void Run()
        {
            Console.WriteLine($"{Name} is waddling!");
        }

        // Implement Swim method from ICanSwim interface
        public void Swim()
        {
            Console.WriteLine($"{Name} is paddling in water!");
        }
    }

    // Create a Zoo class to manage animals
    public class Zoo
    {
        // Array to hold animals and a count of current animals
        private Animal[] animals = new Animal[10];
        private int count = 0;

        // Method to add an animal to the zoo
        public void AddAnimal(Animal animal)
        {
            // Add animal to array at index count, then increment count
            if (count < animals.Length)
            {
                animals[count] = animal;
                count++;
            }
            else
            {
                Console.WriteLine("Zoo is full!");
            }
        }

        // Method to make all animals make sound
        public void MakeAllAnimalsSound()
        {
            // Loop through array and call MakeSound()
            for (int i = 0; i < count; i++)
            {
                animals[i].MakeSound();
            }
        }

        // Method to show running animals
        public void ShowRunningAnimals()
        {
            // Loop through array and call Run() if animal is ICanRun
            for (int i = 0; i < count; i++)
            {
                if (animals[i] is ICanRun runner)
                {
                    runner.Run();
                }
            }
        }

        // Method to show swimming animals
        public void ShowSwimmingAnimals()
        {
            // Loop through array and call Swim() if animal is ICanSwim
            for (int i = 0; i < count; i++)
            {
                if (animals[i] is ICanSwim swimmer)
                {
                    swimmer.Swim();
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // Create instances of Dog, Fish, and Duck
            Dog dog = new Dog { Name = "Buddy", Age = 3 };
            Fish fish = new Fish { Name = "Goldie", Age = 1 };
            Duck duck = new Duck { Name = "Daffy", Age = 2 };

            // Create a Zoo and add animals to it
            Zoo zoo = new Zoo();
            zoo.AddAnimal(dog);
            zoo.AddAnimal(fish);
            zoo.AddAnimal(duck);

            // Make all animals sound, show running and swimming animals
            zoo.MakeAllAnimalsSound();
            zoo.ShowRunningAnimals();
            zoo.ShowSwimmingAnimals();
        }
    }
}

