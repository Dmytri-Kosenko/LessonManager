using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public record DataManager(IStudentsRep StudentsRep, ICoursesRep CoursesRep);
    
}
