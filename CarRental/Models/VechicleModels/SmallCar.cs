
namespace CarRental.Models.VehicleModels
{
    public class SmallCar : Vehicle
    {
        public SmallCar(int mileage) : base(mileage) {}

        public double CalculatePrice(int daysRented)
        {
            var price = DayPrice * daysRented;
            return price;
        }
    }
}
