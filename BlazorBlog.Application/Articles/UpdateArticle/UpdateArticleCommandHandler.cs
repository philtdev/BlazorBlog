using BlazorBlog.Application.Users;

namespace BlazorBlog.Application.Articles.UpdateArticle;

public class UpdateArticleCommandHandler : ICommandHandler<UpdateArticleCommand, ArticleResponse?>
{
    private readonly IArticleRepository _articleRepository;
    private readonly IUserService _userService;

    public UpdateArticleCommandHandler(IArticleRepository articleRepository, IUserService userService)
    {
        _articleRepository = articleRepository;
        _userService = userService;
    }

    public async Task<Result<ArticleResponse?>> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
    {
        var updatedArticle = request.Adapt<Article>();

        if (!await _userService.CurrentUserCanEditArticleAsync(updatedArticle.Id))
            return Result.Fail<ArticleResponse?>("You do not have permission to edit this article.");

        var article = await _articleRepository.UpdateArticleAsync(updatedArticle);

        if (article is null)
            return Result.Fail<ArticleResponse?>("The article does not exist.");

        return article.Adapt<ArticleResponse>();
    }
}