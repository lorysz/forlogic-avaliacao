using Infra.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Interfaces
{
    public interface IAvaliacaoRepository
    {
        void CadastrarAvaliacao(Avaliacao avaliacao);
        Avaliacao GetById(int idAvaliacao);
        List<Avaliacao> GetAll();
        Avaliacao ValidarAvaliacaoAtual(int mes, int ano);
        List<AvaliacaoCliente> GetClientesByIdAvaliacao(int idAvaliacao);
        Avaliacao GetAvaliacaoAtual();
    }
}
