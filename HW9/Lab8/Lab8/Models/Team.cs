namespace Lab8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Team
    {
        
        public Team()
        {
            Athletes = new HashSet<Athlete>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int CID { get; set; }

       
        public virtual ICollection<Athlete> Athletes { get; set; }

        public virtual Coach Coach { get; set; }
    }
}
