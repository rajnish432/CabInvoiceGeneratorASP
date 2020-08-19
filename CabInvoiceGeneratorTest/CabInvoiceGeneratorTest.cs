// <copyright file="CabInvoiceGeneratorTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CabInvoiceGeneratorTest
{
    using NUnit.Framework;
    using CabInvoiceGenerator;

    /// <summary>
    /// Test Class for Cab Invoice Generator.
    /// </summary>
    public class CabInvoiceGeneratorTest
    {
        private CabInvoiceGenerator cabInvoiceGenerator;

        /// <summary>
        /// Setup Method.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.cabInvoiceGenerator = new CabInvoiceGenerator();
        }

        /// <summary>
        /// Test to get total fare using given time and distance.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenProper_ShouldReturnTotalFare()
        {
            // format is Ride type,distance,time of ride.
            double totalFare = this.cabInvoiceGenerator.CalculateFare(RideOption.RideTypes.NORMAL, 3.0, 5.0);
            Assert.AreEqual(35.0, totalFare);
        }

        /// <summary>
        /// Test to get minimum fare using given time and distance.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenProper_ShouldReturnMinimumFare()
        {
            // format is Ride type,distance,time of ride.
            double totalFare = this.cabInvoiceGenerator.CalculateFare(RideOption.RideTypes.NORMAL, 0.2, 2.0);
            Assert.AreEqual(5.0, totalFare);
        }

        /// <summary>
        /// Test to get total fare for Multiple Rides.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenProper_ShouldReturnAggregateFare()
        {
            // format is Ride type,distance,time of ride.
            Ride[] ride = { new Ride(RideOption.RideTypes.NORMAL, 3.0, 5.0), new Ride(RideOption.RideTypes.NORMAL, 2.0, 5.0) };
            InvoiceSummary invoiceSummary = this.cabInvoiceGenerator.GetMultipleRideFare(RideOption.RideTypes.NORMAL, ride);
            Assert.AreEqual(30.0, invoiceSummary.averageFare);
        }

        /// <summary>
        /// Test to get Invoice Summary.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenProper_ShouldReturnInvoiceSummary()
        {
            // format is Ride type,distance,time of ride.
            Ride[] ride = { new Ride(RideOption.RideTypes.NORMAL, 3.0, 5.0), new Ride(RideOption.RideTypes.NORMAL, 2.0, 5.0) };
            InvoiceSummary invoiceSummary = this.cabInvoiceGenerator.GetMultipleRideFare(RideOption.RideTypes.NORMAL, ride);
            InvoiceSummary expectedSummary = new InvoiceSummary(60.0, 2);
            Assert.AreEqual(expectedSummary, invoiceSummary);
        }

        /// <summary>
        /// Test to get Invoice Summary as per User.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenUserFound_ShouldReturnInvoiceSummary()
        {
            string userId = "Rajnish@123";

            // format is Ride type,distance,time of ride.
            Ride[] ride = { new Ride(RideOption.RideTypes.NORMAL, 3.0, 5.0), new Ride(RideOption.RideTypes.NORMAL, 2.0, 5.0) };
            this.cabInvoiceGenerator.MapRidesToUser(userId, ride);
            InvoiceSummary invoiceSummary = this.cabInvoiceGenerator.GetInvoiceSummary(RideOption.RideTypes.NORMAL, userId);
            InvoiceSummary expectedSummary = new InvoiceSummary(60.0, 2);
            Assert.AreEqual(expectedSummary, invoiceSummary);
        }

        /// <summary>
        /// Test to check invalid UserId exception.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenUserIDNotProper_ShouldReturnException()
        {
            string userId = "rajnish@123";

            // format is Ride type,distance,time of ride.
            Ride[] ride = { new Ride(RideOption.RideTypes.NORMAL, 3.0, 5.0), new Ride(RideOption.RideTypes.NORMAL, 2.0, 5.0) };
            var exception = Assert.Throws<CabInvoiceException>(() => this.cabInvoiceGenerator.MapRidesToUser(userId, ride));
            Assert.AreEqual(CabInvoiceException.ExceptionType.INVALID_USER_ID, exception.exceptionType);
        }

        /// <summary>
        /// Test to get total fare using given time and distance for Premium Ride.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForPremiumRide_WhenProper_ShouldReturnTotalFare()
        {
            // format is Ride type,distance,time of ride.
            double totalFare = this.cabInvoiceGenerator.CalculateFare(RideOption.RideTypes.PREMIUM, 3.0, 5.0);
            Assert.AreEqual(55.0, totalFare);
        }

        /// <summary>
        /// Test to get minimum fare using given time and distance for premium ride.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForPremiumRide_WhenProper_ShouldReturnMinimumFare()
        {
            // format is Ride type,distance,time of ride.
            double totalFare = this.cabInvoiceGenerator.CalculateFare(RideOption.RideTypes.PREMIUM, 0.2, 2.0);
            Assert.AreEqual(20.0, totalFare);
        }
    }
}