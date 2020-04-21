using System;
using System.Collections.Generic;
using System.Text;
using School.DataAccess.Entities;

namespace School.DataAccess.Contracts
{
    public interface ICourseRepository : IRepository<Course> 
    {
    }
}
