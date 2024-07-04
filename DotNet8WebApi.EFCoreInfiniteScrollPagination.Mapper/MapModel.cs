using DotNet8WebApi.EFCoreInfiniteScrollPagination.DbService.AppDbContexts;
using DotNet8WebApi.EFCoreInfiniteScrollPagination.Models.Features.Blog;

namespace DotNet8WebApi.EFCoreInfiniteScrollPagination.Mapper;

public static class MapModel
{
    public static BlogModel Map(this TblBlog dataModel)
    {
        return new BlogModel
        {
            BlogId = dataModel.BlogId,
            BlogTitle = dataModel.BlogTitle,
            BlogAuthor = dataModel.BlogAuthor,
            BlogContent = dataModel.BlogContent
        };
    }
}