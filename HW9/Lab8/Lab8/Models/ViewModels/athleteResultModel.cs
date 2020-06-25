using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab8.Models.ViewModels
{
    public class athleteResultModel
    {
        [Required]
        [StringLength(50)]
        public string eventName { get; set; }


        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime eventDate { get; set; }

        [Required]
        [StringLength(50)]
        public string eventLocation { get; set; }

        
        [Required]
        [StringLength(50)]
        public string athleteResult { get; set; }
        
        


    }
}