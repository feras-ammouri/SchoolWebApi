using School.DataAccess.Contracts;
using School.DataAccess.Transactions;
using System.Data;

namespace School.DataAccess.UnitOfWorks
{
    public interface IUnitOfWork
    {
        ITransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Snapshot);

        IStudentRepository StudentRepository { get; }

        ICourseRepository CourseRepository { get; }

        IEnrollmentRepository EnrollmentRepository { get; }

        void Save();

        void Dispose();
    }
}
