using System;
using CarRental.Models;
using CarRental.Models.Services;
using CarRental.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRental.Models.VehicleModels;

namespace CarRental.UnitTests
{
    [TestClass]
    public class BookingServiceTests
    {
        [TestMethod]
        public void CheckIfExtendsVehicle_TypeExtendsVehicle_ReturnsTrue()
        {
            var bookingService = new BookingService();
            var result = bookingService.CheckIfExtendsVehicle("CarRental.Models.VehicleModels.Van");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckIfExtendsVehicle_TypeDoesntExtendVehicle_ReturnsFalse()
        {
            var bookingService = new BookingService();
            var result = bookingService.CheckIfExtendsVehicle("CarRental.Models.Customer");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckCurrentBooking_BookingIsCorrect_ReturnsOK()
        {
            var booking = new Booking("bookingnr", new MiniVan(12500), new Customer(9401089999), 1108);
            var bookingService = new BookingService();
            var result = bookingService.CheckCurrentBooking(booking);
            Assert.AreEqual("OK", result);
        }

        [TestMethod]
        public void CheckCurrentBooking_BookingIsFaulty_ReturnsErrorMsg()
        {
            var booking = new Booking("", null, null, 1);
            var bookingService = new BookingService();
            var result = bookingService.CheckCurrentBooking(booking);
            Assert.AreNotEqual("OK", result);
        }
        [TestMethod]
        public void CheckCurrentBooking_CustomerIsFaulty_ReturnsErrorMsg()
        {
            var booking = new Booking("bookingnr", new MiniVan(12500), new Customer(), 1109);
            var bookingService = new BookingService();
            var result = bookingService.CheckCurrentBooking(booking);
            Assert.AreNotEqual("OK",result);
        }

        [TestMethod]
        public void CheckCurrentBooking_VehicleIsFaulty_ReturnsErrorMsg()
        {
            var booking = new Booking("bookingnr", new MiniVan(-1), new Customer(1234567890), 1109);
            var bookingService = new BookingService();
            var result = bookingService.CheckCurrentBooking(booking);
            Assert.AreNotEqual("OK", result);
        }

        /* ---DATABASE IMPLEMENTATION SPECIFIC---
        [TestMethod]
        public void AddBookingToDatabase_BookingIsCorrect_ReturnsBookingPlaced()
        {
            var booking = new Booking("bookingnr", new Van(12950), new Customer(0), 1108);
            var bookingService = new BookingService();
            bookingService.CurrentBooking = booking;
            var result = bookingService.AddBookingToDatabase(booking);
            Assert.AreEqual("Booking placed", result);

        }
        [TestMethod]
        public void AddBookingToDatabase_BoookingIsFaulty_ReturnsException()
        {
            var booking = new Booking(null, null, null, 1108);
            var bookingService = new BookingService();
            bookingService.CurrentBooking = booking;
            var result = bookingService.AddBookingToDatabase(booking);
            Assert.AreNotEqual("Booking placed", result);
        }
        */
    }
}
