namespace Ratings.Application.Controllers.Helpers;
public interface IUriHelper
{
    public Uri GetPageUri(PaginationFilter filter, string route);
}