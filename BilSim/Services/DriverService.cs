using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilSim.Services
{
    public class DriverService : IDriverService
    {
        private int _tiredness;

        public DriverService()
        {
            _tiredness = 0;
        }

        public DriverStatus GetDriverStatus()
        {
            return new DriverStatus
            {
                Tiredness = _tiredness
            };
        }

        public void IncreaseTiredness()
        {
            _tiredness++;
            Console.WriteLine("Förarens trötthet har ökat.");
        }

        public void Rest()
        {
            _tiredness = 0;
            Console.WriteLine("Föraren har vilat och är utvilad nu.");
        }
    }
}
