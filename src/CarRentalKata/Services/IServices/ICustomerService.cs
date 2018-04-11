using System;
using CarRental.Models;

namespace CarRental.Services
{

    public interface ICustomerService
    {
        /// <summary>
        /// AddCustomer method declaration
        /// </summary>
        /// <param name="customerModel"></param>
        void AddCustomer(CustomerModel customerModel);
        /// <summary>
        /// GetCustomerByCustomerNumber method declaration
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <returns></returns>
        CustomerModel GetCustomerByCustomerNumber(string customerNumber);
        /// <summary>
        /// CreateCarReservation method declaration
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="requestedReservationStartDateTime"></param>
        /// <param name="requestedReservationEndDateTime"></param>
        /// <param name="city"></param>
        void CreateCarReservation(CustomerModel customer, DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime, string city);
    }
}