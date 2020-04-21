using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using School.DataAccess.Entities;

namespace School.DataAccess
{
    public class SchoolContext : DbContext
    {
        #region ' variables and properties '

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        #endregion

        #region ' methods '

        /// <summary>
        /// Constructor, initializes an instance of <see cref="SchoolContext"/>
        /// </summary>
        /// <param name="dbContextOptions"></param>
        public SchoolContext(DbContextOptions dbContextOptions) : 
            base(dbContextOptions)
        {

        } 

        #endregion
    }
}
