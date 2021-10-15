using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Course : EntityBase
    {

        public virtual IList<Student> Students { get; set; } = new List<Student>();
    }
}
