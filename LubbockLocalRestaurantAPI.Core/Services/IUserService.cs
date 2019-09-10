using System.Security.Claims;

namespace LubbockLocalRestaurant.Core.Services
{
    public interface IUserService
    {
        string CurrentUserId { get; }
        ClaimsPrincipal User { get; }
    }
}