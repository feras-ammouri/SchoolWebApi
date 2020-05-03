using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using School.DataAccess.Entities;
using School.DataAccess.UnitOfWorks;

namespace School.Services
{
    public class StudentService : IStudentService
    {
        #region ' variables and properties '

        private IUnitOfWork _unitOfWork;

        public Guid Id { get; set; }

        #endregion

        #region ' methods '

        /// <summary>
        /// Constructor, initializes an instance of <see cref="StudentService"/>
        /// </summary>
        /// <param name="unitOfWiork"></param>
        public StudentService(IUnitOfWork unitOfWiork)
        {
            Id = Guid.NewGuid();
            this._unitOfWork = unitOfWiork ?? throw new ArgumentException("unitOfWiork must not be null or empty");
        }

        /// <inheritdoc cref="IStudentService"/>
        public Task AddNewStudent(Student student)
        {
            return Task.Run(() => this._unitOfWork.StudentRepository.Create(student));
        }

        /// <inheritdoc cref="IStudentService"/>
        public Task UpdateStudent(Student student)
        {
            return Task.Run(() => this._unitOfWork.StudentRepository.Update(student));
        }

        /// <inheritdoc cref="IStudentService"/>
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

        /// <inheritdoc cref="IStudentService"/>
        public Task<IEnumerable<Student>> GetAllStudents()
        {
            return Task.Run(() => this._unitOfWork.StudentRepository.GetAll());
        }

        /// <inheritdoc cref="IStudentService"/>
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
