using System;
using System.Collections.Generic;
using CarRental.Entities;

namespace CarRental.Services
{
    public interface IReservationService
    {
        IEnumerable<Car> FindAvailableCars(DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime, string cityForRequestedReservation);
        void TakeCarReservervation(Customer customer, DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime, string city);
    }
}