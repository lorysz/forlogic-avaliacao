using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Dto.Avaliacao
{
    public class AvaliacaoClienteDto
    {
        public int IdCliente { get; set; }
        public float Nota { get; set; }
        public string Motivo { get; set; }
        public string ResultadoAvaliacao { get; set; }
    }
}
