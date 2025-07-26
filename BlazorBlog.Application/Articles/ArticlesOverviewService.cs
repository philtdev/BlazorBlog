
using BlazorBlog.Application.Articles.GetArticlesByCurrentUser;
using BlazorBlog.Application.Articles.TogglePublishArticle;

using MediatR;

namespace BlazorBlog.Application.Articles;

public class ArticlesOverviewService : IArticlesOverviewService
{
    private readonly ISender _sender;

    public ArticlesOverviewService(ISender sender)
    {
        _sender = sender;
    }

    public async Task<List<ArticleResponse>?> GetArticlesByCurrentUserAsync()
    {
        var result = await _sender.Send(new GetArticlesByCurrentUserQuery());

        return result;
    }

    public async Task<ArticleResponse?> TogglePublishArticlAsync(int articleId)
    {
        var result = await _sender.Send(new TogglePublishArticleCommand { ArticleId = articleId });

        return result;
    }
}
