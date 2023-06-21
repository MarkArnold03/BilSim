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

        public App(ICarService carService, IDriverService driverService, IConsoleDisplayService consoleDisplayService)
        {
            _carService = carService;
            _driverService = driverService;
            _consoleDisplayService = consoleDisplayService;
        }

        public void Run()
        {
            bool isRunning = true;

            while (isRunning)
            {
                _consoleDisplayService.DisplayMenu();

                string userInput = _consoleDisplayService.GetUserInput();

                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        _carService.TurnRight();
                        break;
                    case "2":
                        Console.Clear();
                        _carService.TurnLeft();
                        break;
                    case "3":
                        Console.Clear();
                        _carService.MoveForward();
                        _driverService.IncreaseTiredness();
                        break;
                    case "4":
                        Console.Clear();
                        _carService.MoveBackward();
                        _driverService.IncreaseTiredness();
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
                        _consoleDisplayService.DisplayErrorMessage("Ogiltigt val. Försök igen.");
                        break;
                }

                CarStatus carStatus = _carService.GetCarStatus();
                DriverStatus driverStatus = _driverService.GetDriverStatus();

                _consoleDisplayService.DisplayCarStatus(carStatus);
                _consoleDisplayService.DisplayDriverStatus(driverStatus);
            }
        }
    }
}
