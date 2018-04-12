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
        /// <summary>
        /// CalculatePriceForAvaliableCarsForRental method declaration
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="requestedReservationStartDateTime"></param>
        /// <param name="requestedReservationEndDateTime"></param>
        /// <param name="city"></param>
        void CalculatePriceForAvaliableCarsForRental(CustomerModel customer, DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime, string city);
        /// <summary>
        /// FindAvailableCarsForRental method declaration
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="requestedReservationStartDateTime"></param>
        /// <param name="requestedReservationEndDateTime"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        Dictionary<CarModel, decimal> FindAvailableCarsForRental(CustomerModel customer, DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime, string city);
        /// <summary>
        /// CarModelCategory method declaration
        /// </summary>
        /// <param name="customerTypeId"></param>
        /// <param name="outPutValue"></param>
        void carModelConsumer(int customerTypeId, decimal outPutValue);
        /// <summary>
        /// CarConsumerCategory method declaration
        /// </summary>
        /// <param name="requestedReservationStartDateTime"></param>
        /// <param name="requestedReservationEndDateTime"></param>
        void carConsumerCategory(DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime);
    }
}