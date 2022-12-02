using AvMonitor.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AvMonitor.Data
{
    public class TaskDataContext : DbContext
    {
        public TaskDataContext(DbContextOptions<TaskDataContext> options)
            : base(options)
        {
            Console.WriteLine("DATABASE WAS INIT!!!");
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Console.WriteLine("DATABASE WAS CREATING!!!");
            /*modelBuilder.Entity<ResponseModel>().HasData(
                    new ResponseModel(System.Net.HttpStatusCode.OK, "asf"),
                    new ResponseModel(System.Net.HttpStatusCode.BadRequest, "aasf")

            );*/
        }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<ResponseModel> Rasponses { get; set; }


    }
}