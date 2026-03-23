using Core.Abstracts.Bases;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrete.Entities
{
    public class Project : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string GitUrl { get; set; } = string.Empty;
        public string DemoUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public DateTime? PublishDate { get; set; }
    }
}
