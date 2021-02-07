using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rent_a_car_vehicle_renting_management_solution_webapi.Data
{
    [Table("Country")]
    public class Country
    {
        [Key]
        public int IDCountry { get; set; }
        public string CountryName { get; set; }
    }
}
