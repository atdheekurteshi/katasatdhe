using System.Collections.Generic;
using System;
using CarRental.Entities;

namespace CarRental.Services
{
    public class CarService : ICarService
    {
        //public decimal calculatePrice = 0.0m;

        public IEnumerable<Car> result;

        public Dictionary<Car, decimal> resultOfAvailableCars;

        public IEnumerable<Car> availableCars;
       
        public ICarService _carService;

      
        //public CarService(IEnumerable<Car> result, Dictionary<Car, decimal> resultOfAvailableCars, IEnumerable<Car> availableCars, ICarService carService,String[] args)
        //{
        //    this.result = result;
        //    this.resultOfAvailableCars = resultOfAvailableCars;
        //    this.availableCars = availableCars;
        //    _carService = carService;
            
        //}
        public CarService()
        {
            
        }
        

        public IEnumerable<Car> FindAvailableCarsForRental(
            DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime, string city)
        {
            var carService = new CarService();
            carService.CalculatePriceForAvaliableCarsForRental(requestedReservationStartDateTime,
                requestedReservationEndDateTime, city);

            return carService.result;
        }

        public void CalculatePriceForAvaliableCarsForRental(
            DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime, 
            string city)
        {
            var carService = new CarService();
            var resultOfAvailableCars = new Dictionary<Car, decimal>();
            var calculatePrice = 0.0m;
            availableCars = carService.FindAvailableCarsForRental( requestedReservationStartDateTime,
                requestedReservationEndDateTime, city);

            foreach (var availableCar in availableCars)
            {
                if (availableCar.Category == Car.Small)
                {
                    CarConsumerCategory(requestedReservationStartDateTime, requestedReservationEndDateTime);
                }
                else if (availableCar.Category == Car.Medium)
                {
                    CarConsumerCategory(requestedReservationStartDateTime, requestedReservationEndDateTime);
                }
                else if (availableCar.Category == Car.Large)
                {
                    CarConsumerCategory(requestedReservationStartDateTime, requestedReservationEndDateTime);
                }
                else if (availableCar.Category == Car.Luxury)
                {
                    CarConsumerCategory(requestedReservationStartDateTime, requestedReservationEndDateTime);
                }
                else
                {
                    calculatePrice = 0.0m;
                }

                resultOfAvailableCars.Add(availableCar, calculatePrice);
            }
        }

        public void CarModelConsumer(int customerTypeId, decimal outPutValue)
        {
            var calculatePrice = 0.0m;
            Dictionary<int, decimal> accounts = new Dictionary<int, decimal>();

            accounts.Add(Customer.Consumer, 1);
            accounts.Add(Customer.ConsumerPremium, 2);
            accounts.Add(Customer.Business, 3);
            accounts.Add(Customer.BusinessPremium, 4);

            if (accounts.ContainsKey(customerTypeId))
            {
                calculatePrice = calculatePrice - (calculatePrice * outPutValue);
            }
        }

        public void CarConsumerCategory(DateTime requestedReservationStartDateTime,
            DateTime requestedReservationEndDateTime)
        {
            var calculatePrice = 0.0m;
            Dictionary<string, string> carModels = new Dictionary<string, string>();

            carModels.Add(Car.Small, "A");
            carModels.Add(Car.Medium, "B");
            carModels.Add(Car.Large, "C");
            carModels.Add(Car.Luxury, "D");

            if (carModels.ContainsKey(Car.Small))
            {
                calculatePrice = 50 * (requestedReservationEndDateTime - requestedReservationStartDateTime).Days;
                CarModelConsumer(2, 0.02m);
            }
            else if (carModels.ContainsKey(Car.Medium))
            {
                calculatePrice = 65 * (requestedReservationEndDateTime - requestedReservationStartDateTime).Days;
                CarModelConsumer(2, 0.03m);
                CarModelConsumer(4, 0.04m);
            }
            else if (carModels.ContainsKey(Car.Large))
            {
                calculatePrice = 90 * (requestedReservationEndDateTime - requestedReservationStartDateTime).Days;
                CarModelConsumer(2, 0.05m);
                CarModelConsumer(3, 0.03m);
                CarModelConsumer(4, 0.08m);
            }
            else if (carModels.ContainsKey(Car.Luxury))
            {
                calculatePrice = 120 * (requestedReservationEndDateTime - requestedReservationStartDateTime).Days;
                CarModelConsumer(2, 0.06m);
                CarModelConsumer(3, 0.08m);
                CarModelConsumer(4, 0.12m);

               List<int> list=new List<int>();
               list.Add(1);
               list.Add(2);
               list.Add(3);
               list.Add(4);
               list.Add(1);
            }
            else
            {
                throw new Exception();
                
            }
        }
    }
} 