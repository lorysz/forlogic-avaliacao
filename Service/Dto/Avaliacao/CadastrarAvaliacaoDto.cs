using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Dto.Avaliacao
{
    public class CadastrarAvaliacaoDto
    {
        public int Mes { get; set; }
        public int Ano { get; set; }
        public float Nota { get; set; }

        public List<AvaliacaoClienteDto> Respostas { get; set; }
    }
}
