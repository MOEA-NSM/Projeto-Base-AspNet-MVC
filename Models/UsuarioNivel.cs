using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstudosAsp.Models
{
    [Table("usuario_nivel", Schema = "seguranca")]
    public class UsuarioNivel
    {
        [Key]
        [Column("_usuario", Order = 1)]
        public int UsuarioId { get; set; }

        [Key]
        [Column("_nivel", Order = 2)]
        public int NivelId { get; set; }

        public Usuario Usuario { get; set; }
        public Nivel Nivel { get; set; }
    }
}