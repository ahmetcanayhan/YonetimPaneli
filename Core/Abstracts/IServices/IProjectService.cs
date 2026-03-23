using Core.Concrete.DTOs;
using Core.Concrete.Entities;
using System.Collections.Generic;

namespace Core.Abstracts.IServices
{
    public interface IProjectService
    {
        IEnumerable<ProjectDto> GetAllProjects();
        IEnumerable<ProjectDto> GetProjectsByCategory(int categoryId);

        ProjectDto GetProjectById(int id);
        IEnumerable<CategoryDto> GetCategories();
        void NewProject(NewProjectDto model);
        void DeleteProject(int id);
        void UpdateProject(UpdateProjectDto model);
    }
}
