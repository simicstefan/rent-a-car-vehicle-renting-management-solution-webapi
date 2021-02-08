using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rent_a_car_vehicle_renting_management_solution_webapi
{
    [Table("Model")]
    public partial class Model
    {
        [Key]
        public int IDModel { get; set; }
        public int IDManufacturer { get; set; }
        public string ModelName { get; set; }
    }
}