using BilSim.Services;

namespace BilSim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDriverService driverService = new DriverService();
            ICarService carService = new CarService(driverService);
            IConsoleDisplayService displayService = new ConsoleDisplayService();

            
            App app = new App(carService, driverService, displayService);
            app.Run();
        }
    }
}