using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstudosAsp.Models
{
    [Table("produto_tipo", Schema = "base")]
    public class ProdutoTipo
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [Column("descricao")]
        [MaxLength(40)]
        public string Descricao { get; set; }

        [InverseProperty("ProdutoTipo")]
        public List<Produto> Produtos { get; set; }

    }
}