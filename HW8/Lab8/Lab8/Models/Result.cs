namespace Lab8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Result
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string RaceTime { get; set; }

        public int AID { get; set; }

        public int EID { get; set; }

        public int LID { get; set; }

        public virtual Athlete Athlete { get; set; }

        public virtual Event Event { get; set; }

        public virtual LocationDetail LocationDetail { get; set; }
    }
}
