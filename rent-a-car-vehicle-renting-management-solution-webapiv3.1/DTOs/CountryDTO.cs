using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace rent_a_car_vehicle_renting_management_solution_webapi.DTOs
{
    public class CountryDTO
    {
        [Required]
        public int IDCountry { get; set; }
        [Required]
        public string CountryName { get; set; }
    }

    public class CountryCreateDTO
    {
        [Required]
        public string CountryName { get; set; }
    }

    public class CountryUpdateDTO
    {
        [Required]
        public int IDCountry { get; set; }
        [Required]
        public string CountryName { get; set; }
    }
}
