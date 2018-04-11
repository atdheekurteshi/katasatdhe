using System;
using CarRental.Models;
using CarRental.Services;

namespace CarRental.BusinessLayer
{
    public class CarRentalBusinessLayer
    {
        /// <summary>
        /// CustomerService variable declaration
        /// </summary>
        public CustomerService customerService;
        /// <summary>
        /// NewCustomer variable declaration
        /// </summary>
        public CustomerModel newCustomer;
        /// <summary>
        /// CarRentalBusinessLayer constructor, here we initilize the CustomerService
        /// </summary>
        public CarRentalBusinessLayer()
        {
            customerService = new CustomerService();
        }
        /// <summary>
        /// Create a new customer
        /// </summary>
        /// <param name="customer"></param>
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