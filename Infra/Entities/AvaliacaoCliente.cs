using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infra.Entities
{
    [Table("tb_avaliacao_cliente")]
    public class AvaliacaoCliente
    {
        [Key]
        public int IdAvaliacaoCliente { get; set; }
        public int IdCliente { get; set; }
        public int IdAvaliacao { get; set; }
        public string ResultadoAvaliacao { get; set; }
        public float Nota { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }

        [ForeignKey("IdAvaliacao")]
        public Avaliacao Avaliacao { get; set; }
    }
}
