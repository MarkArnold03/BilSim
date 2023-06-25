using BilSim.Services;
using ClassLibrary.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimTests
{
    [TestClass]
    public class CarServiceTests
    {
        private CarService carService;
        private Mock<IDriverService> driverServiceMock;

        [TestInitialize]
        public void Setup()
        {
            driverServiceMock = new Mock<IDriverService>();
            carService = new CarService(driverServiceMock.Object);
        }

        [TestMethod]
        public void GetCarStatus_ReturnsCarStatus()
        {
            // Arrange

            // Act
            CarStatus carStatus = carService.GetCarStatus();

            // Assert
            Assert.IsNotNull(carStatus);
            
        }

        [TestMethod]
        public void MoveForward_DecreasesFuelLevel()
        {
            // Arrange
            int initialFuelLevel = carService.GetCarStatus().FuelLevel;

            // Act
            carService.MoveForward();
            int updatedFuelLevel = carService.GetCarStatus().FuelLevel;

            // Assert
            Assert.AreEqual(initialFuelLevel - 1, updatedFuelLevel);
        }

        [TestMethod]
        public void MoveForward_WhenFuelIsEmpty_CannotMoveForward()
        {
            // Arrange
            carService.Refuel(); // Ensure the fuel level is full
            for (int i = 0; i < 10; i++)
            {
                carService.MoveForward(); // Consume all the fuel
            }

            // Act
            carService.MoveForward();

            // Assert
            Assert.IsFalse(driverServiceMock.Invocations.Any()); // No interactions with the driver service
            Assert.AreEqual(Direction.North, carService.GetCarStatus().Direction); // Car direction remains the same
            Assert.AreEqual(0, carService.GetCarStatus().FuelLevel); // Fuel level remains at 0
        }

        [TestMethod]
        public void MoveBackward_DecreasesFuelLevel()
        {
            // Arrange
            int initialFuelLevel = carService.GetCarStatus().FuelLevel;

            // Act
            carService.MoveBackward();
            int updatedFuelLevel = carService.GetCarStatus().FuelLevel;

            // Assert
            Assert.AreEqual(initialFuelLevel - 1, updatedFuelLevel);
        }

        [TestMethod]
        public void MoveBackward_WhenFuelIsEmpty_CannotMoveBackward()
        {
            // Arrange
            carService.Refuel(); // Ensure the fuel level is full
            for (int i = 0; i < 10; i++)
            {
                carService.MoveBackward(); // Consume all the fuel
            }

            // Act
            carService.MoveBackward();

            // Assert
            Assert.IsFalse(driverServiceMock.Invocations.Any()); // No interactions with the driver service
            Assert.AreEqual(Direction.North, carService.GetCarStatus().Direction); // Car direction remains the same
            Assert.AreEqual(0, carService.GetCarStatus().FuelLevel); // Fuel level remains at 0
        }

        [TestMethod]
        public void TurnRight_DecreasesFuelLevel()
        {
            // Arrange
            int initialFuelLevel = carService.GetCarStatus().FuelLevel;

            // Act
            carService.TurnRight();
            int updatedFuelLevel = carService.GetCarStatus().FuelLevel;

            // Assert
            Assert.AreEqual(initialFuelLevel - 1, updatedFuelLevel);
        }

        [TestMethod]
        public void TurnRight_WhenFuelIsEmpty_CannotTurnRight()
        {
            // Arrange
            carService.Refuel(); // Ensure the fuel level is full
            for (int i = 0; i < 10; i++)
            {
                carService.TurnRight(); // Consume all the fuel
            }

            // Act
            carService.TurnRight();

            // Assert
            Assert.IsFalse(driverServiceMock.Invocations.Any()); // No interactions with the driver service
            Assert.AreEqual(Direction.South, carService.GetCarStatus().Direction); // Car direction remains the same
            Assert.AreEqual(0, carService.GetCarStatus().FuelLevel); // Fuel level remains at 0
        }

        [TestMethod]
        public void TurnLeft_DecreasesFuelLevel()
        {
            // Arrange
            int initialFuelLevel = carService.GetCarStatus().FuelLevel;

            // Act
            carService.TurnLeft();
            int updatedFuelLevel = carService.GetCarStatus().FuelLevel;

            // Assert
            Assert.AreEqual(initialFuelLevel - 1, updatedFuelLevel);
        }

        [TestMethod]
        public void TurnLeft_WhenFuelIsEmpty_CannotTurnLeft()
        {
            // Arrange
            carService.Refuel(); // Ensure the fuel level is full
            for (int i = 0; i < 10; i++)
            {
                carService.TurnLeft(); // Consume all the fuel
            }

            // Act
            carService.TurnLeft();

            // Assert
            Assert.IsFalse(driverServiceMock.Invocations.Any()); // No interactions with the driver service
            Assert.AreEqual(Direction.South, carService.GetCarStatus().Direction); // Car direction remains the same
            Assert.AreEqual(0, carService.GetCarStatus().FuelLevel); // Fuel level remains at 0
        }

        [TestMethod]
        public void Refuel_ResetsFuelLevelToFull()
        {
            // Arrange
            int initialFuelLevel = carService.GetCarStatus().FuelLevel;

            // Act
            carService.Refuel();
            int updatedFuelLevel = carService.GetCarStatus().FuelLevel;

            // Assert
            Assert.AreEqual(10, updatedFuelLevel);
        }
    }
}
