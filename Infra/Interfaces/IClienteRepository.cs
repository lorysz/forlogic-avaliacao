using Infra.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Interfaces
{
    public interface IClienteRepository
    {
        void CadastrarCliente(Cliente cliente);
        Cliente GetById(int idCliente);
        void AlterarCliente(Cliente cliente);
        List<Cliente> GetAll();
        List<Cliente> GetAllCombo();
        Cliente ValidarCnpjExistente(string cnpj, int idCliente);
        int TotalClientesAvaliadosMes();

    }
}
