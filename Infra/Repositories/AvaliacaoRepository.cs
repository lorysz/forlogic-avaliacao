
using Infra.Entities;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Repositories
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        public void CadastrarAvaliacao(Avaliacao avaliacao)
        {
            using (var _con = new Context())
            {
                _con.Avaliacao.Add(avaliacao);
                _con.SaveChanges();
            }
        }

        public List<Avaliacao> GetAll()
        {
            using (var _con = new Context())
            {
                return _con.Avaliacao.Include(x => x.Avaliacoes).ToList();
            }
        }

        public Avaliacao GetAvaliacaoAtual()
        {
            using (var _con = new Context())
            {
                return _con.Avaliacao.Include(x => x.Avaliacoes).Where(x => x.Ano == DateTime.Now.Year && x.Mes == DateTime.Now.Month).FirstOrDefault();
            }
        }

        public Avaliacao GetById(int idAvaliacao)
        {
            using(var _con = new Context())
            {
                return _con.Avaliacao.Where(x => x.IdAvaliacao == idAvaliacao).FirstOrDefault();
            }
        }

        public List<AvaliacaoCliente> GetClientesByIdAvaliacao(int idAvaliacao)
        {
            using (var _con = new Context())
            {
                return _con.AvaliacaoCliente.Include(x => x.Cliente).Where(x => x.IdAvaliacao == idAvaliacao).ToList();
            }
        }

        public Avaliacao ValidarAvaliacaoAtual(int mes, int ano)
        {
            using (var _con = new Context())
            {
                return _con.Avaliacao.Where(x => x.Mes == mes && x.Ano == ano).FirstOrDefault();
            }
        }
    }
}
