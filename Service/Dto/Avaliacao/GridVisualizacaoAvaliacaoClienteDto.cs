using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Dto.Avaliacao
{
    public class GridVisualizacaoAvaliacaoClienteDto
    {
        public string RazaoSocial { get; set; }
        public string NomeResponsavel { get; set; }
        public int Nota { get; set; }
        public string ResultadoAvaliacao { get; set; }
    }
}
