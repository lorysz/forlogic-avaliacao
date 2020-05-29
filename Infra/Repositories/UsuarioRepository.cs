using Infra.Entities;
using Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuario GetUsuario(string login, string senha)
        {
            using (var _con = new Context())
            {
                return _con.Usuario.Where(usu =>
                                      usu.Email == login
                                   && usu.Senha == senha).FirstOrDefault();
            }
        }
    }
}
