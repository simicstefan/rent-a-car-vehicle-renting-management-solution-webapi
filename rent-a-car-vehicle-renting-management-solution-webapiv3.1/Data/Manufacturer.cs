using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rent_a_car_vehicle_renting_management_solution_webapi
{
    [Table("Manufacturer")]
    public partial class Manufacturer
    {
        [Key]
        public int IDManufacturer { get; set; }
        public string ManufacturerName { get; set; }
    }
}