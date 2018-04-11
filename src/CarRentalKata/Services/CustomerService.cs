using System;
using System.Collections.Generic;
using System.Linq;
using CarRental.Entities;
using CarRental.Models;
using CarRental.Repositories;

namespace CarRental.Services
{
    public class CustomerService : ICustomerService
    {   /// <summary>
        /// ReservationService variable decleration
        /// </summary>
        public ReservationService reservationService;
        /// <summary>
        /// Customer variable decleration
        /// </summary>
        public Customer newCustomerEntity;
        /// <summary>
        /// CarRentalDbContext variable decleration
        /// </summary>
        public CarRentalDbContext carRentalDbContext;
        /// <summary>
        /// CustomerModel variable decleration
        /// </summary>
        public CustomerModel customerModel = null;
        /// <summary>
        /// Customer variable decleration
        /// </summary>
        public Customer foundCustomer;
        /// <summary>
        /// CustomerService constructor, here we initilize the reservationService and carRentalDbContext instaces
        /// </summary>
        public CustomerService()
        {
            reservationService = new ReservationService();
            carRentalDbContext = new CarRentalDbContext();
        }
        /// <summary>
        /// AddCustomer variable decleration
        /// </summary>
        /// <param name="customerModel"></param>
        public void AddCustomer(CustomerModel customerModel)
        {
            try
            {
                // NewCustomerEntity entry
                newCustomerEntity = new Customer
                {
                    City = customerModel.City,
                    CustomerType = customerModel.CustomerType,
                    Street = customerModel.Street,
                    Postcode = customerModel.Postcode,
                    CustomerId = customerModel.CustomerId,
                    CustomerNumber = customerModel.CustomerNumber,
                    DateOfBirth = customerModel.DateOfBirth,
                    FirstName = customerModel.FirstName,
                    LastName = customerModel.LastName
                };

                //using (var carRentalDbContext = new CarRentalDbContext())
                //{
                // Add the newCustomerEntity to the Customers table in database
                carRentalDbContext.Customers.Add(newCustomerEntity);
                // Savechanges to database
                carRentalDbContext.SaveChanges();
                //}
            }
            catch { throw new ArgumentNullException(); }
        }
        /// <summary>
        /// GetCustomerByCustomerNumber by customerNumber
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <returns></returns>
        public CustomerModel GetCustomerByCustomerNumber(string customerNumber)
        {
            //using (var carRentalDbContext = new CarRentalDbContext())
            //{
            // Find the customer with the paricular customerNumber and save into foundCustomer
            try
            {
                foundCustomer = carRentalDbContext.Customers.SingleOrDefault(customer => customer.CustomerNumber == customerNumber);
                //}
                //If found add the particuar customer else through an error

                if (foundCustomer != null)
                {
                    customerModel = new CustomerModel
                    {
                        CustomerType = foundCustomer.CustomerType,
                        City = foundCustomer.City,
                        CustomerId = foundCustomer.CustomerId,
                        CustomerNumber = foundCustomer.CustomerNumber,
                        DateOfBirth = foundCustomer.DateOfBirth,
                        Street = foundCustomer.Street,
                        Postcode = foundCustomer.Postcode,
                        LastName = foundCustomer.LastName,
                        FirstName = foundCustomer.FirstName
                    };
                }

            }
            catch
            {
                throw new ArgumentNullException();
            }

            return customerModel;
        }
        /// <summary>
        /// CreateCarReservation for the particualr Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="requestedReservationStartDateTime"></param>
        /// <param name="requestedReservationEndDateTime"></param>
        /// <param name="city"></param>
        public void CreateCarReservation(CustomerModel customer, DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime, string city)
        {
            try
            {
                reservationService.TakeCarReservervation(customer, requestedReservationStartDateTime, requestedReservationEndDateTime, city);
            }
            catch
            {
                throw new ArgumentNullException();
            }
        }
    }
}