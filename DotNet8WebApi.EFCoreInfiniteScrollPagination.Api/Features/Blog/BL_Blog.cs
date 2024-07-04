using DotNet8WebApi.EFCoreInfiniteScrollPagination.Models.Features.Blog;
using DotNet8WebApi.EFCoreInfiniteScrollPagination.Models.Features;
using DotNet8WebApi.EFCoreInfiniteScrollPagination.Repositories.Features.Blog;
using Microsoft.AspNetCore.Http.HttpResults;
using DotNet8WebApi.EFCoreInfiniteScrollPagination.Models.Resources;

namespace DotNet8WebApi.EFCoreInfiniteScrollPagination.Api.Features.Blog
{
    public class BL_Blog
    {
        private readonly IBlogRepository _blogRepository;

        public BL_Blog(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<Result<BlogListResponseModel>> GetBlogs(int id, int pageSize)
        {
            Result<BlogListResponseModel> responseModel;
            try
            {
                if (id <= 0)
                {
                    responseModel = Result<BlogListResponseModel>.FailureResult(MessageResource.InvalidId);
                    goto result;
                }

                if (pageSize <= 0)
                {
                    responseModel = Result<BlogListResponseModel>.FailureResult(MessageResource.InvalidPageSize);
                    goto result;
                }

                responseModel = await _blogRepository.GetBlogs(id, pageSize);
            }
            catch (Exception ex)
            {
                responseModel = Result<BlogListResponseModel>.FailureResult(ex);
            }

        result:
            return responseModel;
        }
    }
}
