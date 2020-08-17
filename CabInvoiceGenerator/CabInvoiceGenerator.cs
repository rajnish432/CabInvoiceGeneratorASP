// <copyright file="CabInvoiceGenerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CabInvoiceGenerator
{
    using System;

    /// <summary>
    /// Cab Invoice Generator Class.
    /// </summary>
    public class CabInvoiceGenerator
    {
        private static double COST_PER_KILOMETER;
        private static double COST_PER_MINUTE;
        private static double MINIMUM_FARE;
        private double cabFare = 0.0;
        private RideRepository rideRepository = new RideRepository();
        private RideOption rideOption = new RideOption();

        /// <summary>
        /// Function to Calculate Total Fare.
        /// </summary>
        /// <param name="rideTypes"></param>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double CalculateFare(RideOption.RideTypes rideTypes, double distance, double time)
        {
            this.SetRideInvoiceGeneratorValues(rideTypes);
            this.cabFare = (distance * COST_PER_KILOMETER) + (time * COST_PER_MINUTE);
            return Math.Max(this.cabFare, MINIMUM_FARE);
        }

        public InvoiceSummary GetMultipleRideFare(RideOption.RideTypes rideTypes, Ride[] rides)
        {
            double totalRideFare = 0.0;
            foreach (Ride ride in rides)
            {
                totalRideFare += this.CalculateFare(rideTypes, ride.rideDistance, ride.rideTime);
            }

            return new InvoiceSummary(totalRideFare, rides.Length);
        }

        public void SetRideInvoiceGeneratorValues(RideOption.RideTypes rideTypes)
        {
            RideOption rideType = this.rideOption.SetRideValues(rideTypes);
            COST_PER_KILOMETER = rideType.costPerKms;
            COST_PER_MINUTE = rideType.costPerMinute;
            MINIMUM_FARE = rideType.minimumFare;
        }

        public void MapRidesToUser(string userID, Ride[] rides)
        {
            this.rideRepository.AddCabRides(userID, rides);
        }

        public InvoiceSummary GetInvoiceSummary(RideOption.RideTypes rideTypes, string userID)
        {
            return this.GetMultipleRideFare(rideTypes, this.rideRepository.GetCabRides(userID));
        }
    }
}
