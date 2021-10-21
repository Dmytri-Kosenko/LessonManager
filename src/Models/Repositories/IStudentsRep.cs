using Models.Entities;
using System;
using System.Linq;

namespace Models.Repositories
{
    public interface IStudentsRep
    {
        IQueryable<Student> Items { get; }
        void Add(Student student);
        void Delete(Guid id);
        void Rename(Student student, string Name);
        Student? GetStudentById(Guid id);
        void SetCourse(Student student, Course course);
        
    }
}
