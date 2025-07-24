
using BlazorBlog.Domain.Users;

namespace BlazorBlog.Application.Users.GetUsers;

public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, List<UserResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;

    public GetUsersQueryHandler(IUserRepository userRepository, IUserService userService)
    {
        _userRepository = userRepository;
        _userService = userService;
    }

    public async Task<Result<List<UserResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        if (!await _userService.IsCurrentUserInRoleAsync("Admin"))
            return Result.Fail<List<UserResponse>>("You are not authorized to view users.");

        var users = await _userRepository.GetAllUsersAsync();

        var response = users.Adapt<List<UserResponse>>();

        return response;
    }
}