using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using School.DataAccess.Entities;
using School.DataAccess.UnitOfWorks;

namespace School.Services
{
    public class StudentService : IStudentService
    {
        #region ' variables and properties '

        private IUnitOfWiork _unitOfWork;

        #endregion

        #region ' methods '

        public StudentService(IUnitOfWiork unitOfWiork)
        {
            this._unitOfWork = unitOfWiork ?? throw new ArgumentException("unitOfWiork must not be null or empty");
        }

        public Task AddNewStudent(Student student)
        {
            return Task.Run(() => this._unitOfWork.StudentRepository.Create(student));
        }


        public Task UpdateStudent(Student student)
        {
            return Task.Run(() => this._unitOfWork.StudentRepository.Update(student));
        }

        public Task DeleteStudent(int Id)
        {
            Expression<Func<Student, bool>> filter = x => x.Id.Equals(Id);

            Student student = this.getStudentsByFilter(filter)?.FirstOrDefault();

            if (student == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            return Task.Run(() => this._unitOfWork.StudentRepository.Delete(student));
        }

        public Task<IEnumerable<Student>> GetAllStudents()
        {
            return Task.Run(() => this._unitOfWork.StudentRepository.GetAll());
        }

        public Task<Student> GetStudentById(int Id)
        {
            Expression<Func<Student, bool>> filter = x => x.Id.Equals(Id);

            return Task.Run(() => this.getStudentsByFilter(filter)?.FirstOrDefault());
        }

        private IEnumerable<Student> getStudentsByFilter(Expression<Func<Student, bool>> filter)
        {
            return this._unitOfWork.StudentRepository.GetByFilter(filter);
        }

        #endregion
    }
}
