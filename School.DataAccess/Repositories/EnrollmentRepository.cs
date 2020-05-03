using School.DataAccess.Contracts;
using School.DataAccess.Entities;

namespace School.DataAccess.Repositories
{
    public class EnrollmentRepository : BaseRepository<Enrollment>, IEnrollmentRepository
    {
        /// <summary>
        /// Constructor, initializes an instance of <see cref="EnrollmentRepository"/>
        /// </summary>
        /// <param name="schoolContext"></param>

        public EnrollmentRepository(SchoolDBContext schoolContext)
            :base(schoolContext)
        {
        }
    }
}