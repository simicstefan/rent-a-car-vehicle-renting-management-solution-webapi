using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rent_a_car_vehicle_renting_management_solution_webapi.Data
{
    [Table("Client")]
    public partial class Client
    {
        [Key]
        public int IDClient { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string JMBG { get; set; }
        public string PassportNumber { get; set; }
        public string DrivingLicenseNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int IDCity { get; set; }
        public string EmailAddress { get; set; }
    }
}
