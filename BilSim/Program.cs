using BilSim.Services;

namespace BilSim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarService();
            IDriverService driverService = new DriverService();
            IConsoleDisplayService displayService = new ConsoleDisplayService();

            
            App app = new App(carService, driverService, displayService);
            app.Run();
        }
    }
}