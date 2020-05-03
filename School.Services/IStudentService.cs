using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using School.DataAccess.Entities;

namespace School.Services
{
    public interface IStudentService
    {
        Guid Id { get; set; }

        Task AddNewStudent(Student student);

        Task UpdateStudent(Student student);

        Task DeleteStudent(int Id);

        Task<IEnumerable<Student>> GetAllStudents();

        Task<Student> GetStudentById(int Id);   
    }
}
