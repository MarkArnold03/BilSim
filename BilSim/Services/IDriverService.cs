﻿using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilSim.Services
{
    public interface IDriverService
    {
        DriverStatus GetDriverStatus();
        void IncreaseTiredness();
        void Rest();
    }
}
