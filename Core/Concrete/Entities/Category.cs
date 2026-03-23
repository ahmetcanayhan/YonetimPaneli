using Core.Abstracts.Bases;
using System.Collections.Generic;

namespace Core.Concrete.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
