using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rent_a_car_vehicle_renting_management_solution_webapi.DTOs
{
    public class DocumentDTO
    {
        public int IDDocument { get; set; }
        public string DocumentName { get; set; }
        public string Extension { get; set; }
        public int IDClient { get; set; }
        public DateTime DateTime_insert { get; set; }
        public DateTime DateTime_update { get; set; }
    }

    public class DocumentCreateDTO
    {
        public string DocumentName { get; set; }
        public string Extension { get; set; }
        public int IDClient { get; set; }
        public DateTime DateTime_insert { get; set; }
        public DateTime DateTime_update { get; set; }
    }

    public class DocumentUpdateDTO
    {
        public int IDDocument { get; set; }
        public string DocumentName { get; set; }
        public string Extension { get; set; }
        public int IDClient { get; set; }
        public DateTime DateTime_insert { get; set; }
        public DateTime DateTime_update { get; set; }
    }
}
