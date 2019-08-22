using EstudosAsp.Models;
using Dapper;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;

namespace EstudosAsp.DAO
{
    public class NivelDAO: Repositorio<Nivel>
    {

        static string strConexao = ConfigurationManager.ConnectionStrings["Asp_Net_MVC_CS"].ConnectionString;

        public void ConsultarSQLNativoPuro()
        {
            //No dapper o desenvolvedor deve garantir a conexao aberta e garantir o fechamento, 
            //por isso deve-se usar sempre o using, este é apenas um exemplo
            SqlConnection conexaoBD = new SqlConnection(strConexao);
            conexaoBD.Open();
            var resultado = conexaoBD.Query("SELECT * FROM seguranca.nivel");
            System.Console.WriteLine("{0} - {1} ", "Id", "Descricao");
            foreach (dynamic nivel in resultado)
            {
                System.Console.WriteLine("{0} - {1}", nivel.Id, nivel.Descricao);
            }
            conexaoBD.Close();
        }

        public Nivel ConsultarCastObjeto()
        {
            using (var conexaoBD = new SqlConnection(strConexao))
            {
                return conexaoBD.Query<Nivel>("SELECT * FROM seguranca.nivel WHERE id = @Id", new { Id = 3}).FirstOrDefault();
            }
        }

        public List<Nivel> ConsultarListaComParametroAnonimo()
        {
            using (var conexaoBD = new SqlConnection(strConexao))
            {
                List<Nivel> niveis = conexaoBD.Query<Nivel>
                    (
                      "SELECT id, descricao FROM seguranca.nivel WHERE id > @IdInicio", new { IdInicio = 4 }
                    ).AsList();
                return niveis;
            }
        }


        public void ExemploInsercao()
        {
            using (var conexaoBD = new SqlConnection(strConexao))
            {
                var nivel = new Nivel()
                {
                    Descricao = "Rua Projetada 100"
                };
                conexaoBD.Execute(@"INSERT nivel(descricao) VALUES (@Descricao)", nivel);
            }
        }

        public void ExemploUpdate()
        {
            using (var conexaoBD = new SqlConnection(strConexao))
            {
                var atualizarBD = @"UPDATE nivel SET descricao = @Descricao WHERE id = @NivelId";
                conexaoBD.Execute(atualizarBD, new
                {
                    Descricao = "Teste de Update",
                    NivelId = 5
                });
            }
        }

    }
}