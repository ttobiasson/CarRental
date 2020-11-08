using System;
using CarRental.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarRental.UnitTests
{
    [TestClass]
    public class BookingViewModelTests
    {
        [TestMethod]
        public void checkIfExtendsVehicle_TypeExtendsVehicle_ReturnsTrue()
        {
            var bookingViewModel = new BookingViewModel();
            var result = bookingViewModel.checkIfExtendsVehicle("CarRental.Models.VehicleModels.Van");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void checkIfExtendsVehicle_TypeDoesntExtendVehicle_ReturnsFalse()
        {
            var bookingViewModel = new BookingViewModel();
            var result = bookingViewModel.checkIfExtendsVehicle("CarRental.Models.VehicleModels.Moped");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void checkCurrentBooking_BookingIsCorrect_ReturnsOK()
        {

        }
    }
}
