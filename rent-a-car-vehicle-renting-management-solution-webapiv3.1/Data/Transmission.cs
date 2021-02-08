using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rent_a_car_vehicle_renting_management_solution_webapi
{
    [Table("Transmission")]
    public partial class Transmission
    {
        [Key]
        public int IDTransmission { get; set; }
        public string TransmissionName { get; set; }
    }
}