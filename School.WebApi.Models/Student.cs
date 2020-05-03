using System;

namespace School.WebApi.Models
{
    public class Student : IModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //public DateTime DateOfBirth { get; set; }

       // public Genders Gender { get; set; }
    }
}
