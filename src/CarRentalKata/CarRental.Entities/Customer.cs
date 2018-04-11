using System;
using System.Collections.Generic;

namespace CarRental.Entities
{
    public class Customer
    {
        /// <summary>
        /// Consumer variable declaration
        /// </summary>
        public const int Consumer = 1;
        /// <summary>
        /// ConsumerPremium variable declaration
        /// </summary>
        public const int ConsumerPremium = 2;
        /// <summary>
        /// Business variable declaration
        /// </summary>
        public const int Business = 3;
        /// <summary>
        /// BusinessPremium variable declaration
        /// </summary>
        public const int BusinessPremium = 4;
        /// <summary>
        /// CustomerId get set declaration
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// CustomerNumber get set declaration
        /// </summary>
        public string CustomerNumber { get; set; }
        /// <summary>
        /// FirstName get set declaration
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// LastName get set declaration
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// DateOfBirth get set declaration
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// CustomerType get set declaration
        /// </summary>
        public int CustomerType { get; set; }
        /// <summary>
        /// Street get set declaration
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// City get set declaration
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Postcode get set declaration
        /// </summary>
        public string Postcode { get; set; }
    }
}