using School.DataAccess.Contracts;
using School.DataAccess.Entities;

namespace School.DataAccess.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        /// <summary>
        /// Constructor, initializes an instance of <see cref="CourseRepository"/>
        /// </summary>
        /// <param name="schoolContext"></param>
        public CourseRepository(SchoolDBContext schoolContext)
            :base(schoolContext)
        {
        }
    }
}