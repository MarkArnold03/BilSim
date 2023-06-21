using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilSim.Services
{
    public interface IConsoleDisplayService
    {
        void DisplayMenu();
        void DisplayCarStatus(CarStatus carStatus);
        void DisplayDriverStatus(DriverStatus driverStatus);
        void DisplayErrorMessage(string errorMessage);
        string GetUserInput();
    }
}
