using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.Dto.Cliente
{
    public class CadastrarClienteDto
    {
        [Required]
        public string RazaoSocial { get; set; }
        [Required]
        public string NomeResponsavel { get; set; }
        public string Cnpj { get; set; }
    }
}
