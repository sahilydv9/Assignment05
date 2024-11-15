using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment05
{
    internal class Program
    {

    //deligates
    //Question1
    static int calculaeSum(int num1, int num2)
        {
            return num1 + num2;
        }
        //Question2

        abstract class Appliance
        {
            private int power;

            public int Power
            {
                get => power;
                set
                {
                    if (value > 1000)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), "Power cannot exceed 1000 watts.");
                    }
                    power = value;
                }
            }

            public abstract void TurnOn();
        }

        class Fan : Appliance
        {
            public override void TurnOn()
            {
                Console.WriteLine("Fan is now turned on.");
            }
        }

        class AirConditioner : Appliance
        {
            public override void TurnOn()
            {
                Console.WriteLine("Air Conditioner is now turned on.");
            }
        }

        //Question3
        static void DisplayData(string data)
        {
            Console.WriteLine("Displaying data: " + data);
        }

        static void LogData(string data)
        {
            Console.WriteLine("Logging data to file: " + data);
            
        }

        //Que1
        public delegate int sumDelegate(int num1, int num2);
        //Que3
        delegate void ProcessData(string data);

        static void Main(string[] args)
        {
            Console.WriteLine("Question1");
            sumDelegate sum = new sumDelegate(calculaeSum);
            Console.WriteLine(sum(45, 55));


            //Question2
            Console.WriteLine();
            Console.WriteLine("Question2");
            try
            {
                Fan fan = new Fan();
                fan.Power = 1500; // This will throw an exception
                fan.TurnOn();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            } 

            try
            {
                AirConditioner ac = new AirConditioner();
                ac.Power = 800; // This is valid power to operate on 
                ac.TurnOn();
                Console.WriteLine($"Air Conditioner power set to {ac.Power} watts.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            try
            {
                Fan fan = new Fan();
                fan.Power = 500; // This is valid power to operate on
                fan.TurnOn();
                Console.WriteLine($"Fan power set to {fan.Power} watts.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            //Question3
            Console.WriteLine();
            Console.WriteLine("Question3 : ");
            ProcessData processData = DisplayData; // Assign DisplayData initially
            processData += LogData; // Add LogData to the multicast delegate

            processData("Hello, world!");   

            Console.ReadLine();


        }
    }
}
