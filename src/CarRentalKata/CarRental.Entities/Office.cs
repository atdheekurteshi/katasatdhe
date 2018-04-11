using System.Collections.Generic;

namespace CarRental.Entities
{
    public class Office
    {
        /// <summary>
        /// OfficeId get,set declaration
        /// </summary>
        public int OfficeId { get; set; }
        /// <summary>
        /// Street get,set declaration
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// City get,set declaration
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Postcode get,set declaration
        /// </summary>
        public string Postcode { get; set; }
        /// <summary>
        /// Country get,set declaration
        /// </summary>
        public string Country { get; set; }
    }
}