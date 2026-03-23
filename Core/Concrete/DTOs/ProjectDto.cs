using System;

namespace Core.Concrete.DTOs
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string GitUrl { get; set; } = string.Empty;
        public string DemoUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime? PublishDate { get; set; }
        public bool IsDraft { get; set; }
    }
}
