using School.DataAccess.Contracts;

namespace School.DataAccess.UnitOfWorks
{
    public interface IUnitOfWiork
    {
        IStudentRepository StudentRepository { get; }

        ICourseRepository CourseRepository { get; }

        IEnrollmentRepository EnrollmentRepository { get; }

        void Save();
    }
}
