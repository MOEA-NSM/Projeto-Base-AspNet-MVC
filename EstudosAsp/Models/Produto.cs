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
        private int Id { get; }

        [Required]
        [Index(IsUnique = true)]
        [Column("descricao")]
        [MaxLength(40)]
        public string Descricao { get; }

        [Column("peso")]
        private double Peso;
       
        [ForeignKey("ProdutoTipo")]
        [Column("_produto_tipo")]
        public int ProdutoTipoId { get; }
        
        public ProdutoTipo ProdutoTipo { get; set; }

        [Column("data_cadastro")]
        public DateTime DataCadastro { get;} = DateTime.Now;

        public Produto(string descricao, double peso, int produtoTipoId)
        {
            Descricao = descricao;
            Peso = peso;
            ProdutoTipoId = produtoTipoId;
        }
    }
}