using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rent_a_car_vehicle_renting_management_solution_webapi.Data
{
    [Table("City")]
    public partial class City
    {
        [Key]
        public int IDCity { get; set; }
        public int IDCountry { get; set; }
        public string CityName { get; set; }
        public string ZIPCode { get; set; }
    }
}
