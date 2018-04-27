using System;
using CarRental.Entities;
using CarRental.Services;

namespace CarRental.BusinessLayer
{
    public class CarRentalBusinessLayer
    {
        public CustomerService customerService;
        public Customer newCustomer;
        public CarRentalBusinessLayer()
        {
            customerService = new CustomerService();
        }
        public void CreateNewCustomer(Customer customer)
        {
            newCustomer = new Customer
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