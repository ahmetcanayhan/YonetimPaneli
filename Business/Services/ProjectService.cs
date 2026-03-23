using Core.Abstracts;
using Core.Abstracts.IRepositories;
using Core.Abstracts.IServices;
using Core.Concrete.DTOs;
using Core.Concrete.Entities;
using Data;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext context = ApplicationDbContext.Create();
        private readonly IUnitOfWork unitOfWork;

        public ProjectService()
        {
            unitOfWork = new UnitOfWork(context);
        }

        public void DeleteProject(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProjectDto> GetAllProjects()
        {
            return from p in unitOfWork.ProjectRepository.ReadMany(null, "Category")
                   select new ProjectDto
                   {
                       Id = p.Id,
                       Title = p.Title,
                       Description = p.Description,
                       CategoryId = p.CategoryId,
                       DemoUrl = p.DemoUrl,
                       GitUrl = p.GitUrl,
                       IsDraft = !p.Active,
                       PublishDate = p.PublishDate,
                       CategoryName = p.Category.Name
                   };
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            return unitOfWork.CategoryRepository.ReadMany().Select(c => new CategoryDto { Id = c.Id, Name = c.Name }); // Yukarıdaki yapı bu şekildede yapılabilir.
        }

        public ProjectDto GetProjectById(int id)
        {
            var p = unitOfWork.ProjectRepository.ReadById(id);
            return new ProjectDto
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                CategoryId = p.CategoryId,
                DemoUrl = p.DemoUrl,
                GitUrl = p.GitUrl,
                IsDraft = !p.Active,
                PublishDate = p.PublishDate,
                CategoryName = p.Category.Name
            };
        }

        public IEnumerable<ProjectDto> GetProjectsByCategory(int categoryId)
        {
            return from p in unitOfWork.ProjectRepository.ReadMany(x => x.CategoryId == categoryId, "Category")
                   select new ProjectDto
                   {
                       Id = p.Id,
                       Title = p.Title,
                       Description = p.Description,
                       CategoryId = p.CategoryId,
                       DemoUrl = p.DemoUrl,
                       GitUrl = p.GitUrl,
                       IsDraft = !p.Active,
                       PublishDate = p.PublishDate,
                       CategoryName = p.Category.Name
                   };
        }

        public void NewProject(NewProjectDto model)
        {
            var project = new Project
            {
                Title = model.Title,
                Description = model.Description,
                GitUrl = model.GitUrl,
                DemoUrl = model.DemoUrl,
                CategoryId = model.CategoryId,
                PublishDate = model.PublishDate,
                CreatedAt = DateTime.UtcNow
            };
        }

        public void UpdateProject(UpdateProjectDto model)
        {
            var p = unitOfWork.ProjectRepository.ReadById(model.Id);
            if (p != null)
            {
                p.Title = model.Title;
                p.Description = model.Description;
                p.CategoryId = model.CategoryId;
                p.DemoUrl = model.DemoUrl;
                p.GitUrl = model.GitUrl;
                p.PublishDate = DateTime.Now;
                p.Active = !model.IsDraft;
                unitOfWork.ProjectRepository.Update(p);
                unitOfWork.Commit();
            }
        }
    }
}
