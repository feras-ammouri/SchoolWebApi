using System;

namespace School.DataAccess.Entities
{
    public class Student : IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Genders Gender { get; set; }
    }
}
