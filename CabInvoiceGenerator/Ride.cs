// <copyright file="Ride.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    /// <summary>
    /// Ride Class to set Ride values.
    /// </summary>
    public class Ride
    {
        public double rideDistance;
        public double rideTime;
        public RideOption.RideTypes rideType;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ride"/> class.
        /// </summary>
        /// <param name="rideDistance"></param>
        /// <param name="rideTime"></param>
        public Ride(RideOption.RideTypes rideType, double rideDistance, double rideTime)
        {
            this.rideDistance = rideDistance;
            this.rideTime = rideTime;
            this.rideType = rideType;
        }
    }
}
