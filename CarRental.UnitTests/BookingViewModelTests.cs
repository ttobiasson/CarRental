using System;
using CarRental.Models;
using CarRental.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRental.Models.VehicleModels;

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
            var result = bookingViewModel.checkIfExtendsVehicle("CarRental.Models.Customer");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void checkCurrentBooking_BookingIsCorrect_ReturnsOK()
        {
            var booking = new Booking("bookingnr", new Van(), new Customer(0), 1108);
            var bookingViewModel = new BookingViewModel();
            var result = bookingViewModel.checkCurrentBooking(booking);
            Assert.AreEqual("OK", result);
        }

        [TestMethod]
        public void checkCurrentBooking_BookingIsFaulty_ReturnsErrorMsg()
        {
            var booking = new Booking("", null, null, 1);
            var bookingViewModel = new BookingViewModel();
            var result = bookingViewModel.checkCurrentBooking(booking);
            Assert.AreNotEqual("OK", result);
        }

    }
}
