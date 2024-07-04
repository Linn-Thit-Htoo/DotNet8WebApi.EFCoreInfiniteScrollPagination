using DotNet8WebApi.EFCoreInfiniteScrollPagination.DbService.AppDbContexts;
using DotNet8WebApi.EFCoreInfiniteScrollPagination.Models.Features.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8WebApi.EFCoreInfiniteScrollPagination.Mapper
{
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
}
