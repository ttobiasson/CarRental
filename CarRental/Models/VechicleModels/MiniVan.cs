
namespace CarRental.Models.VehicleModels
{
    public class MiniVan : Vehicle
    {
        public MiniVan(int mileage) : base(mileage) {}
               
        public double CalulatePrice(int daysRented, int kmDriven)
        {
            var price = (DayPrice * daysRented * 1.7) + 
                        (KmPrice * kmDriven * 1.5);
            return price;
        }
    }
}
