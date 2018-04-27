using System;
using CarRental.Entities;

namespace CarRental.Services
{

    public interface ICustomerService
    {
        void AddCustomer(Customer customerModel);
        Customer GetCustomerByCustomerNumber(string customerNumber);
        void CreateCarReservation(Customer customer, DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime, string city);
    }
}