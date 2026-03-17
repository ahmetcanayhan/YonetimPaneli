using Core.Abstracts.IRepositories;
using Core.Concrete.Entities;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Wrappers;

namespace Data.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
