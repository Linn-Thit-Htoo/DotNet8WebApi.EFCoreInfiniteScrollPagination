namespace DotNet8WebApi.EFCoreInfiniteScrollPagination.Repositories.Features.Blog;

public class BlogRepository : IBlogRepository
{
    private readonly AppDbContext _appDbContext;

    public BlogRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Result<BlogListResponseModel>> GetBlogs(int id, int pageSize)
    {
        Result<BlogListResponseModel> responseModel;
        try
        {
            var query = _appDbContext
                .TblBlogs.Where(x => x.BlogId > id)
                .OrderByDescending(x => x.BlogId);

            var lst = await query.Take(pageSize).ToListAsync();

            var model = new BlogListResponseModel(lst.Select(x => x.Map()).ToList());

            responseModel = Result<BlogListResponseModel>.SuccessResult(model);
        }
        catch (Exception ex)
        {
            responseModel = Result<BlogListResponseModel>.FailureResult(ex);
        }

        return responseModel;
    }
}
