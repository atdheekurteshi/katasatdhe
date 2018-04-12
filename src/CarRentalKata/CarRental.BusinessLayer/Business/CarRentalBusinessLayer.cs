using System;
using CarRental.Models;
using CarRental.Services;

namespace CarRental.BusinessLayer
{
    public class CarRentalBusinessLayer
    {

       
        public CustomerService customerService;
        public CustomerModel newCustomer;
        public CarRentalBusinessLayer()
        {
            customerService = new CustomerService();
        }
        public void CreateNewCustomer(CustomerModel customer)
        {
            newCustomer = new CustomerModel
            {
                CustomerNumber = Guid.NewGuid().ToString(),
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DateOfBirth = customer.DateOfBirth,
                City = customer.City,
                CustomerType = customer.CustomerType,
                Street = customer.Street,
                Postcode = customer.Postcode
            };
            customerService.AddCustomer(newCustomer);
        }
    }
}