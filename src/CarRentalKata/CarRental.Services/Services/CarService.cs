using System.Collections.Generic;
using CarRental.Models;
using CarRental.Services;
using System;
using CarRental.Entities;

namespace CarRental.Services
{
    public class CarService : ICarService
    {

        public decimal calculatePrice = 0;
        public ReservationService reservationService;
        public IEnumerable<CarModel> availableCars;
        public Dictionary<CarModel, decimal> result;
        public CarService calculatePriceForAvaliableCars;

        public CarService()
        {
            reservationService = new ReservationService();
            result = new Dictionary<CarModel, decimal>();
        }
        public Dictionary<CarModel, decimal> FindAvailableCarsForRental(CustomerModel customer, DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime, string city)
        {
            calculatePriceForAvaliableCars = new CarService();

            try
            {
                calculatePriceForAvaliableCars.CalculatePriceForAvaliableCarsForRental(customer, requestedReservationStartDateTime, requestedReservationEndDateTime, city);
            }
            catch
            {
                throw new Exception();
            }
            return calculatePriceForAvaliableCars.result.Count > 0 ? calculatePriceForAvaliableCars.result : null;
        }

        public void CalculatePriceForAvaliableCarsForRental(CustomerModel customer, DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime, string city)
        {
            avaliableCars(requestedReservationStartDateTime, requestedReservationEndDateTime, city);
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
                throw new Exception();
            }
        }

        public void avaliableCars(DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime,string city)
        {
            availableCars = reservationService.FindAvailableCars(requestedReservationStartDateTime, requestedReservationEndDateTime, city);

            foreach (var availableCar in availableCars)
            {
                if (availableCar.Category == CarModel.Small)
                {
                    carConsumerCategory(requestedReservationStartDateTime, requestedReservationEndDateTime);
                }
                else if (availableCar.Category == CarModel.Medium)
                {
                    carConsumerCategory(requestedReservationStartDateTime, requestedReservationEndDateTime);
                }
                else if (availableCar.Category == CarModel.Large)
                {
                    carConsumerCategory(requestedReservationStartDateTime, requestedReservationEndDateTime);
                }
                else if (availableCar.Category == CarModel.Luxury)
                {
                    carConsumerCategory(requestedReservationStartDateTime, requestedReservationEndDateTime);
                }
                else
                {
                    calculatePrice = 0;
                }
                result.Add(availableCar, calculatePrice);
            }
        }
    }
}
