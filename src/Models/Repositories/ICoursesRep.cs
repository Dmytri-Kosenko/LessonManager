using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public interface ICoursesRep
    {
        IQueryable<Course> Items { get; }
        void Add(Course course);
        void Delete(Guid id);
        void Rename(Course course, string Name);
        Course? GetCourseById(Guid id);
        

    }
}
