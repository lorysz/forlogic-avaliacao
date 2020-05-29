using Service.Dto;
using Service.Dto.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IUsuarioService
    {
        UsuarioLogadoDto LoginUsuario(LoginUsuarioDto loginDto);
    }
}
