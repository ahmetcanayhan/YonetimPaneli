using Core.Abstracts.IRepositories;
using Core.Abstracts.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository PostRepository { get; }
        ITagRepository TagRepository { get; }
        IProjectRepository ProjectRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        void Commit();
    }
}
