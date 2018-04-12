using System;
using CarRental.Models;

namespace CarRental.Services
{

    public interface ICustomerService
    {
       
        void AddCustomer(CustomerModel customerModel);
        CustomerModel GetCustomerByCustomerNumber(string customerNumber);
        void CreateCarReservation(CustomerModel customer, DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime, string city);
    }
}