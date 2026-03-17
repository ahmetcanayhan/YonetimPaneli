using Core.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.IServices
{
    public interface IPostService
    {
        IEnumerable<PostListItemDto> GetPostList();
        PostDetailDto GetPostDetail(int id);

        void CreatePost(NewPostDto newPost);
        void UpdatePost(UpdatePostDto newPost);
        void DeletePost(int id, string authorId);
    }
}
