using System.Collections.Generic;

namespace Models.Entities
{
    public class Course : EntityBase
    {

        public virtual IList<Student> Students { get; set; } = new List<Student>();
    }
}
