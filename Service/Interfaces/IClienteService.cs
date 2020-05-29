using Service.Dto.Cliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IClienteService
    {
        void CadastrarCliente(CadastrarClienteDto cliente);
        VisualizarClienteDto GetById(int idCliente);
        void AlterarCliente(AlterarClienteDto cliente);
        List<GridClienteDto> GetAll();
        List<ComboClienteDto> GetAllCombo();
        bool ValidarCnpjExistente(string cnpj, int idCliente);
    }
}
