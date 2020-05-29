using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Infra.Identity
{
    public class UserIdentity : IUser
    {
        private readonly IHttpContextAccessor _accessor;
        public UserIdentity(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        public string Nome => _accessor.HttpContext.User.Identity.Name;

        public int IdUsuario => Convert.ToInt32(_accessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("primarysid")).Value);

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
