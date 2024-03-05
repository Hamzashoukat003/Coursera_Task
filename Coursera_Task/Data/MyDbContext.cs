﻿using Coursera_Task.Controllers;
using Coursera_Task.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity.Infrastructure;

namespace Coursera_Task.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbQuery<Report> ReportResultsView { get; set; }
        public DbQuery<Report> Report { get; set; }
        public IList<Report> GetReport(string pinList, int? minimumCredit, DateTime? startDate, DateTime? endDate)
        {
            var parameters = new[]
            {
                new SqlParameter("@PinList", SqlDbType.NVarChar) { Value = pinList ?? (object)DBNull.Value },
                new SqlParameter("@MinimumCredit", SqlDbType.Int) { Value = minimumCredit ?? (object)DBNull.Value },
                new SqlParameter("@StartDate", SqlDbType.Date) { Value = startDate ?? (object)DBNull.Value },
                new SqlParameter("@EndDate", SqlDbType.Date) { Value = endDate ?? (object)DBNull.Value }
            };
            return new List<Report>();
        }
            //return Report.FromSqlRaw("EXEC [dbo].[GetReport] @PinList, @MinimumCredit, @StartDate, @EndDate", parameters).ToList();

        public DbSet<StudentCourseXref> StudentsCoursesXref { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Report>()
          .HasNoKey();
            modelBuilder.Entity<Report>().ToTable("Report");

            modelBuilder.Entity<Students>()
           .HasKey(s => s.PIN);
        

            modelBuilder.Entity<Students>()
           .Property(x => x.PIN)
           .ValueGeneratedOnAdd();

            modelBuilder.Entity<Students>()
           .Property(x => x.FirstName)
           .HasMaxLength(50);

            modelBuilder.Entity<Students>()
           .Property(x => x.LastName)
           .HasMaxLength(50);

            modelBuilder.Entity<StudentCourseXref>()
       .HasKey(x => new { x.ID });

          

            modelBuilder.Entity<Courses>()
           .Property(x => x.Name)
           .HasMaxLength(150);

            modelBuilder.Entity<Instructor>()
           .Property(x => x.FirstName)
           .HasMaxLength(100);
            modelBuilder.Entity<Instructor>()
           .Property(x => x.LastName)
           .HasMaxLength(100);
        }
    }
}