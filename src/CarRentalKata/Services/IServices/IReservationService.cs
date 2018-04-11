using System;
using System.Collections.Generic;
using CarRental.Models;

namespace CarRental.Services
{

    public interface IReservationService
    {
        /// <summary>
        /// FindAvailableCars method declaration
        /// </summary>
        /// <param name="requestedReservationStartDateTime"></param>
        /// <param name="requestedReservationEndDateTime"></param>
        /// <param name="cityForRequestedReservation"></param>
        /// <returns></returns>
        IEnumerable<CarModel> FindAvailableCars(DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime, string cityForRequestedReservation);
        /// <summary>
        /// TakeCarReservervation method declaration
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="requestedReservationStartDateTime"></param>
        /// <param name="requestedReservationEndDateTime"></param>
        /// <param name="city"></param>
        void TakeCarReservervation(CustomerModel customer, DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime, string city);

    }
}