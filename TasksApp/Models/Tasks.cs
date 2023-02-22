using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TasksApp.Models
{
    public class Tasks
    {
        [Key]
        [Required]
        public int TaskID { get; set; }
        [Required]
        public string TaskName { get; set; }
        public DateTime DueDate { get; set; } //need use String.Format("{0:MM/dd/yyyy}", dt); "03/09/2008"
        [Required]
        public int Quadrant { get; set; }
        public bool Completed { get; set; }
        //Build Foreign Key Relationship:
        [Required]
        public int CategoryID { get; set; }//Q*******I think this needs to be required but pls confirm****
        public Category Category { get; set; } //declare Category type named "Category"

    }
}
