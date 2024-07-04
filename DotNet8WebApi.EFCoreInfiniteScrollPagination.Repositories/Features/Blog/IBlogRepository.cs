namespace DotNet8WebApi.EFCoreInfiniteScrollPagination.Repositories.Features.Blog;

public interface IBlogRepository
{
    Task<Result<BlogListResponseModel>> GetBlogs(int id, int pageSize);
}
