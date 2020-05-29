using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Infra.Identity
{
    public interface IUser
    {
        string Nome { get; }
        int IdUsuario { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
