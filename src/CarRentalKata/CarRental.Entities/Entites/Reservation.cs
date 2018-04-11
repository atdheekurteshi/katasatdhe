using System;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;

namespace CarRental.Entities
{
    public class Reservation
    {
        /// <summary>
        /// ReservationId get,set declaration
        /// </summary>
        public int ReservationId { get; set; }
        /// <summary>
        /// CarId get,set declaration
        /// </summary>
        public int CarId { get; set; }
        /// <summary>
        /// Car get,set declaration
        /// </summary>
        public Car Car { get; set; }
        /// <summary>
        /// CustomerId get,set declaration
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Customer get,set declaration
        /// </summary>
        public Customer Customer { get; set; }
        /// <summary>
        /// InvoiceId get,set declaration
        /// </summary>
        public int? InvoiceId { get; set; }
        /// <summary>
        /// Invoice get,set declaration
        /// </summary>
        public Invoice Invoice { get; set; }
        /// <summary>
        /// ReservationStart get,set declaration
        /// </summary>
        public DateTime ReservationStart { get; set; }
        /// <summary>
        /// ReservationEnd get,set declaration
        /// </summary>
        public DateTime ReservationEnd { get; set; }
    }
}