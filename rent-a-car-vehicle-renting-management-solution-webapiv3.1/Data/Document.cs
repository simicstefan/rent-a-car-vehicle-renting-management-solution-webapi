using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rent_a_car_vehicle_renting_management_solution_webapi.Data
{
    [Table("Document")]
    public partial class Document
    {
        [Key]
        public int IDDocument { get; set; }
        public string DocumentName { get; set; }
        public string Extension { get; set; }
        public int IDClient { get; set; }
        public DateTime DateTime_insert { get; set; }
        public DateTime DateTime_update { get; set; }
    }
}
