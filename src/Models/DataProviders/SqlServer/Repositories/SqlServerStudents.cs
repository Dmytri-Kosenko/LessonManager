using Models.DataProviders.SqlServer;
using Models.Entities;
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataProviders.Repositories
{
    public class SqlServerStudents : IStudentsRep
    {
        public IQueryable<Student> Items 
        { 
            get
            {
                using var context = new SqlSerDbContext();
                return context.Students;
            } 
        }
        public void Delete(Guid id)
        {
            using var context = new SqlSerDbContext();
            var result = context.Students.FirstOrDefault(s => s.Id == id);
            if (result == default) return;
            context.Remove(result);
            context.SaveChanges();
        }

        public Student? GetStudentById(Guid id)
        {
            using var context = new SqlSerDbContext();
            return context.Students.FirstOrDefault(s => s.Id == id);
        }

        public void SetCourse(Student student, Course course)
        {
            using var context = new SqlSerDbContext();
            if (student.Courses.Contains(course)) return;
            if (context.Courses.Contains(course)) 
            { 
                student.Courses.Add(course);
                context.SaveChanges();
                return;
            }
            throw new ArgumentException("Курс не создан");
        }

        public void Rename(Student student,string name)
        {
            using var context = new SqlSerDbContext();
            var result = context.Students.FirstOrDefault(s => s.Id == student.Id);
            if(result == null) throw new ArgumentException("Такого студента не существует");
            if (student.Name != name)
            {
                student.Name = name;
                context.Update(student);
                context.SaveChanges();
            }
        }

    }
}
