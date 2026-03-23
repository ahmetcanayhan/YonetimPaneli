using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Concrete.DTOs
{
    public class NewProjectDto
    {
        [Required]
        public string Title { get; set; }
        [DataType (DataType.MultilineText)]
        public string Description { get; set; }
        [Display (Name = "Git Repository Url")]
        public string GitUrl { get; set; } = string.Empty;
        [Display (Name = "Demostration Url")]
        public string DemoUrl { get; set; } = string.Empty;
        [Required, Display(Name = "Category")]
        public int CategoryId { get; set; }
        public DateTime? PublishDate { get; set; }
    }
    public class UpdateProjectDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Git Repository Url")]
        public string GitUrl { get; set; } = string.Empty;
        [Display(Name = "Demostration Url")]
        public string DemoUrl { get; set; } = string.Empty;
        [Required, Display(Name = "Category")]
        public int CategoryId { get; set; }
        public DateTime? PublishDate { get; set; }
        [Display (Name = "Is Draft")]
        public bool IsDraft { get; set; }
    }
}
