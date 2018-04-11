using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CarRental.Models;
using CarRental.Repositories;
using CarRental.Services;
namespace CarRental.Services
{
    public class ReservationService : IReservationService
    {
        /// <summary>
        /// CarRentalDbContext variable decleration
        /// </summary>
        public CarRentalDbContext carRentalDbContext;
        /// <summary>
        /// ResultAvailableCars variable decleration
        /// </summary>
        public IEnumerable<CarModel> resultAvailableCars;
        /// <summary>
        /// ReservationService constructor, here we inject the car rental db context
        /// </summary>
        public ReservationService()
        {

            carRentalDbContext = new CarRentalDbContext();

        }
        /// <summary>
        /// FindAvailableCars from a CarModel
        /// </summary>
        /// <param name="requestedReservationStartDateTime"></param>
        /// <param name="requestedReservationEndDateTime"></param>
        /// <param name="cityForRequestedReservation"></param>
        /// <returns></returns>
        [Description("FindAvailableCars")]
        public IEnumerable<CarModel> FindAvailableCars(DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime, string cityForRequestedReservation)
        {
            //using (carRentalDbContext = new CarRentalDbContext())
            //{
            var idsOfCarsNotAvailableNow =
                carRentalDbContext.Reservations
                                  .Where(placedReservation => placedReservation.ReservationStart <= requestedReservationEndDateTime && placedReservation.ReservationEnd >= requestedReservationStartDateTime)
                                  .Select(placedReservation => placedReservation.CarId);

            var availableCars = carRentalDbContext.Cars.Where(car =>
                                                                      !idsOfCarsNotAvailableNow.Contains(car.CarId) && car.Office.City == cityForRequestedReservation);
           // try
            //{
                resultAvailableCars = availableCars.Select(availableCar => new CarModel
                {
                    CarId = availableCar.CarId,
                    Category = availableCar.Category,
                    CarBrand = availableCar.CarBrand,
                    KilometerReading = availableCar.KilometerReading,
                    LicenceNumber = availableCar.LicenceNumber,
                    OfficeId = availableCar.OfficeId,
                    Office = new OfficeModel
                    {
                        City = availableCar.Office.City,
                        Country = availableCar.Office.Country,
                        OfficeId = availableCar.Office.OfficeId,
                        Postcode = availableCar.Office.Postcode,
                        Street = availableCar.Office.Street
                    }
                }).ToList();
            //}
            //catch
            //{
            //    throw new ArgumentNullException();
            //}


            return resultAvailableCars;
            //}
        }
        
        /// <summary>
        /// Make car reservervation from a particualr customer
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="requestedReservationStartDateTime"></param>
        /// <param name="requestedReservationEndDateTime"></param>
        /// <param name="city"></param>
        public void TakeCarReservervation(CustomerModel customer, DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime, string city)
        {
            throw new NotImplementedException();
        }
    }
}