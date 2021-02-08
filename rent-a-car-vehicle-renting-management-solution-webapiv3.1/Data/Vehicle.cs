using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rent_a_car_vehicle_renting_management_solution_webapi
{
    [Table("Vehicle")]
    public class Vehicle
    {
        [Key]
        public int IDVehicle { get; set; }
        public string RegistrationNumber { get; set; }
        public int IDManufacturer { get; set; }
        public int IDModel { get; set; }
        public int IDTransmission { get; set; }
        public string Color { get; set; }
        public int Volume { get; set; }
        public int HorsePower { get; set; }
        public DateTime ManufactureYear { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int Mileage { get; set; }
    }
}