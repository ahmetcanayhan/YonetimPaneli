using Data.Contexts;

using Core.Abstracts;
using Core.Abstracts.IRepositories;
using Data.Repositories;
using System;
using Core.Abstracts.IServices;
namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }
        private IPostRepository postRepository;
        public IPostRepository PostRepository => postRepository = postRepository ?? new PostRepository(context);

        private ITagRepository tagRepository;
        public ITagRepository TagRepository => tagRepository = tagRepository ?? new TagRepository(context);
        private IProjectRepository projectRepository;
        public IProjectRepository ProjectRepository => projectRepository = projectRepository ?? new ProjectRepository(context);
        private ICategoryRepository categoryRepository;
        public ICategoryRepository CategoryRepository => categoryRepository = categoryRepository ?? new CategoryRepository(context);

        public void Commit()
        {
           try
            {
                context.SaveChanges();
            }
            catch (Exception ex) 
            {
                context.Dispose();
                throw ex;
            }
        }

        public void Dispose()
        {
           context.Dispose();
        }
    }
}
