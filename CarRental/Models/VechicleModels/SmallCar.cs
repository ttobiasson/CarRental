using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CarRental.Models.VehicleModels
{
    public class SmallCar : Vehicle
    {
        public SmallCar(int mileage) : base(mileage) { }

        public double CalculatePrice(int daysRented)
        {
            var price = DayPrice * daysRented;
            return price;
        }
    }
}
