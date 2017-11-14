using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppStudenciINF.Models
{
    public class Student
    {
        public int ID { get; set; }             //ID.
        [Required]
        public string Name { get; set; }        //Imię.
        [Required]
        public string LastName { get; set; }    //Nazwisko.
        [Required]
        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}"), DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }   //Data urodzenia.
        [Required]
        public string SID { get; set; }         //Identyfikator studenta (Student ID).
        [Required]
        public string Course { get; set; }      //Kierunek.
        [Required]
        public string GroupName { get; set; }   //Nazwa grupy.
        [Required]
        public string Specialty { get; set; }   //Specjalność.
    }
}