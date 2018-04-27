using System.Security.AccessControl;
using CarRental.Entities;

namespace CarRental.Models
{
    public class CarModel : Car
    {
        public void AddKilometers(float kilometersDriven)
        {
            KilometerReading += kilometersDriven;
        }
    }
}