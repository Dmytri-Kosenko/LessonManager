using Models.Entities;
using Models.Repositories;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Models.DataProviders.SqlServer.Repositories
{
    public class SqlServerStudents : IStudentsRep
    {
        private readonly SqlSerDbContext context;

        public SqlServerStudents(SqlSerDbContext context) => this.context = context;

        public IQueryable<Student> Items => context.Students.Include(s => s.Courses);

        public void Delete(Guid id)
        {
            var result = context.Students.FirstOrDefault(s => s.Id == id);
            if (result == default) return;
            var courses = context.Courses.Where(s => s.Students.Contains(result));
            foreach (var item in courses)
            {
                item.Students.Remove(result);
            }

            context.Remove(result);
            context.SaveChanges();
        }

        public Student? GetStudentById(Guid id) =>
            context.Students.FirstOrDefault(s => s.Id == id);

        public void SetCourse(Student student, Course course)
        {
            if (!context.Courses.Contains(course)) throw new ArgumentException("Курс не создан");
            if (student.Courses.Contains(course)) return;
            student.Courses.Add(course);
            context.SaveChanges();
        }

        public void Rename(Student student, string name)
        {
            var result = context.Students.FirstOrDefault(s => s.Id == student.Id);
            if(result == null) throw new ArgumentException("Такого студента не существует");
            if (student.Name != name)
            {
                student.Name = name;
                context.Update(student);
                context.SaveChanges();
            }
        }

        public void Add(Student student)
        {
            if (student.Id == default)
            {
                //student.Id = Guid.NewGuid();
                context.Add(student);
                context.SaveChanges();
                return;
            }
            if (context.Students.FirstOrDefault(s => s.Id == student.Id) is not null) 
                throw new ArgumentException();
            context.Add(student);
            context.SaveChanges();
        }
    }
}
