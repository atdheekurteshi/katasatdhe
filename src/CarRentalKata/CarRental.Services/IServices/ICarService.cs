using System;
using System.Collections.Generic;
using CarRental.Models;

namespace CarRental.Services
{
    public interface ICarService
    {
        void CalculatePriceForAvaliableCarsForRental(CustomerModel customer, DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime, string city);
      
        Dictionary<CarModel, decimal> FindAvailableCarsForRental(CustomerModel customer, DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime, string city);
       
        void carModelConsumer(int customerTypeId, decimal outPutValue);
     
        void carConsumerCategory(DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime);
    }
}