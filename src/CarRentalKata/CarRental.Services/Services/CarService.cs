using System.Collections.Generic;
using CarRental.Models;
using CarRental.Services;
using System;
using CarRental.Entities;

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
            //try
            // {
            calculatePriceForAvaliableCars.CalculatePriceForAvaliableCarsForRental(customer, requestedReservationStartDateTime, requestedReservationEndDateTime, city);
            // }
            //catch
            //{
            //    throw new ArgumentNullException();
            //}
            // Return CalculatePriceForAvaliableCarsForRental.Results
            return calculatePriceForAvaliableCars.result.Count > 0 ? calculatePriceForAvaliableCars.result : null;
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
            //try
            //{
            availableCars = reservationService.FindAvailableCars(requestedReservationStartDateTime, requestedReservationEndDateTime, city);

            // Query through availableCars and select them based on CustomerType
            foreach (var availableCar in availableCars)
            {
                switch (availableCar.Category)
                {
                    case CarModel.Small:
                        carConsumerCategory(requestedReservationStartDateTime, requestedReservationEndDateTime);
                        break;
                    case CarModel.Medium:
                        carConsumerCategory(requestedReservationStartDateTime, requestedReservationEndDateTime);
                        break;
                    case CarModel.Large:
                        carConsumerCategory(requestedReservationStartDateTime, requestedReservationEndDateTime);
                        break;
                    case CarModel.Luxury:
                        carConsumerCategory(requestedReservationStartDateTime, requestedReservationEndDateTime);
                        break;
                    default:
                        {
                            calculatePrice = 0;
                            break;
                        }
                }
                // Return the calulcated price for the avaliable cars
                result.Add(availableCar, calculatePrice);
            }
            // }
            //catch
            //{
            //    throw new ArgumentNullException();
            //}

        }

        public void carModelConsumer(int customerTypeId, decimal outPutValue)
        {
            Dictionary<int, decimal> accounts = new Dictionary<int, decimal>();

            accounts.Add(CustomerModel.Consumer, 1);
            accounts.Add(CustomerModel.ConsumerPremium, 2);
            accounts.Add(CustomerModel.Business, 3);
            accounts.Add(CustomerModel.BusinessPremium, 4);

            if (accounts.ContainsKey(customerTypeId))
            {
                calculatePrice = calculatePrice - (calculatePrice * outPutValue);
            }
        }
        public void carConsumerCategory(DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime)
        {

            Dictionary<string, string> carModels = new Dictionary<string, string>();

            carModels.Add(CarModel.Small, "A");
            carModels.Add(CarModel.Medium, "B");
            carModels.Add(CarModel.Large, "C");
            carModels.Add(CarModel.Luxury, "D");

            if (carModels.ContainsKey(CarModel.Small))
            {
                calculatePrice = 50 * (requestedReservationEndDateTime - requestedReservationStartDateTime).Days;
                carModelConsumer(2, 0.02m);
            }
            else if (carModels.ContainsKey(CarModel.Medium))
            {
                calculatePrice = 65 * (requestedReservationEndDateTime - requestedReservationStartDateTime).Days;
                carModelConsumer(2, 0.03m);
                carModelConsumer(4, 0.04m);
            }
            else if (carModels.ContainsKey(CarModel.Large))
            {
                calculatePrice = 90 * (requestedReservationEndDateTime - requestedReservationStartDateTime).Days;
                carModelConsumer(2, 0.05m);
                carModelConsumer(3, 0.03m);
                carModelConsumer(4, 0.08m);
            }
            else if (carModels.ContainsKey(CarModel.Luxury))
            {
                calculatePrice = 120 * (requestedReservationEndDateTime - requestedReservationStartDateTime).Days;
                carModelConsumer(2, 0.06m);
                carModelConsumer(3, 0.08m);
                carModelConsumer(4, 0.12m);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}
