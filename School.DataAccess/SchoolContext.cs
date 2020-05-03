using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using School.DataAccess.Entities;

namespace School.DataAccess
{
    public class SchoolDBContext : DbContext
    {
        #region ' variables and properties '

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        #endregion

        #region ' methods '

        public SchoolDBContext()
        {

        }

        /// <summary>
        /// Constructor, initializes an instance of <see cref="SchoolDBContext"/>
        /// </summary>
        /// <param name="dbContextOptions"></param>
        public SchoolDBContext(DbContextOptions<SchoolDBContext> dbContextOptions) : 
            base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        #endregion
    }
}
