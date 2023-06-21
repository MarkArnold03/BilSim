using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilSim.Services
{
    public class CarService : ICarService
    {
        private Direction _direction;
        private int _fuelLevel;

        public CarService()
        {
            _direction = Direction.North;
            _fuelLevel = 100;
        }

        public CarStatus GetCarStatus()
        {
            return new CarStatus
            {
                Direction = _direction,
                FuelLevel = _fuelLevel
            };
        }

        public void TurnRight()
        {
            if (_direction == Direction.North)
                _direction = Direction.East;
            else if (_direction == Direction.East)
                _direction = Direction.South;
            else if (_direction == Direction.South)
                _direction = Direction.West;
            else if (_direction == Direction.West)
                _direction = Direction.North;
        }

        public void TurnLeft()
        {
            if (_direction == Direction.North)
                _direction = Direction.West;
            else if (_direction == Direction.West)
                _direction = Direction.South;
            else if (_direction == Direction.South)
                _direction = Direction.East;
            else if (_direction == Direction.East)
                _direction = Direction.North;
        }

        public void MoveForward()
        {
            if (_direction == Direction.North)
                Console.WriteLine("Kör framåt norrut.");
            else if (_direction == Direction.East)
                Console.WriteLine("Kör framåt österut.");
            else if (_direction == Direction.South)
                Console.WriteLine("Kör framåt söderut.");
            else if (_direction == Direction.West)
                Console.WriteLine("Kör framåt västerut.");
        }

        public void MoveBackward()
        {
            if (_direction == Direction.North)
                Console.WriteLine("Kör bakåt söderut.");
            else if (_direction == Direction.East)
                Console.WriteLine("Kör bakåt västerut.");
            else if (_direction == Direction.South)
                Console.WriteLine("Kör bakåt norrut.");
            else if (_direction == Direction.West)
                Console.WriteLine("Kör bakåt österut.");
        }

        public void Refuel()
        {
            _fuelLevel = 100;
            Console.WriteLine("Bilen har tankats.");
        }
    }

}
