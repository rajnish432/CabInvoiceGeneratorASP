// <copyright file="RideRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CabInvoiceGenerator
{
    using System.Collections.Generic;

    public class RideRepository
    {
        private Dictionary<string, List<Ride>> userRideList = new Dictionary<string, List<Ride>>();

        public void AddCabRides(string userID, Ride[] ride)
        {
            bool checkList = this.userRideList.ContainsKey(userID);

            if (checkList == false)
            {
                this.userRideList.Add(userID, new List<Ride>(ride));
            }
        }

        public Ride[] GetCabRides(string userId)
        {
            return this.userRideList[userId].ToArray();
        }
    }
}
