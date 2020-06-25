using HomeworkHelp;
using System.Data.Entity;
using HomeworkHelp.Models; 

namespace HomeworkHelp.DAL
{
    // Class that gives us access to a DB
    public class HomeworkContext : DbContext
    {
        // Which database to connect to (details in web.config)
        public HomeworkContext() : base("name=HomeworkDB")
        {

        }

        // Access to our table
        public virtual DbSet<Homework> Homework { get; set; }
    }
}