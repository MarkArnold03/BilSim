using BilSim.Services;

namespace BilSim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRandomUserService randomService = new RandomUserService();
            IDriverService driverService = new DriverService(randomService);
            ICarService carService = new CarService(driverService);
            IConsoleDisplayService displayService = new ConsoleDisplayService();
            


            App app = new App(carService, driverService, displayService,randomService);
            app.Run();
        }
    }
}