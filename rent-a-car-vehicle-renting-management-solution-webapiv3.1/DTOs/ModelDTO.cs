using System;
using System.ComponentModel.DataAnnotations;

namespace rent_a_car_vehicle_renting_management_solution_webapi
{
    public class ModelDTO
    {
        public int IDModel { get; set; }
        public int IDManufacturer { get; set; }
        public string ModelName { get; set; }

    }

    public class ModelCreateDTO
    {
        [Required]
        public int IDManufacturer { get; set; }
        [Required]
        public string ModelName { get; set; }

    }

    public class ModelUpdateDTO
    {
        [Required]
        public int IDModel { get; set; }
        [Required]
        public int IDManufacturer { get; set; }
        [Required]
        public string ModelName { get; set; }

    }
}