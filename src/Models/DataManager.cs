using Models.Repositories;

namespace Models
{
    public record DataManager(IStudentsRep StudentsRep, ICoursesRep CoursesRep);
    
}
