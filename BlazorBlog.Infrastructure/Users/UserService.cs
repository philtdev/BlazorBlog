using BlazorBlog.Application.Users;

namespace BlazorBlog.Infrastructure.Users;

public class UserService : IUserService
{
    public Task<bool> CurrentUserCanCreateArticlesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CurrentUserCanEditArticleAsync(int articleId)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetCurrentUserIdAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsCurrentUserInRoleAsync(string role)
    {
        throw new NotImplementedException();
    }
}
