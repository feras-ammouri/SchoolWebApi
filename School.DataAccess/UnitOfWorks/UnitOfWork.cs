using System;
using System.Collections.Generic;
using System.Text;
using School.DataAccess.Contracts;
using School.DataAccess.Repositories;

namespace School.DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWiork
    {
        #region ' variables and properties '

        private SchoolContext _schoolContext;

        private IStudentRepository _studentRepository;

        private ICourseRepository _courseRepository;

        private IEnrollmentRepository _enrollmentRepository;

        public IStudentRepository StudentRepository
        {
            get
            {
                if (_studentRepository == null)
                {
                    _studentRepository = new StudentRepository(_schoolContext);
                }

                return _studentRepository;
            }
        }

        public ICourseRepository CourseRepository
        {
            get
            {
                if (_courseRepository == null)
                {
                    _courseRepository = new CourseRepository(_schoolContext);
                }

                return _courseRepository;
            }
        }

        public IEnrollmentRepository EnrollmentRepository
        {
            get
            {
                if (_enrollmentRepository == null)
                {
                    _enrollmentRepository = new EnrollmentRepository(_schoolContext);
                }

                return _enrollmentRepository;
            }
        }

        #endregion

        #region ' methods '

        public UnitOfWork(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        /// <inheritdoc <see cref="IUnitOfWiork"/>
        public void Save()
        {
            _schoolContext.SaveChanges();
        }

        #endregion
    }
}
