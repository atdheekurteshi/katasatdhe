using System;
using System.Collections.Generic;
using CarRental.Models;

namespace CarRental.Services
{
    public interface IReservationService
    {
        IEnumerable<CarModel> FindAvailableCars(DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime, string cityForRequestedReservation);
        void TakeCarReservervation(CustomerModel customer, DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime, string city);
    }
}