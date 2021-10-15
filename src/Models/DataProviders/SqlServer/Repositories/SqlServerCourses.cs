using Models.DataProviders.SqlServer;
using Models.Entities;
using Models.Repositories;
using System;
using System.Linq;

namespace Models.DataProviders.Repositories
{
    public class SqlServerCourses : ICoursesRep
    {
        public IQueryable<Course> Items
        {
            get
            {
                using var context = new SqlSerDbContext();
                return context.Courses;
            }
        }
        public void Delete(Guid id)
        {
            using var context = new SqlSerDbContext();
            var result = context.Courses.FirstOrDefault(s => s.Id == id);
            if (result == default) return;
            context.Remove(result);
            context.SaveChanges();
        }

        public Course? GetCourseById(Guid id)
        {
            using var context = new SqlSerDbContext();
            return context.Courses.FirstOrDefault(s => s.Id == id);
        }
               
        public void Rename(Course course, string name)
        {
            using var context = new SqlSerDbContext();
            var result = context.Courses.FirstOrDefault(s => s.Id == course.Id);
            if (result == null) throw new ArgumentException("Такого курса не существует");
            if (course.Name != name)
            {
                course.Name = name;
                context.Update(course);
                context.SaveChanges();
            }
        }
    }
}
