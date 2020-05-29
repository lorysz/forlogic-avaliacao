using Infra.Entities;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public void AlterarCliente(Cliente cliente)
        {
            using (var _con = new Context())
            {
                _con.Cliente.Update(cliente);
                _con.SaveChanges();
            }
        }

        public void CadastrarCliente(Cliente cliente)
        {
            using (var _con = new Context())
            {
                _con.Cliente.Add(cliente);
                _con.SaveChanges();
            }
        }

        public List<Cliente> GetAll()
        {
            using (var _con = new Context())
            {
                return _con.Cliente.ToList();
            }
        }

        public List<Cliente> GetAllCombo()
        {
            using (var _con = new Context())
            {
                return _con.Cliente
                    .Include(x => x.Avaliacoes)
                        .ThenInclude(z => z.Avaliacao)
                    .ToList();
            }
        }

        public Cliente GetById(int idCliente)
        {
            using (var _con = new Context())
            {
                return _con.Cliente.Where(x => x.IdCliente == idCliente).FirstOrDefault();
            }
        }

        public int TotalClientesAvaliadosMes()
        {
            using (var _con = new Context())
            {
                return _con.AvaliacaoCliente.Where(x => x.Avaliacao.Mes == DateTime.Now.Month && x.Avaliacao.Ano == DateTime.Now.Year).Count();
            }
        }

        public Cliente ValidarCnpjExistente(string cnpj, int idCliente)
        {
            using (var _con = new Context())
            {
                if (idCliente == 0)
                {
                    return _con.Cliente.Where(x => x.Cnpj == cnpj).FirstOrDefault();
                }
                else
                {
                    return _con.Cliente.Where(x => x.Cnpj == cnpj && x.IdCliente != idCliente).FirstOrDefault();
                }
            }
        }
    }
}
