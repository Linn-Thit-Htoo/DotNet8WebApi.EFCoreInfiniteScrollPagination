using DotNet8WebApi.EFCoreInfiniteScrollPagination.DbService.AppDbContexts;
using DotNet8WebApi.EFCoreInfiniteScrollPagination.Mapper;
using DotNet8WebApi.EFCoreInfiniteScrollPagination.Models.Features;
using DotNet8WebApi.EFCoreInfiniteScrollPagination.Models.Features.Blog;
using Microsoft.EntityFrameworkCore;

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
            var lst = await _appDbContext
                .TblBlogs.Where(x => x.BlogId > id)
                .Take(pageSize)
                .ToListAsync();

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
