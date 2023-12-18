using Microsoft.AspNetCore.Http;
using ProductManagerTest.Application.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerTest.Application.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string? AccessToken;
        private readonly string? UserName;
        private readonly string? UserId;
        private readonly string? RoleId;
        private readonly string? RoleName;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            if (_httpContextAccessor.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                AccessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];
            }
            if (AccessToken != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(AccessToken) as JwtSecurityToken;
                UserId = jsonToken.Claims.FirstOrDefault(x => x.Type == "Id").Value;
                UserName = jsonToken.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value;

                //UserId = _httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == "Id").Select(x => x.Value).SingleOrDefault();
                RoleId = _httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == "Role").Select(x => x.Value).SingleOrDefault();
                RoleName = _httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == "RoleName").Select(x => x.Value).SingleOrDefault();
                //UserName = _httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Select(x => x.Value).SingleOrDefault();
            }
        }
        public string? GetAccessToken()
        {
            return AccessToken;
        }
        public string? GetUserName()
        {
            return UserName;
        }
        public string? GetRoleName()
        {
            return RoleName;
        }
        public string? GetRoleId()
        {
            return RoleId;
        }
        public string? GetUserId()
        {
            return UserId;
        }
    }
}
