using AutoMapper;
using Infra.Entities;
using Infra.Identity;
using Infra.Interfaces;
using Service.Dto.Cliente;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repo;
        private readonly IUser _user;
        private readonly IMapper _map;
        public ClienteService(IClienteRepository repo, IMapper map, IUser user)
        {
            _repo = repo;
            _map = map;
            _user = user;
        }

        public void AlterarCliente(AlterarClienteDto cliente)
        {
            var result = _repo.GetById(cliente.IdCliente);

            if (result != null)
            {
                var resultMap = _map.Map(cliente, result);
                _repo.AlterarCliente(resultMap);
            }
        }

        public void CadastrarCliente(CadastrarClienteDto cliente)
        {
            var resultMap = _map.Map<Cliente>(cliente);
            resultMap.IdUsuario = _user.IdUsuario;
            _repo.CadastrarCliente(resultMap);
        }

        public List<GridClienteDto> GetAll()
        {
            var result = _repo.GetAll();
            var resultMap = _map.Map<List<GridClienteDto>>(result);

            return resultMap;
        }

        public List<ComboClienteDto> GetAllCombo()
        {
            var result = _repo.GetAllCombo();
            var resultMap = _map.Map<List<ComboClienteDto>>(result);

            return resultMap;
        }

        public VisualizarClienteDto GetById(int idCliente)
        {
            var result = _repo.GetById(idCliente);
            var resultMap = _map.Map<VisualizarClienteDto>(result);

            return resultMap;
        }

        public bool ValidarCnpjExistente(string cnpj, int idCliente)
        {
            return _repo.ValidarCnpjExistente(cnpj, idCliente) != null;
        }
    }
}
