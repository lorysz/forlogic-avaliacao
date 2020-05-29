using AutoMapper;
using Infra.Entities;
using Infra.Identity;
using Infra.Interfaces;
using Service.Dto.Avaliacao;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly IAvaliacaoRepository _repo;
        private readonly IUser _user;
        private readonly IMapper _map;
        public AvaliacaoService(IAvaliacaoRepository repo, IMapper map, IUser user)
        {
            _repo = repo;
            _map = map;
            _user = user;
        }

        public void CadastrarAvaliacao(CadastrarAvaliacaoDto avaliacao)
        {
            var resultMap = _map.Map<Avaliacao>(avaliacao);
            resultMap.IdUsuario = _user.IdUsuario;
            _repo.CadastrarAvaliacao(resultMap);
        }

        public List<GridAvaliacaoDto> GetAll()
        {
            var result = _repo.GetAll();
            var resultMap = _map.Map<List<GridAvaliacaoDto>>(result);

            return resultMap;
        }

        public VisualizarAvaliacaoDto GetById(int idAvaliacao)
        {
            var result = _repo.GetById(idAvaliacao);
            var resultMap = _map.Map<VisualizarAvaliacaoDto>(result);

            return resultMap;
        }

        public List<GridVisualizacaoAvaliacaoClienteDto> GetClientesByIdAvaliacao(int idAvaliacao)
        {
            var result = _repo.GetClientesByIdAvaliacao(idAvaliacao);
            var resultMap = _map.Map<List<GridVisualizacaoAvaliacaoClienteDto>>(result);

            return resultMap;
        }

        public bool ValidarAvaliacaoAtual(int mes, int ano)
        {
            var result = _repo.ValidarAvaliacaoAtual(mes, ano);

            return result == null;
        }
    }
}
