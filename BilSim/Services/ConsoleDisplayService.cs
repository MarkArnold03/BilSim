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
            Console.WriteLine("Välj ett alternativ:");
            Console.WriteLine("1. Visa bilens status");
            Console.WriteLine("2. Visa förarens status");
            Console.WriteLine("3. Sväng höger");
            Console.WriteLine("4. Sväng vänster");
            Console.WriteLine("5. Kör framåt");
            Console.WriteLine("6. Kör bakåt");
            Console.WriteLine("7. Tanka bilen");
            Console.WriteLine("8. Ta en rast");
            Console.WriteLine("9. Avsluta programmet");
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

            if (driverStatus.Tiredness < 4)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Trötthetsstatus: " + (driverStatus.Tiredness < 4 ? "RÖD" : "GRÖN"));
            Console.ResetColor();
        }

        public void DisplayErrorMessage(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Fel: " + errorMessage);
            Console.ResetColor();
            Console.WriteLine();
        }

        public string GetUserInput()
        {
            Console.Write("Ange ditt val: ");
            return Console.ReadLine();
        }
    }

}
