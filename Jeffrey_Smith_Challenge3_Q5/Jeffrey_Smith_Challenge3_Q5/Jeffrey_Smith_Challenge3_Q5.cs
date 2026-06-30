using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeffrey_Smith_Challenge3_Q5
{
    public class WeatherStation
    {
        // TODO: declare public event Action<int> TemperatureChanged;
        public event Action<int> TemperatureChanged;

        public void UpdateTemperature(int newTemp)
        {
            Console.WriteLine($"Updating temperature to {newTemp}°C");
            // TODO: trigger the TemperatureChanged event (call the event safely)
            if (TemperatureChanged != null)
            {
                TemperatureChanged(newTemp);
            }
        }
    }

    public class User
    {
        public void OnTemperatureChanged(int temp)
        {
            Console.WriteLine($"User: New temperature is {temp}°C");
        }
    }

    public class Admin
    {
        public void OnTemperatureChanged(int temp)
        {
            Console.WriteLine($"Admin: Temperature updated to {temp} degrees.");
        }
    }

    class Jeffrey_Smith_Challenge3_Q5
    {
        static void Main(string[] args)
        {
            // TODO: create WeatherStation, User, Admin; subscribe handlers and call UpdateTemperature
            // Example:
            var ws = new WeatherStation();
            var u = new User();
            var a = new Admin();
            ws.TemperatureChanged += u.OnTemperatureChanged;
            ws.TemperatureChanged += a.OnTemperatureChanged;
            ws.UpdateTemperature(25);
        }
    }

}
