using BilSim.Services;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilSim
{
    public class App
    {
        private ICarService _carService;
        private IDriverService _driverService;
        private IConsoleDisplayService _consoleDisplayService;
        public App(ICarService carService, IDriverService driverService, IConsoleDisplayService consoleDisplayService, IRandomUserService randomUserService)
        {
            _carService = carService;
            _driverService = driverService;
            _consoleDisplayService = consoleDisplayService;
            
        }

        public void Run()
        {
            bool isRunning = true;
            var message = "";
            var driver = _driverService.GetRandomDriver();

            while (isRunning)
            {
                _consoleDisplayService.DisplayMenu();


                string userInput = _consoleDisplayService.GetUserInput();
                var carStatus = _carService.GetCarStatus();
                var driverStatus = _driverService.GetDriverStatus();
               
                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        if (carStatus.FuelLevel != 0 || driverStatus.Tiredness != 10)
                        {
                            _carService.TurnRight();
                            _driverService.IncreaseTiredness();
                        }
                        message = _driverService.GetTirednessMessage();
                        break;
                    case "2":
                        Console.Clear();
                        if (carStatus.FuelLevel != 0 || driverStatus.Tiredness != 10)
                        {
                            _carService.TurnLeft();
                            _driverService.IncreaseTiredness();
                        }
                        message = _driverService.GetTirednessMessage();
                        break;
                    case "3":
                        Console.Clear();
                        if (carStatus.FuelLevel != 0 || driverStatus.Tiredness != 10)
                        {
                            _carService.MoveForward();
                            _driverService.IncreaseTiredness();
                        }
                        message = _driverService.GetTirednessMessage();
                        break;
                    case "4":
                        Console.Clear();
                        if (carStatus.FuelLevel != 0 || driverStatus.Tiredness != 10)
                        {
                            _carService.MoveBackward();
                            _driverService.IncreaseTiredness();
                        }
                        message = _driverService.GetTirednessMessage();
                        break;
                    case "5":
                        Console.Clear();
                        _carService.Refuel();
                        break;
                    case "6":
                        Console.Clear();
                        _driverService.Rest();
                        break;
                    case "7":
                        Console.Clear();
                        isRunning = false;
                        Console.WriteLine("Avslutar programmet...");
                        break;
                    default:
                        Console.Clear();
                        _consoleDisplayService.DisplayErrorMessage("Ogiltigt val. Försök igen.");
                        break;
                }

                Console.WriteLine(message);
                _consoleDisplayService.DisplayCarStatus(carStatus);
                _consoleDisplayService.DisplayDriverStatus(driverStatus,driver);
            }
        }
    }
}
