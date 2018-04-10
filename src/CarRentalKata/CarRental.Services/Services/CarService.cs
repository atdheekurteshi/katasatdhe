using System.Collections.Generic;
using CarRental.Models;
using CarRental.Services;
using System;

namespace CarRental.Services
{
    public class CarService : ICarService
    {
        /// <summary>
        /// CalculatePrice variable decleration
        /// </summary>
        public decimal calculatePrice = 0;
        /// <summary>
        /// ReservationService variable decleration
        /// </summary>
        public ReservationService reservationService;
        /// <summary>
        /// AvailableCars variable decleration
        /// </summary>
        public IEnumerable<CarModel> availableCars;
        /// <summary>
        /// Return variable decleration
        /// </summary>
        public Dictionary<CarModel, decimal> result;
        /// <summary>
        /// CalculatePriceForAvaliableCars variable decleration
        /// </summary>
        public CarService calculatePriceForAvaliableCars;

        /// <summary>
        /// CarService constructor, here we inject the reservation service instance and the result instance so we can obtain them faster.
        /// </summary>
        public CarService()
        {
            reservationService = new ReservationService();
            result = new Dictionary<CarModel, decimal>();

        }

        /// <summary>
        /// Calculating the price for the rental avaliable cars form a particualr city like city="Wien"
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="requestedReservationStartDateTime"></param>
        /// <param name="requestedReservationEndDateTime"></param>
        /// <param name="city"></param>
        public void CalculatePriceForAvaliableCarsForRental(CustomerModel customer, DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime, string city)
        {
            // Reserve all avaliablecarse peer requestedReservationStartDateTime and requestedReservationEndDateTime and city
            try
            {
                availableCars = reservationService.FindAvailableCars(requestedReservationStartDateTime, requestedReservationEndDateTime, city);
                // Query through availableCars and select them based on CustomerType
                foreach (var availableCar in availableCars)
                {
                    switch (availableCar.Category)
                    {
                        case "A":
                            {
                                calculatePrice = 50 * (requestedReservationEndDateTime - requestedReservationStartDateTime).Days;

                                switch (customer.CustomerType)
                                {
                                    case CustomerModel.ConsumerPremium:
                                        {
                                            calculatePrice = calculatePrice - (calculatePrice * 0.02m);
                                            break;
                                        }
                                }

                                break;
                            }

                        case "B":
                            {
                                calculatePrice = 65 * (requestedReservationEndDateTime - requestedReservationStartDateTime).Days;

                                switch (customer.CustomerType)
                                {
                                    case CustomerModel.ConsumerPremium:
                                        {
                                            calculatePrice = calculatePrice - (calculatePrice * 0.03m);
                                            break;
                                        }

                                    case CustomerModel.BusinessPremium:
                                        {
                                            calculatePrice = calculatePrice - (calculatePrice * 0.04m);
                                            break;
                                        }
                                }

                                break;
                            }

                        case "C":
                            {
                                calculatePrice = 90 * (requestedReservationEndDateTime - requestedReservationStartDateTime).Days;

                                switch (customer.CustomerType)
                                {
                                    case CustomerModel.ConsumerPremium:
                                        {
                                            calculatePrice = calculatePrice - (calculatePrice * 0.05m);
                                            break;
                                        }

                                    case CustomerModel.Business:
                                        {
                                            calculatePrice = calculatePrice - (calculatePrice * 0.06m);
                                            break;
                                        }

                                    case CustomerModel.BusinessPremium:
                                        {
                                            calculatePrice = calculatePrice - (calculatePrice * 0.08m);
                                            break;
                                        }
                                }

                                break;
                            }

                        case "D":
                            {
                                calculatePrice = 120 * (requestedReservationEndDateTime - requestedReservationStartDateTime).Days;

                                switch (customer.CustomerType)
                                {
                                    case CustomerModel.ConsumerPremium:
                                        {
                                            calculatePrice = calculatePrice - (calculatePrice * 0.06m);
                                            break;
                                        }

                                    case CustomerModel.Business:
                                        {
                                            calculatePrice = calculatePrice - (calculatePrice * 0.08m);
                                            break;
                                        }

                                    case CustomerModel.BusinessPremium:
                                        {
                                            calculatePrice = calculatePrice - (calculatePrice * 0.12m);
                                            break;
                                        }
                                }

                                break;
                            }

                        default:
                            {
                                calculatePrice = 0;
                                break;
                            }
                    }
                    // Return the calulcated price for the avaliable cars
                    result.Add(availableCar, calculatePrice);
                }
            }
            catch
            {
                throw new ArgumentNullException();
            }

        }

        /// <summary>
        /// Finding all avaliable cars for rental form a particualr city like city="Wien"
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="requestedReservationStartDateTime"></param>
        /// <param name="requestedReservationEndDateTime"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        public Dictionary<CarModel, decimal> FindAvailableCarsForRental(CustomerModel customer, DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime, string city)
        {
            // Declear calculatePriceForAvaliableCars 
            calculatePriceForAvaliableCars = new CarService();
            // Call calculatePriceForAvaliableCars.CalculatePriceForAvaliableCarsForRental
            try
            {
                calculatePriceForAvaliableCars.CalculatePriceForAvaliableCarsForRental(customer, requestedReservationStartDateTime, requestedReservationEndDateTime, city);
            }
            catch
            {
                throw new ArgumentNullException();
            }
            // Return CalculatePriceForAvaliableCarsForRental.Results
            return calculatePriceForAvaliableCars.result.Count > 0 ? calculatePriceForAvaliableCars.result : null;
        }

    }
}