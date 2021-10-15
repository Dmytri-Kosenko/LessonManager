using Models.DataProviders.SqlServer;
using Models.Entities;
using Models.Repositories;
using System;
using System.Linq;

namespace Models.DataProviders.Repositories
{
    public class SqlServerCourses : ICoursesRep
    {
        private readonly SqlSerDbContext context;

        public SqlServerCourses(SqlSerDbContext context) => this.context = context;

        public IQueryable<Course> Items => context.Courses;

        public void Add(Course course)
        {
            if(course.Id == default)
            {
                course.Id = Guid.NewGuid();
                context.Add(course);
                context.SaveChanges();
                return;
            }
            var result = context.Courses.FirstOrDefault(s => s.Id == course.Id);
            if (result is not null) throw new ArgumentException("");
            context.Add(course);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var result = context.Courses.FirstOrDefault(s => s.Id == id);
            if (result == default) return;
            context.Remove(result);
            context.SaveChanges();
        }

        public Course? GetCourseById(Guid id) =>
            context.Courses.FirstOrDefault(s => s.Id == id);

        public void Rename(Course course, string name)
        {
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
