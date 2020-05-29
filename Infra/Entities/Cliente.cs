using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infra.Entities
{
    [Table("tb_cliente")]
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        [Required]
        public string RazaoSocial { get; set; }
        [Required]
        public string NomeResponsavel { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataCadastro { get; set; }
        [Required]
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        public List<AvaliacaoCliente> Avaliacoes { get; set; }

        public Cliente()
        {
            this.DataCadastro = DateTime.Now;
        }
    }
}
