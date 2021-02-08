using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rent_a_car_vehicle_renting_management_solution_webapi
{
    [Table("HirePoint")]
    public partial class HirePoint
    {
        [Key]
        public int IDHirePoint { get; set; }
        public string HirePointName { get; set; }
        public string Address { get; set; }
        public int IDCity { get; set; }
    }
}