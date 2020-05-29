using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Dto.Avaliacao
{
    public class GridAvaliacaoDto
    {
        public int IdAvaliacao { get; set; }
        public string Nota { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
    }
}
