using System;
using System.Linq;
using CarRental.Entities;
using CarRental.Models;
using CarRental.Repositories;

namespace CarRental.Services
{
    public class CustomerService : ICustomerService, IDisposable
    {
        public ReservationService reservationService;
        public Customer newCustomerEntity;
        public CarRentalDbContext carRentalDbContext;
        public CustomerModel customerModel = null;
        public Customer foundCustomer;
        public CustomerService()
        {
            reservationService = new ReservationService();
            carRentalDbContext = new CarRentalDbContext();
        }
        public void AddCustomer(CustomerModel customerModel)
        {
            try
            {
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

                carRentalDbContext.Customers.Add(newCustomerEntity);
                carRentalDbContext.SaveChanges();
            }
            catch { throw new ArgumentNullException(); }
        }
        public CustomerModel GetCustomerByCustomerNumber(string customerNumber)
        {
            try
            {
                foundCustomer = carRentalDbContext.Customers.SingleOrDefault(customer => customer.CustomerNumber == customerNumber);

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
        public void Dispose()
        {
            ((IDisposable)carRentalDbContext).Dispose();
        }
    }
}