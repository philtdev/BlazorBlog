using BlazorBlog.Domain.Users;
using BlazorBlog.Infrastructure.Users;

using Microsoft.AspNetCore.Identity;

namespace BlazorBlog.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<User> _userManager;

    public UserRepository(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IUser?> GetUserByIdAsync(string userId)
    {
        return await _userManager.FindByIdAsync(userId);
    }
}
