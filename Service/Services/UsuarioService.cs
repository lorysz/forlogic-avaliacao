using AutoMapper;
using Infra.Interfaces;
using Infra.Jwt;
using Service.Dto.Usuario;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repo;
        private readonly IMapper _mapper;
        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        public UsuarioLogadoDto LoginUsuario(LoginUsuarioDto loginDto)
        {
            var result = _repo.GetUsuario(loginDto.Login, loginDto.Senha);
            UsuarioLogadoDto usuarioDto = null;
            // Verifica se retornou algum resultado para aquele login
            if (result != null)
            {
                var token = TokenService.GenerateToken(result);
                usuarioDto = new UsuarioLogadoDto
                {
                    Nome = result.Nome,
                    AccessToken = token
                };
            }
            // Gera o Token
            return usuarioDto;
        }
    }
}
