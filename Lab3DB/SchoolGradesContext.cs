using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Lab3DB
{
    public class SchoolGradesContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SchoolGrades;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>().HasNoKey();
            modelBuilder.Entity<Grade>()
       .HasOne(g => g.Teacher)
       .WithMany()
       .HasForeignKey(g => g.TeacherID_FK);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany()
                .HasForeignKey(g => g.StudentID_FK);
        }
    }

    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string EmployeeRole { get; set; }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Class { get; set; }
    }

    public class Grade
    {
        public string CourseName { get; set; }
        public string? Grade1 { get; set; }
        public int TeacherID_FK { get; set; }
        public DateTime GradeDate { get; set; }
        public int StudentID_FK { get; set; }

        public virtual Employee Teacher { get; set; }
        public virtual Student Student { get; set; }
    }
}
