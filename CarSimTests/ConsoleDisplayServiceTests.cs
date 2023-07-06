using BilSim.Services;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimTests
{
    [TestClass]
    public class ConsoleDisplayServiceTests
    {
        private ConsoleDisplayService consoleDisplayService;
        private CarService carService;
        private DriverService driverService;
        private RandomUserService randomUserService;

        [TestInitialize]
        public void Setup()
        {
            carService = new CarService(driverService);
            driverService = new DriverService(randomUserService);
            consoleDisplayService = new ConsoleDisplayService();
        }

        [TestMethod]
        public void DisplayCarStatus_ShouldDisplayCarStatus()
        {
            // Arrange
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            CarStatus carStatus = new CarStatus
            {
                Direction = Direction.North,
                FuelLevel = 50
            };

            // Act
            consoleDisplayService.DisplayCarStatus(carStatus);
            string output = consoleOutput.ToString().Trim();

            // Assert
            Assert.IsTrue(output.Contains("Bilens status"));
            Assert.IsTrue(output.Contains("Riktning: North"));
            Assert.IsTrue(output.Contains("Bensinnivå: 50%"));
            Assert.IsTrue(output.Contains("Bensinstatus: GRÖN"));
        }

        [TestMethod]
        public void DisplayDriverStatus_ShouldDisplayDriverStatus()
        {
            // Arrange,
            var consoleOutput = new StringWriter();
            var driver = new Driver();
            Console.SetOut(consoleOutput);
            DriverStatus driverStatus = new DriverStatus
            {
                Tiredness = 5
            };

            // Act
            consoleDisplayService.DisplayDriverStatus(driverStatus,driver);
            string output = consoleOutput.ToString().Trim();

            // Assert
            Assert.IsTrue(output.Contains("Förarens status"));
            Assert.IsTrue(output.Contains("Trötthet: 5"));
            Assert.IsTrue(output.Contains("Trötthetsstatus: GRÖN"));
        }

        [TestMethod]
        public void DisplayErrorMessage_ShouldDisplayErrorMessage()
        {
            // Arrange
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            string errorMessage = "Felmeddelande";

            // Act
            consoleDisplayService.DisplayErrorMessage(errorMessage);
            string output = consoleOutput.ToString().Trim();

            // Assert
            Assert.IsTrue(output.Contains("Fel: Felmeddelande"));
        }

        [TestMethod]
        public void GetUserInput_ShouldReturnUserInput()
        {
            // Arrange
            string userInput = "3";
            var inputReader = new StringReader(userInput);
            Console.SetIn(inputReader);

            // Act
            string result = consoleDisplayService.GetUserInput();

            // Assert
            Assert.AreEqual(userInput, result);
        }
    }

}
