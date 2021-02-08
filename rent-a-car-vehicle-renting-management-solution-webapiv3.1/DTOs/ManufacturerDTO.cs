using System;
using System.ComponentModel.DataAnnotations;

namespace rent_a_car_vehicle_renting_management_solution_webapi
{
    public class ManufacturerDTO
    {
        [Required]
        public int IDManufacturer { get; set; }
        [Required]
        public string ManufacturerName { get; set; }
    }

    public class ManufacturerCreateDTO
    {
        [Required]
        public string ManufacturerName { get; set; }
    }

    public class ManufacturerUpdateDTO
    {
        [Required]
        public int IDManufacturer { get; set; }
        [Required]
        public string ManufacturerName { get; set; }
    }
}