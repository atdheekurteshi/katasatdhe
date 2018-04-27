using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CarRental.Entities;
using CarRental.Repositories;
namespace CarRental.Services
{
    public class ReservationService : IDisposable
    {
        public CarRentalDbContext carRentalDbContext;
        public IEnumerable<Car> resultOfAvailableCars;
        public ReservationService()
        {
            carRentalDbContext = new CarRentalDbContext();
        }
        [Description("FindAvailableCars")]
        public IEnumerable<Car> FindAvailableCars(DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime, string cityForRequestedReservation)
        {
            var idsOfCarsNotAvailableNow =
                carRentalDbContext.Reservations
                                  .Where(placedReservation => placedReservation.ReservationStart <= requestedReservationEndDateTime && placedReservation.ReservationEnd >= requestedReservationStartDateTime)
                                  .Select(placedReservation => placedReservation.CarId);

            var availableCars = carRentalDbContext.Cars.Where(car =>
                                                                      !idsOfCarsNotAvailableNow.Contains(car.CarId) && car.Office.City == cityForRequestedReservation);
         
                resultOfAvailableCars = availableCars.Select(availableCar => new Car
                {
                    CarId = availableCar.CarId,
                    Category = availableCar.Category,
                    CarBrand = availableCar.CarBrand,
                    KilometerReading = availableCar.KilometerReading,
                    LicenceNumber = availableCar.LicenceNumber,
                    OfficeId = availableCar.OfficeId,
                    Office = new Office
                    {
                        City = availableCar.Office.City,
                        Country = availableCar.Office.Country,
                        OfficeId = availableCar.Office.OfficeId,
                        Postcode = availableCar.Office.Postcode,
                        Street = availableCar.Office.Street
                    }
                }).ToList();

            return resultOfAvailableCars;
        }
        public void TakeCarReservervation(Customer customer, DateTime requestedReservationStartDateTime, DateTime requestedReservationEndDateTime, string city)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            ((IDisposable)carRentalDbContext).Dispose();
        }
    }
}