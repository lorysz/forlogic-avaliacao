using Infra.Interfaces;
using Service.Dto.Home;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class HomeService : IHomeService
    {
        private readonly IAvaliacaoRepository _repo;

        public HomeService(IAvaliacaoRepository repo)
        {
            _repo = repo;
        }

        public HomeDto GetInformacoes()
        {
            var avaliacao = _repo.GetAvaliacaoAtual();
            return new HomeDto {
                QuantidadeClientesAvaliadosMes = avaliacao != null ? avaliacao.Avaliacoes.Count : 0,
                NotaGeralMes = avaliacao != null ? avaliacao.Nota : 0,
                AvaliadoMes = avaliacao != null && avaliacao.Avaliacoes.Count > 0 ? "Sim" : "Não"
            };
        }
    }
}
