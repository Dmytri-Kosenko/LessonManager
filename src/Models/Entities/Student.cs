using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Student : EntityBase
    {
        public virtual IList<Course> Courses { get; set; } = new List<Course>();
    }
}
