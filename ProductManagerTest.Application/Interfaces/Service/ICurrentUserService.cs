using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerTest.Application.Interfaces.Service
{
    public interface ICurrentUserService
    {
        public string? GetAccessToken();
        public string? GetUserId();
        public string? GetUserName();
        public string? GetRoleId();
        public string? GetRoleName();
    }
}
