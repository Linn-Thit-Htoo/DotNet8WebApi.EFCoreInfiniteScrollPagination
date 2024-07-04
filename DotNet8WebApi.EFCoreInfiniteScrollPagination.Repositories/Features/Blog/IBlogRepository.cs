using DotNet8WebApi.EFCoreInfiniteScrollPagination.Models.Features;
using DotNet8WebApi.EFCoreInfiniteScrollPagination.Models.Features.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8WebApi.EFCoreInfiniteScrollPagination.Repositories.Features.Blog
{
    public interface IBlogRepository
    {
        Task<Result<BlogListResponseModel>> GetBlogs(int id, int pageSize);
    }
}
