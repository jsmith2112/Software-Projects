using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeffrey_Smith_Challenge3_Q1
{
    // Abstract Class
    public abstract class Vehicle
    {
        public string Name { get; set; }

        public Vehicle(string name)
        {
            Name = name;
        }

        // Method to display vehicle name
        public void DisplayVehicleInfo()
        {
            Console.WriteLine($"Vehicle: {Name}");
        }
    }

    // IStartable Interface
    public interface IStartable
    {
        void Start();
        bool IsRunning { get; set; }
    }

    // IStoppable Interface
    public interface IStoppable
    {
        void Stop();
        bool IsStopped { get; set; }
    }

    // Car Class - Inherits from Vehicle and implements IStartable and IStoppable
    public class Car : Vehicle, IStartable, IStoppable
    {

        // implement IsRunning and IsStopped properties
        // Use Start() to set IsRunning = true, IsStopped = false and print a message: $"{Name} has started."
        // - implement Stop() to set IsRunning = false, IsStopped = true and print a message like: $"{Name} has stopped."

        public Car(string name) : base(name) { }

        public bool IsRunning { get; set; } // TODO: adjust initialization if needed
        public bool IsStopped { get; set; } // TODO: adjust initialization if needed

        public void Start()
        {
            // TODO: set IsRunning = true, IsStopped = false
            // TODO: print a message showing the vehicle has started, e.g. Console.WriteLine($"{Name} has started.");
            
            IsRunning = true;
            IsStopped = false;
            Console.WriteLine($"{Name} has started.");
            
        }

        public void Stop()
        {
            // TODO: set IsRunning = false, IsStopped = true
            // TODO: print a message showing the vehicle has stopped, e.g. Console.WriteLine($"{Name} has stopped.");
            
            IsRunning = false;
            IsStopped = true;
            Console.WriteLine($"{Name} has stopped.");
            
        }
    }

    // Motorcycle Class - Inherits from Vehicle and implements IStartable and IStoppable
    public class Motorcycle : Vehicle, IStartable, IStoppable
    {
        // complete this part similar to Car

        public Motorcycle(string name) : base(name) { }

        public bool IsRunning { get; set; } // TODO: implement
        public bool IsStopped { get; set; } // TODO: implement

        public void Start()
        {
            // TODO: implement start behavior and print a message
            IsRunning = true;
            IsStopped = false;
            Console.WriteLine($"{Name} has started.");
            
        }

        public void Stop()
        {
            // TODO: implement stop behavior and print a message
            IsRunning = false;
            IsStopped = true;
            Console.WriteLine($"{Name} has stopped.");
            
        }
    }

    // Main Program
    class Jeffrey_Smith_Challenge3_Q1
    {
        static void Main(string[] args)
        {
            // TODO: Create instances of Car and Motorcycle and test their Start/Stop behavior.
            // Example:
            // var car = new Car(\"Toyota Corolla\");
            // car.DisplayVehicleInfo();
            // car.Start();
            // car.Stop();
            //
            var car = new Car("Toyota Corolla");
            car.DisplayVehicleInfo();
            car.Start();
            car.Stop();

            Console.WriteLine();
            // var bike = new Motorcycle(\"Yamaha MT-07\");
            // bike.DisplayVehicleInfo();
            // bike.Start();
            // bike.Stop();

            var bike = new Motorcycle("Yamaha MT-07");
            bike.DisplayVehicleInfo();
            bike.Start();
            bike.Stop();
        }
    }
}

