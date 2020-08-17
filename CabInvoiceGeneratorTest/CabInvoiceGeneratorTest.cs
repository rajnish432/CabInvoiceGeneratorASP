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
            double totalFare = this.cabInvoiceGenerator.CalculateFare(3.0, 5.0);
            Assert.AreEqual(35.0, totalFare);
        }

        /// <summary>
        /// Test to get minimum fare using given time and distance.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenProper_ShouldReturnMinimumFare()
        {
            double totalFare = this.cabInvoiceGenerator.CalculateFare(0.2, 2.0);
            Assert.AreEqual(5.0, totalFare);
        }

        /// <summary>
        /// Test to get total fare for Multiple Rides.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenProper_ShouldReturnAggregateFare()
        {
            Ride[] ride = { new Ride(3.0, 5.0), new Ride(2.0, 5.0) };
            InvoiceSummary invoiceSummary = this.cabInvoiceGenerator.GetMultipleRideFare(ride);
            Assert.AreEqual(30.0, invoiceSummary.averageFare);
        }

        /// <summary>
        /// Test to get Invoice Summary.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForMultipleRides_WhenProper_ShouldReturnInvoiceSummary()
        {
            Ride[] ride = { new Ride(3.0, 5.0), new Ride(2.0, 5.0) };
            InvoiceSummary invoiceSummary = this.cabInvoiceGenerator.GetMultipleRideFare(ride);
            InvoiceSummary expectedSummary = new InvoiceSummary(60.0, 2);
            Assert.AreEqual(expectedSummary, invoiceSummary);
        }
    }
}