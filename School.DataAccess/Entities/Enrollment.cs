using System;
using System.Collections.Generic;
using System.Text;

namespace School.DataAccess.Entities
{
    public class Enrollment : IEntity
    {
        public int Id { get; set; }

        public Student student { get; set; }

        public Course Course { get; set; }
    }
}
