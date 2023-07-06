using BilSim.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimTests
{
    [TestClass]
    public class DriverServiceTests
    {
        private DriverService driverService;
        private RandomUserService randomUserService;

        [TestInitialize]
        public void Setup()
        {
            // Initialize the driverService instance
            driverService = new DriverService(randomUserService);
        }

        [TestMethod]
        public void IncreaseTiredness_IncreasesTirednessByOne()
        {
            // Arrange
            int initialTiredness = driverService.GetDriverStatus().Tiredness;

            // Act
            driverService.IncreaseTiredness();
            int updatedTiredness = driverService.GetDriverStatus().Tiredness;

            // Assert
            Assert.AreEqual(initialTiredness + 1, updatedTiredness); // Tiredness increases by 1
        }

        [TestMethod]
        public void Rest_ResetsTirednessToZero()
        {
            // Arrange
            driverService.IncreaseTiredness(); // Increase tiredness to a non-zero value

            // Act
            driverService.Rest();
            int updatedTiredness = driverService.GetDriverStatus().Tiredness;

            // Assert
            Assert.AreEqual(0, updatedTiredness); // Tiredness is reset to zero
        }
    }
}
