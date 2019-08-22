using EstudosAsp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace EstudosAsp.Contexts
{
    public class EstudoContext: DbContext
    {
        public EstudoContext() : base("Asp_Net_MVC_CS") {

            Database.Log = (query) => Debug.Write(query);
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoTipo> ProdutoTipos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioNivel> UsuarioNiveis { get; set; }
        public DbSet<Nivel> Niveis { get; set; }

    }
}