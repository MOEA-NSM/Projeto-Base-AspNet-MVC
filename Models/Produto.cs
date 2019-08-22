using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstudosAsp.Models
{
    [Table("produto", Schema = "base")]
    public class Produto
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [Column("descricao")]
        [MaxLength(40)]
        public string Descricao { get; set; }

        [Column("peso")]
        public double Peso { get; set; }
       
        [ForeignKey("ProdutoTipo")]
        [Column("_produto_tipo")]
        public int ProdutoTipoId { get; set; }

        public ProdutoTipo ProdutoTipo { get; set; }

        [Column("data_cadastro")]
        public DateTime DataCadastro { get;} = DateTime.Now;

    }
}