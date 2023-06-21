using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilSim.Services
{
    public class DriverService : IDriverService
    {
        private DriverStatus driverStatus;

        public DriverService()
        {
            driverStatus = new DriverStatus
            {
                Tiredness = 0
            };
        }

        public DriverStatus GetDriverStatus()
        {
            return driverStatus;
        }

        public void IncreaseTiredness()
        {
            if (driverStatus.Tiredness < 10)
            {
                driverStatus.Tiredness++;
            }
            Console.WriteLine("Förarens trötthetsnivå har ökat.");
            Console.WriteLine();
        }

        public void Rest()
        {
            driverStatus.Tiredness = 0;
            Console.WriteLine("Föraren har tagit en rast och är nu utvilad.");
            Console.WriteLine();
        }

        public string GetTirednessMessage()
        {
            if (driverStatus.Tiredness < 3)
            {
                return "Föraren är pigg och alert.";
            }
            else if (driverStatus.Tiredness >= 3 && driverStatus.Tiredness <= 6)
            {
                return "Föraren bör ta en paus snart.";
            }
            else
            {
                return "Föraren är mycket trött. Ta en rast så snart som möjligt!";
            }
        }
    }

}
