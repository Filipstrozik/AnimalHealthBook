using AnimalHealthBookApi.Context;
using AnimalHealthBookApi.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AnimalHealthBookApi.Services
{
    public class UserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AHBContext _context;

        public UserService(
            IHttpContextAccessor httpContextAccessor,
            AHBContext dbContext    
        )
        {
            _httpContextAccessor = httpContextAccessor;
            _context = dbContext;
        }

        public User GetUserFromRequest()
        {
            ClaimsPrincipal user = _httpContextAccessor.HttpContext.User;
            var userId = user.Identity.Name;
            if ( userId == null )
            {
                return null;
            }
            var userIdGuid = new Guid(userId);
            var userEntity = _context.Users.FirstOrDefault(u => u.Id == userIdGuid);
            return userEntity;
        }
    }
}
