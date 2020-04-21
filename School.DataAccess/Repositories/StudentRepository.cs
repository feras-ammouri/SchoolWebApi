using School.DataAccess.Contracts;
using School.DataAccess.Entities;

namespace School.DataAccess.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        /// <summary>
        /// Constructor, initializes an instance of <see cref="StudentRepository"/>
        /// </summary>
        /// <param name="schoolContext"></param>

        public StudentRepository(SchoolContext schoolContext)
            :base(schoolContext)
        {
        }
    }
}