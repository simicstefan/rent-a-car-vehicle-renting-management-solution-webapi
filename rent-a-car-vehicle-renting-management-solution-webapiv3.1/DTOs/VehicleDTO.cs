using System;
using System.ComponentModel.DataAnnotations;

namespace rent_a_car_vehicle_renting_management_solution_webapi
{
    public class VehicleDTO
    {
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

    public class VehicleCreateDTO
    {
        [Required]
        public string RegistrationNumber { get; set; }
        [Required]
        public int IDManufacturer { get; set; }
        [Required]
        public int IDModel { get; set; }
        [Required]
        public int IDTransmission { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int Volume { get; set; }
        [Required]
        public int HorsePower { get; set; }
        [Required]
        public DateTime ManufactureYear { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
        [Required]
        public int Mileage { get; set; }
    }

    public class VehicleUpdateDTO
    {
        [Required]
        public int IDVehicle { get; set; }
        [Required]
        public string RegistrationNumber { get; set; }
        [Required]
        public int IDManufacturer { get; set; }
        [Required]
        public int IDModel { get; set; }
        [Required]
        public int IDTransmission { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int Volume { get; set; }
        [Required]
        public int HorsePower { get; set; }
        [Required]
        public DateTime ManufactureYear { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
        [Required]
        public int Mileage { get; set; }
    }
}