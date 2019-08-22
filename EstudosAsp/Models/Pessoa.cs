using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstudosAsp.Models
{
    [Table("pessoa")]
    public class Pessoa
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(40)]
        [Column("nome")]

        public string Nome { get; set; }
        [MaxLength(40)]
        [Column("sobrenome")]
        public string Sobrenome { get; set; }

        [MaxLength(40)]
        [Column("nome_mae")]
        public string NomeMae { get; set; }

        [MaxLength(40)]
        [Column("nome_pai")]
        public string NomePai { get; set; }
    }
}