namespace BlazorBlog.Domain.Users;

public interface IUserRepository
{
    Task<IUser?> GetUserByIdAsync(string userId);
}
