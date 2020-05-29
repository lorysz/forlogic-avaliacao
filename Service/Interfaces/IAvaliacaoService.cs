using Service.Dto;
using Service.Dto.Avaliacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IAvaliacaoService
    {
        void CadastrarAvaliacao(CadastrarAvaliacaoDto avaliacao);
        VisualizarAvaliacaoDto GetById(int idAvaliacao);
        List<GridAvaliacaoDto> GetAll();
        bool ValidarAvaliacaoAtual(int mes, int ano);
        List<GridVisualizacaoAvaliacaoClienteDto> GetClientesByIdAvaliacao(int idAvaliacao);
    }
}
