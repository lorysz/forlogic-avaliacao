using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infra.Entities
{
    [Table("tb_avaliacao")]
    public class Avaliacao
    {
        [Key]
        public int IdAvaliacao { get; set; }
        [Required]
        public int Mes { get; set; }
        [Required]
        public int Ano { get; set; }
        [Required]
        public float Nota { get; set; }
        [Required]
        public int IdUsuario { get; set; }

        public List<AvaliacaoCliente> Avaliacoes { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
    }
}
