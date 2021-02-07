using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace rent_a_car_vehicle_renting_management_solution_webapi.DTOs
{
    public class CityDTO
    {
        public int IDCity { get; set; }
        public int IDCountry { get; set; }
        public string CityName { get; set; }
        public string ZIPCode { get; set; }
    }

    public class CityCreateDTO
    {
        [Required]
        public int IDCountry { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        public string ZIPCode { get; set; }
    }

    public class CityUpdateDTO
    {
        [Required]
        public int IDCity { get; set; }
        [Required]
        public int IDCountry { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        public string ZIPCode { get; set; }
    }
}
