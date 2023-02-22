using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksApp.Models
{
    public class TasksDatabaseContext : DbContext
    {
        //Constructor
        public TasksDatabaseContext(DbContextOptions<TasksDatabaseContext> options) : base(options)
        {
            //Call constructor. Leave blank for now. This also calls the overall DbContext file
        }

        //create a database set for each of the two models
        public DbSet<Tasks> Responses { get; set; }
        public DbSet<Category> Categories{ get; set;}

        //seed data below here
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData( //make sure there isn't already data as add this in
                new Category { CategoryID = 1, CategoryName = "Home" },
                new Category { CategoryID = 2, CategoryName = "School" },
                new Category { CategoryID = 3, CategoryName = "Work" },
                new Category { CategoryID = 4, CategoryName = "Church" }
                );
            mb.Entity<Tasks>().HasData(
                new Tasks
                {
                    TaskID = 1,
                    TaskName = "Do the Dishes",
                    DueDate = new DateTime(2023, 3, 13), //March 13th, 2023; time is 12am; to display, need to use .String.Format("{0:MM/dd/yyyy}", dt);  "03/09/2008"
                    Quadrant = 2, 
                    Completed = false,
                    CategoryID = 1, //home category
                },
                new Tasks
                {
                    TaskID = 2,
                    TaskName = "Study for Security Test",
                    DueDate = new DateTime(2023, 2, 26),
                    Quadrant = 1,
                    Completed = false,
                    CategoryID = 2, //school category
                }
                );

        }

    }
}
