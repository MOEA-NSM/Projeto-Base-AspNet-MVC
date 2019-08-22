using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstudosAsp.Models
{
    [Table("usuario", Schema = "seguranca")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        [Column("nome")]
        public string Nome { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(40)]
        [Column("login")]
        public string Login { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(40)]
        [Column("email")]
        public string Email { get; set; }

        [Column("data_ultimo_acesso")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DataUltimoAcesso{ get; set; }

        [Column("data_cadastro")]
        public DateTime DataCadastro { get; } = DateTime.Now;

        [InverseProperty("Usuario")]
        public List<UsuarioNivel> Niveis { get; set; }

        [NotMapped]
        public string AtributoAuxiliar;
    }
}