namespace CarRental.BusinessLayer.IntegrationTests
{
    using System;
    using System.Linq;
    using AutoFixture;
    using Entities;
    using Models;
    using Repositories;
    using Xunit;
    using CarRental.Services;

    public class CarRentalBusinessLayerTests : IDisposable
    {
        /// <summary>
        /// CustomersLastNameToBeDeleted variable declered and initilized
        /// </summary>
        private const string CustomersLastNameToBeDeleted = "FC5EC369-1CDB-4A6E-B0D0-9D3E89ADFE6C";
        /// <summary>
        /// CustomerLastName variable declered and initilized
        /// </summary>
        private const string customerLastName = CustomersLastNameToBeDeleted;
        /// <summary>
        /// Fixture variable declered and initilized
        /// </summary>
        private readonly Fixture _autoFixture = new Fixture();
        /// <summary>
        /// Dispose the TestCleanup
        /// </summary>
        public void Dispose()
        {
            TestCleanup();
        }

        [Fact]
        public void TestCleanup()
        {
            using (var carRentalDbContext = new CarRentalDbContext())
            {
                var customerToBeDeleted = carRentalDbContext.Customers.SingleOrDefault(c => c.LastName == CustomersLastNameToBeDeleted);
                if (customerToBeDeleted != null)
                {
                    carRentalDbContext.Customers.Remove(customerToBeDeleted);
                    carRentalDbContext.SaveChanges();
                }
            }
        }

        [Fact]
        public void SearchInVienna_Returns2Cars()
        {
            //Arrange
            var systemUnderTest = new CarService();
            var requestedReservationStart = new DateTime(2014, 09, 22, 8, 0, 0);
            var requestedReservationEnd = new DateTime(2014, 09, 25, 8, 0, 0);
            var anonymousCustomerDoSearch = _autoFixture.Create<Customer>();
            const string cityToSearchFor = "Wien";

            //Act
            var actualResult = systemUnderTest.FindAvailableCarsForRental(anonymousCustomerDoSearch, requestedReservationStart, requestedReservationEnd, cityToSearchFor);

            //Assert
            var expectedResult = 2;
            Assert.True(actualResult.Count == expectedResult);
        }
        [Fact]
        public void SearchInBerlin_Returns3Cars()
        {
            //Arrange
            var systemUnderTest = new CarService();
            var requestedReservationStart = new DateTime(2013, 12, 29, 8, 0, 0);
            var requestedReservationEnd = new DateTime(2014, 09, 28, 8, 0, 0);
            var anonymousCustomerDoSearch = _autoFixture.Create<Customer>();
            const string cityToSearchFor = "Berlin";

            //Act
            var actualResult = systemUnderTest.FindAvailableCarsForRental(anonymousCustomerDoSearch, requestedReservationStart, requestedReservationEnd, cityToSearchFor);

            //Assert
            var expectedResult = 3;
            Assert.True(actualResult.Count == expectedResult);
        }
        [Fact]
        public void SearchInSalzburg_Returns1Cars()
        {
            //Arrange
            var systemUnderTest = new CarService();
            var requestedReservationStart = new DateTime(2014, 05, 24, 8, 0, 0);
            var requestedReservationEnd = new DateTime(2014, 06, 01, 8, 0, 0);
            var anonymousCustomerDoSearch = _autoFixture.Create<Customer>();
            const string cityToSearchFor = "Salzburg";

            //Act
            var actualResult = systemUnderTest.FindAvailableCarsForRental(anonymousCustomerDoSearch, requestedReservationStart, requestedReservationEnd, cityToSearchFor);

            //Assert
            var expectedResult = 1;
            Assert.True(actualResult.Count == expectedResult);
        }

        [Fact]
        public void SearchInBratislava_Returns3Cars()
        {
            //Arrange
            var systemUnderTest = new CarService();
            var requestedReservationStart = new DateTime(2014, 05, 24, 8, 0, 0);
            var requestedReservationEnd = new DateTime(2017, 06, 01, 8, 0, 0);
            var anonymousCustomerDoSearch = _autoFixture.Create<Customer>();
            const string cityToSearchFor = "Bratislava";

            //Act
            var actualResult = systemUnderTest.FindAvailableCarsForRental(anonymousCustomerDoSearch, requestedReservationStart, requestedReservationEnd, cityToSearchFor);

            //Assert
            var expectedResult = 3;

            Assert.True(actualResult.Count == expectedResult);


        }

        [Fact]
        public void SearchInPrag_Returns2Cars()
        {
            //Arrange
            var systemUnderTest = new CarService();
            var requestedReservationStart = new DateTime(2014, 01, 29, 8, 0, 0);
            var requestedReservationEnd = new DateTime(2014, 04, 02, 8, 0, 0);
            var anonymousCustomerDoSearch = _autoFixture.Create<Customer>();
            const string cityToSearchFor = "Prag";

            //Act
            var actualResult = systemUnderTest.FindAvailableCarsForRental(anonymousCustomerDoSearch, requestedReservationStart, requestedReservationEnd, cityToSearchFor);

            //Assert
            var expectedResult = 2;
            Assert.True(actualResult.Count == expectedResult);
        }
        public void SearchInMuenchen_Returns3Cars()
        {
            //Arrange
            var systemUnderTest = new CarService();
            var requestedReservationStart = new DateTime(2015, 03, 31, 8, 0, 0);
            var requestedReservationEnd = new DateTime(2017, 11, 18, 8, 0, 0);
            var anonymousCustomerDoSearch = _autoFixture.Create<Customer>();
            const string cityToSearchFor = "München";

            //Act
            var actualResult = systemUnderTest.FindAvailableCarsForRental(anonymousCustomerDoSearch, requestedReservationStart, requestedReservationEnd, cityToSearchFor);

            //Assert
            var expectedResult = 3;
            Assert.True(actualResult.Count == expectedResult);
        }

        [Fact]
        public void SearchResult_Returns_CarsWith_ViennaOffice()
        {
            //Arrange
            var systemUnderTest = new CarService();
            var requestedReservationStart = new DateTime(2014, 09, 22, 8, 0, 0);
            var requestedReservationEnd = new DateTime(2014, 09, 25, 8, 0, 0);
            var anonymousCustomerDoSearch = _autoFixture.Create<Customer>();
            const string cityToSearchFor = "Wien";

            //Act
            var actualResult = systemUnderTest.FindAvailableCarsForRental(anonymousCustomerDoSearch, requestedReservationStart, requestedReservationEnd, cityToSearchFor);

            //Assert
            Func<CarModel, bool> expectedResult = (car => car.Office.City != cityToSearchFor);
            Assert.False(actualResult.Keys.Any(expectedResult));
        }
        [Fact]
        public void SearchResult_Returns_CarsWith_BerlinOffice()
        {
            //Arrange
            var systemUnderTest = new CarService();
            var requestedReservationStart = new DateTime(2013, 12, 29, 8, 0, 0);
            var requestedReservationEnd = new DateTime(2014, 09, 28, 8, 0, 0);
            var anonymousCustomerDoSearch = _autoFixture.Create<Customer>();
            const string cityToSearchFor = "Berlin";

            //Act
            var actualResult = systemUnderTest.FindAvailableCarsForRental(anonymousCustomerDoSearch, requestedReservationStart, requestedReservationEnd, cityToSearchFor);

            //Assert
            Func<CarModel, bool> expectedResult = (car => car.Office.City != cityToSearchFor);
            Assert.False(actualResult.Keys.Any(expectedResult));
        }
        [Fact]
        public void SearchResult_Returns_CarsWith_MuenchenOffice()
        {
            //Arrange
            var systemUnderTest = new CarService();
            var requestedReservationStart = new DateTime(2015, 03, 31, 8, 0, 0);
            var requestedReservationEnd = new DateTime(2017, 11, 18, 8, 0, 0);
            var anonymousCustomerDoSearch = _autoFixture.Create<Customer>();
            const string cityToSearchFor = "München";

            //Act
            var actualResult = systemUnderTest.FindAvailableCarsForRental(anonymousCustomerDoSearch, requestedReservationStart, requestedReservationEnd, cityToSearchFor);

            //Assert
            Func<CarModel, bool> expectedResult = (car => car.Office.City != cityToSearchFor);
            Assert.False(actualResult.Keys.Any(expectedResult));
        }
        [Fact]
        public void SearchResult_Returns_CarsWith_PragOffice()
        {
            //Arrange
            var systemUnderTest = new CarService();
            var requestedReservationStart = new DateTime(2014, 01, 29, 8, 0, 0);
            var requestedReservationEnd = new DateTime(2014, 04, 02, 8, 0, 0);
            var anonymousCustomerDoSearch = _autoFixture.Create<Customer>();
            const string cityToSearchFor = "Prag";

            //Act
            var actualResult = systemUnderTest.FindAvailableCarsForRental(anonymousCustomerDoSearch, requestedReservationStart, requestedReservationEnd, cityToSearchFor);

            //Assert
            Func<CarModel, bool> expectedResult = (car => car.Office.City != cityToSearchFor);
            Assert.False(actualResult.Keys.Any(expectedResult));
        }
        [Fact]
        public void SearchResult_Returns_CarsWith_BratislavaOffice()
        {
            //Arrange
            var systemUnderTest = new CarService();
            var requestedReservationStart = new DateTime(2014, 05, 24, 8, 0, 0);
            var requestedReservationEnd = new DateTime(2017, 06, 01, 8, 0, 0);
            var anonymousCustomerDoSearch = _autoFixture.Create<Customer>();
            const string cityToSearchFor = "Bratislava";

            //Act
            var actualResult = systemUnderTest.FindAvailableCarsForRental(anonymousCustomerDoSearch, requestedReservationStart, requestedReservationEnd, cityToSearchFor);

            //Assert
            Func<CarModel, bool> expectedResult = (car => car.Office.City != cityToSearchFor);
            Assert.False(actualResult.Keys.Any(expectedResult));
        }
        [Fact]
        public void SearchResult_Returns_CarsWith_SalzburgOffice()
        {
            //Arrange
            var systemUnderTest = new CarService();
            var requestedReservationStart = new DateTime(2014, 05, 24, 8, 0, 0);
            var requestedReservationEnd = new DateTime(2014, 06, 01, 8, 0, 0);
            var anonymousCustomerDoSearch = _autoFixture.Create<Customer>();
            const string cityToSearchFor = "Salzburg";

            //Act
            var actualResult = systemUnderTest.FindAvailableCarsForRental(anonymousCustomerDoSearch, requestedReservationStart, requestedReservationEnd, cityToSearchFor);

            //Assert
            Func<CarModel, bool> expectedResult = (car => car.Office.City != cityToSearchFor);
            Assert.False(actualResult.Keys.Any(expectedResult));
        }
        [Fact]
        public void CarPriceOfCarTypeB_IsCorrectCalculated_ForCustomerOfType_Consumer()
        {
            //Arrange
            var systemUnderTest = new CarService();
            var requestedReservationStart = new DateTime(2014, 09, 22, 8, 0, 0);
            var requestedReservationEnd = new DateTime(2014, 09, 25, 8, 0, 0);
            var customerOfTypeConsumerDoSearch = _autoFixture.Build<Customer>().With(property => property.CustomerType, Customer.Consumer).Create();
            const string cityToSearchFor = "Wien";

            //Act
            var actualResult = systemUnderTest.FindAvailableCarsForRental(customerOfTypeConsumerDoSearch, requestedReservationStart, requestedReservationEnd, cityToSearchFor)
                                              .Where(availableCar => availableCar.Key.Category == CarModel.Medium).Select(result => result.Value);

            //Assert
            var expectedResult = 195.0m;
            foreach (var price in actualResult) { Assert.True(price == expectedResult); }
        }

        [Fact]
        public void CarPriceOfCarTypeD_IsCorrectCalculated_ForCustomerOfType_Consumer()
        {
            //Arrange
            var systemUnderTest = new CarService();
            var carModel = new CarModel();
            var requestedReservationStart = new DateTime(2015, 03, 31, 8, 0, 0);
            var requestedReservationEnd = new DateTime(2015, 04, 01, 8, 0, 0);
            var customerOfTypeConsumerDoSearch = _autoFixture.Build<Customer>().With(property => property.CustomerType, Customer.Consumer).Create();
            const string cityToSearchFor = "München";

            //Act
            var actualResult = systemUnderTest.FindAvailableCarsForRental(customerOfTypeConsumerDoSearch, requestedReservationStart, requestedReservationEnd, cityToSearchFor)
                                              .Where(availableCar => availableCar.Key.Category == CarModel.Luxury).Select(result => result.Value);

            //Assert
            var expectedResult = 1440.0m;
            foreach (var price in actualResult) { Assert.True(price == expectedResult); }
        }


        [Fact]
        public void NewCustomerIs_Created()
        {
            //Arrange
            var systemUnderTest = new CarRentalBusinessLayer();
            var customerToBeCreated = _autoFixture.Build<Customer>().Without(property => property.CustomerId).With(property => property.CustomerType, Customer.Consumer).With(property => property.LastName, customerLastName)
                                                  .Create();
            var expectedResult = customerToBeCreated;
            var customer = new Customer();
            //Act
            systemUnderTest.CreateNewCustomer(customerToBeCreated);

            //Assert
            Customer actualResult;
            using (var carRentalDbContext = new CarRentalDbContext()) { actualResult = carRentalDbContext.Customers.SingleOrDefault(c => c.LastName == customerLastName); }
            Assert.True(actualResult != null && expectedResult.LastName == actualResult.LastName);
        }
    }
}