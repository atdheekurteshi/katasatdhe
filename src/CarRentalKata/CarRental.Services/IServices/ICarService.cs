using System;
using System.Collections.Generic;
using CarRental.Entities;
using CarRental.Models;
using CarRental.Services;
using CarRental.Repositories;

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