using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Dto.Cliente
{
    public class GridClienteDto
    {
        public int IdCliente { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeResponsavel { get; set; }
        public string Cnpj { get; set; }
    }
}
