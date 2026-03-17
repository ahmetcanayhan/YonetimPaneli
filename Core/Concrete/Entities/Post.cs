using Core.Abstracts.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrete.Entities
{
    public class Post:BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string CoverImageUrl { get; set; }
        [ForeignKey("Author")]
        public string AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public DateTime PublishDate { get; set; }
        public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
        
    }
}
