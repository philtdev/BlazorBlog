using BlazorBlog.Domain.Articles;
using BlazorBlog.Domain.Users;

using Microsoft.AspNetCore.Identity;

namespace BlazorBlog.Infrastructure.Authentication;

public class User : IdentityUser, IUser
{
    public List<Article> Articles { get; set; } = new List<Article>();
}
