using BlazorBlog.Application.Articles;

using Carter;

namespace BlazorBlog.WebUI.Server.Features.Articles;

public class ArticlesEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/Articles");

        group.MapGet("/", async (IArticlesOverviewService articlesOverviewService) =>
        {
            var result = await articlesOverviewService.GetArticlesByCurrentUserAsync();

            return Results.Ok(result);
        });

        group.MapPatch("/{id:int}", async (int id, IArticlesOverviewService articlesOverviewService) =>
        {
            var result = await articlesOverviewService.TogglePublishArticleAsync(id);

            return result is null ? Results.BadRequest() : Results.Ok(result);
        });
    }
}
