using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.VehicleModels
{
    public class Van : Vehicle
    {
        public Van(int mileage) : base(mileage) {}

        public double CalculatePrice(int daysRented, int kmDriven)
        {
            var price = (DayPrice * daysRented * 1.2) + (KmPrice * kmDriven);
            return price;
        }
    }
}
