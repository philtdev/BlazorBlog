namespace BlazorBlog.Application.Articles;

public interface IArticlesOverviewService
{
    Task<ArticleResponse?> TogglePublishArticlAsync(int articleId);
    Task<List<ArticleResponse>> GetArticlesByCurrentUserAsync();
}
