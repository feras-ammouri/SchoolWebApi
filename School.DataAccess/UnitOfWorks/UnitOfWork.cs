using System.Data;
using Microsoft.EntityFrameworkCore;
using School.DataAccess.Contracts;
using School.DataAccess.Repositories;
using School.DataAccess.Transactions;

namespace School.DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        #region ' variables and properties '

        private SchoolDBContext _schoolContext;

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

        /// <summary>
        /// Constructor, initializes an instance of <see cref="UnitOfWork"/>
        /// </summary>
        /// <param name="schoolContext"></param>
        public UnitOfWork(SchoolDBContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        /// <inheritdoc <see cref="IUnitOfWork"/>
        public ITransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Snapshot)
        {
            return new DbTransaction(_schoolContext.Database.BeginTransaction(isolationLevel));
        }

        /// <inheritdoc <see cref="IUnitOfWork"/>
        public void Save()
        {
            _schoolContext.SaveChanges();
        }

        /// <inheritdoc <see cref="IUnitOfWork"/>
        public void Dispose()
        {
            _schoolContext = null;
        }

        #endregion
    }
}
