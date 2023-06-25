using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilSim.Services
{
    public class CarService : ICarService
    {
        private CarStatus carStatus;
        private IDriverService driverService;
        private DriverStatus driverStatus;

        public CarService(IDriverService driverService)
        {
            carStatus = new CarStatus
            {
                Direction = Direction.North,
                FuelLevel = 10
            };

            driverStatus = new DriverStatus
            {
                Tiredness=0
            };
            this.driverService = driverService;
        }
        

        public CarStatus GetCarStatus()
        {
            return carStatus;
        }
        public DriverStatus GetDriverStatus()
        {
            return driverStatus;
        }

        public void MoveForward()
        {
            if (carStatus.FuelLevel >= 1)
            {
                carStatus.FuelLevel--;
                switch (carStatus.Direction)
                {
                    case Direction.North:
                        Console.WriteLine("Bilen kör framåt norrut.");
                        break;
                    case Direction.South:
                        Console.WriteLine("Bilen kör framåt söderut.");
                        break;
                    case Direction.East:
                        Console.WriteLine("Bilen kör framåt österut.");
                        break;
                    case Direction.West:
                        Console.WriteLine("Bilen kör framåt västerut.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Det är tomt på bensin. Du kan inte köra framåt.");
            } 
            Console.WriteLine();
        }

        public void MoveBackward()
        {
            if (carStatus.FuelLevel >= 1)
            {
                carStatus.FuelLevel--;
                switch (carStatus.Direction)
                {
                    case Direction.North:
                        Console.WriteLine("Bilen kör bakåt söderut.");
                        carStatus.Direction = Direction.South;
                        break;
                    case Direction.South:
                        Console.WriteLine("Bilen kör bakåt norrut.");
                        carStatus.Direction = Direction.North;
                        break;
                    case Direction.East:
                        Console.WriteLine("Bilen kör bakåt västerut.");
                        carStatus.Direction = Direction.West;
                        break;
                    case Direction.West:
                        Console.WriteLine("Bilen kör bakåt österut.");
                        carStatus.Direction = Direction.East;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Det är tomt på bensin. Du kan inte köra bakåt.");
            }
            Console.WriteLine();
        }

        public void TurnRight()
        {
            if (carStatus.FuelLevel >= 1)
            {
                carStatus.FuelLevel--;
                switch (carStatus.Direction)
                {
                    case Direction.North:
                        Console.WriteLine("Bilen svänger höger och fortsätter österut.");
                        carStatus.Direction = Direction.East;
                        break;
                    case Direction.South:
                        Console.WriteLine("Bilen svänger höger och fortsätter västerut.");
                        carStatus.Direction = Direction.West;
                        break;
                    case Direction.East:
                        Console.WriteLine("Bilen svänger höger och fortsätter söderut.");
                        carStatus.Direction = Direction.South;
                        break;
                    case Direction.West:
                        Console.WriteLine("Bilen svänger höger och fortsätter norrut.");
                        carStatus.Direction = Direction.North;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Det är tomt på bensin. Du kan inte svänga höger.");
            }
            Console.WriteLine();
        }

        public void TurnLeft()
        {
            if (carStatus.FuelLevel >= 1)
            {
                carStatus.FuelLevel--;
                switch (carStatus.Direction)
                {
                    case Direction.North:
                        Console.WriteLine("Bilen svänger vänster och fortsätter västerut.");
                        carStatus.Direction = Direction.West;
                        break;
                    case Direction.South:
                        Console.WriteLine("Bilen svänger vänster och fortsätter österut.");
                        carStatus.Direction = Direction.East;
                        break;
                    case Direction.East:
                        Console.WriteLine("Bilen svänger vänster och fortsätter norrut.");
                        carStatus.Direction = Direction.North;
                        break;
                    case Direction.West:
                        Console.WriteLine("Bilen svänger vänster och fortsätter söderut.");
                        carStatus.Direction = Direction.South;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Det är tomt på bensin. Du kan inte svänga vänster.");
            }
            Console.WriteLine();
        }

        public void Refuel()
        {
            carStatus.FuelLevel = 10;
            Console.WriteLine("Bilen har tankats och bensinnivån är nu full.");
            Console.WriteLine();
        }
    }


}
