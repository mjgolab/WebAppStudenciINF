using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppStudenciINF.Models
{
    public class StudentDetailsDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}"), DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string SID { get; set; }
        public string Course { get; set; }
        public string GroupName { get; set; }
        public string Specialty { get; set; }
    }
}