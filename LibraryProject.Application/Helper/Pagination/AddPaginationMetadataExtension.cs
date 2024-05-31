using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LibraryProject.Application.Helper.Pagination
{
    public static class AddPaginationMetadataExtension
    {
        public static void AddPaginationMetadata<T>(this Controller controller, PagedList<T> pagedItems,
            PaginationQueryObject queryParameters)
        {
            string? previousPageUrl = null;
            string? nextPageUrl = null;

            var paginationAttribute = (PaginatedHttpGetAttribute?)controller.ControllerContext.ActionDescriptor.MethodInfo
                .GetCustomAttributes(false).FirstOrDefault(obj => obj is PaginatedHttpGetAttribute);

            var routeName = paginationAttribute.Name;

            if (pagedItems.HasPrevious)
            {

                previousPageUrl = controller.Url.Link(routeName, queryParameters with
                {
                    PageNumber = queryParameters.PageNumber - 1
                });
            }

            if (pagedItems.HasNext)
            {

                nextPageUrl = controller.Url.Link(routeName, queryParameters with
                {
                    PageNumber = queryParameters.PageNumber + 1
                });
            }

            var paginationMetadata = new PaginationMetadata
            {
                HasNext = pagedItems.HasNext,
                HasPrevious = pagedItems.HasPrevious,
                TotalPageCount = pagedItems.TotalPageCount,
                TotalItemCount = pagedItems.TotalItemCount,
                CurrentPage = pagedItems.CurrentPage,
                PageSize = pagedItems.PageSize,
                PreviousPageUrl = previousPageUrl,
                NextPageUrl = nextPageUrl
            };

            controller.Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));
        }
    }
}
