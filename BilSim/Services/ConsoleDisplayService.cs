using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilSim.Services
{
    public class ConsoleDisplayService : IConsoleDisplayService
    {
        public void DisplayMenu()
        {
            Console.WriteLine("Välj ett kommando:");
            Console.WriteLine("1. Sväng höger");
            Console.WriteLine("2. Sväng vänster");
            Console.WriteLine("3. Kör framåt");
            Console.WriteLine("4. Kör bakåt");
            Console.WriteLine("5. Tanka bilen");
            Console.WriteLine("6. Ta en rast");
            Console.WriteLine("7. Avsluta programmet");
        }

        public void DisplayCarStatus(CarStatus carStatus)
        {
            Console.WriteLine("Bilens status:");
            Console.WriteLine("Riktning: " + carStatus.Direction);
            Console.WriteLine("Bensinnivå: " + carStatus.FuelLevel + "%");

            if (carStatus.FuelLevel < 30)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Bensinstatus: " + (carStatus.FuelLevel < 30 ? "RÖD" : "GRÖN"));
            Console.ResetColor();
        }

        public void DisplayDriverStatus(DriverStatus driverStatus)
        {
            Console.WriteLine("Förarens status:");
            Console.WriteLine("Trötthet: " + driverStatus.Tiredness);

            if (driverStatus.Tiredness >= 8)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Trötthetsstatus: " + (driverStatus.Tiredness >= 8 ? "RÖD" : "GRÖN"));
            Console.ResetColor();
        }

        public void DisplayErrorMessage(string errorMessage)
        {
            Console.WriteLine("Fel: " + errorMessage);
        }

        public string GetUserInput()
        {
            Console.Write("Ange ditt val: ");
            return Console.ReadLine();
        }
    }


}
