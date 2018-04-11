namespace CarRental.Entities
{
    public class Car
    {
        /// <summary>
        /// Small variable declaration
        /// </summary>
        public const string Small = "A";
        /// <summary>
        /// Medium variable declaration
        /// </summary>
        public const string Medium = "B";
        /// <summary>
        /// Large variable declaration
        /// </summary>
        public const string Large = "C";
        /// <summary>
        /// Luxury variable declaration
        /// </summary>
        public const string Luxury = "D";
        /// <summary>
        /// CarId get set declaration
        /// </summary>
        public int CarId { get; set; }
        /// <summary>
        /// CarBrand get set declaration
        /// </summary>
        public string CarBrand { get; set; }
        /// <summary>
        /// LicenceNumber get set declaration
        /// </summary>
        public string LicenceNumber { get; set; }
        /// <summary>
        /// KilometerReading get set declaration
        /// </summary>
        public float KilometerReading { get; set; }
        /// <summary>
        /// Category get set declaration
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Office get set declaration
        /// </summary>
        public Office Office { get; set; }
        /// <summary>
        /// OfficeId get set declaration
        /// </summary>
        public int OfficeId { get; set; }

        //public void AddKilometers(float kilometersDriven)
        //{
        //    KilometerReading += kilometersDriven;
        //}

    }
}