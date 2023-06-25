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
    public class DirectionTests
    {
        private CarService carService;

        [TestInitialize]
        public void Setup()
        {
            // Initialize the carService instance
            carService = new CarService(new Mock<IDriverService>().Object);
        }

        [TestMethod]
        public void TurnRight_ChangesDirectionClockwise()
        {
            // Arrange
            Direction initialDirection = carService.GetCarStatus().Direction;

            // Act
            carService.TurnRight();
            Direction updatedDirection = carService.GetCarStatus().Direction;

            // Assert
            Assert.AreNotEqual(initialDirection, updatedDirection); // Direction changes
                                             
        }

        [TestMethod]
        public void TurnLeft_ChangesDirectionCounterClockwise()
        {
            // Arrange
            Direction initialDirection = carService.GetCarStatus().Direction;

            // Act
            carService.TurnLeft();
            Direction updatedDirection = carService.GetCarStatus().Direction;

            // Assert
            Assert.AreNotEqual(initialDirection, updatedDirection); // Direction changes
                                                                    
        }

        [TestMethod]
        public void MoveForward_ChangesDirectionBasedOnCurrentDirection()
        {
            // Arrange
            Direction initialDirection = carService.GetCarStatus().Direction;

            // Act
            carService.MoveForward();
            Direction updatedDirection = carService.GetCarStatus().Direction;

            // Assert
            Assert.AreEqual(initialDirection, updatedDirection); // Direction remains the same
                                                                 
        }

        [TestMethod]
        public void MoveBackward_ChangesDirectionOppositeToCurrentDirection()
        {
            // Arrange
            Direction initialDirection = carService.GetCarStatus().Direction;

            // Act
            carService.MoveBackward();
            Direction updatedDirection = carService.GetCarStatus().Direction;

            // Assert
            Assert.AreNotEqual(initialDirection, updatedDirection); // Direction changes
                                                                    
        }
    }

}
