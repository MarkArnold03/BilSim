using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class CarStatus
    {
        public Direction Direction { get; set; }
        public int FuelLevel { get; set; }
    }
    public enum Direction
    {
        Norrut,
        Söderut,
        Västerut,
        Österut
    }
}
