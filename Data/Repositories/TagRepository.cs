using Core.Abstracts.IRepositories;
using Core.Concrete.Entities;
using Data.Contexts;
using Utils.Wrappers;

namespace Data.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
