using System;
using System.Collections.Generic;
using CarRental.Entities;

namespace CarRental.Services
{
    public interface ICarService
    {
        void CalculatePriceForAvaliableCarsForRental(DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime, string city);

        IEnumerable<Car> FindAvailableCarsForRental(DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime, string city);
       
        void CarModelConsumer(int customerTypeId, decimal outPutValue);
     
        void CarConsumerCategory(DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime);
    }
}