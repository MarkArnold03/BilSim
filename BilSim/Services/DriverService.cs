using ClassLibrary.Models;
using Newtonsoft.Json;
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
        private IRandomUserService randomUserService;
        private CarStatus carStatus;
        public DriverService(IRandomUserService randomUserService)
        {
            driverStatus = new DriverStatus
            {
                Tiredness = 0
            };
            this.randomUserService = randomUserService;
        }

        public DriverStatus GetDriverStatus()
        {
            return driverStatus;
        }
        public Driver GetRandomDriver()
        {
            RandomUserApiResponse randomUserResponse = randomUserService.GetRandomUser();
            if (randomUserResponse != null && randomUserResponse.Results.Length > 0)
            {
                Driver driver = new Driver
                {
                    Name = $"{randomUserResponse.Results[0].Name.First} {randomUserResponse.Results[0].Name.Last}",
                    Age = randomUserResponse.Results[0].Dob.Age
                };
                return driver;
            }
            return null;
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

        public string GetFeulMessage()
        {
            if (carStatus.FuelLevel > 30)
            {
                return "Bilen har tillräckligt besin";
            }
            else if (carStatus.FuelLevel <= 30 && carStatus.FuelLevel <= 60)
            {
                return "Bilen Bor tankas snart";
            }
            else
            {
                return "Det är tomt på bensin";
            }
        }

    }

}
