using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ProductManagerTest.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PermissionAuthorizeAttribute : Attribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            try
            {
                var accessToken = filterContext.HttpContext.Request.Headers.Authorization.ToString().Split(" ")[1];

                if (string.IsNullOrEmpty(accessToken))
                {
                    filterContext.Result = new UnauthorizedObjectResult(new { message = "توکن دریافت نشد" });
                    return;
                }
                // needs jwt setting class
                var key = Encoding.UTF8.GetBytes("0ieFQe1e/Vt57RCtmwyk4dHT+rXewy0Izq4j+uPBDNQ=");
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(accessToken, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

            }
            catch (SecurityTokenExpiredException e)
            {
                filterContext.Result = new UnauthorizedObjectResult(new { message = " توکن منقضی شده است" });
                return;
            }
        }
    }
}
