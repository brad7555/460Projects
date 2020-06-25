using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeworkHelp.Models
{
    public class Homework
    {
        [Key]
        public int ID { get; set; }

        [Required, DisplayName("Priority")]
        [StringLength(64)] // Easy way of validation
        public string Priority { get; set; }

        [Required, DisplayName("Due Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }

        [Required]
        [DisplayName("Due Time")]
        [StringLength(128)] //Validation 
        public string Time { get; set; }

        [Required]
        [DisplayName("HwTitle")]
        [StringLength(128)] //Validation 
        public string Title { get; set; }

        [Required]
        [DisplayName("Department")]
        [StringLength(128)] //Validation 
        public string Department { get; set; }

        [Required]
        [DisplayName("Course #")]

        public int CourseID { get; set; }

        [Required]
        [DisplayName("Notes")]
        [StringLength(128)] //Validation 
        public string Notes { get; set; }





        public override string ToString()
        {
            return $"{base.ToString()}: {Date} {Time} {Title} {Department} {CourseID} {Notes} ";
        }
    }
}