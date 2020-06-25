namespace Lab8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Coach
    {
        
        public Coach()
        {
            Teams = new HashSet<Team>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        
        public virtual ICollection<Team> Teams { get; set; }
    }
}
