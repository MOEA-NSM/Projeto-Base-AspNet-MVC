using EstudosAsp.Models;
using EstudosAsp.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EstudosAsp.Controllers
{
    public class HomeController : Controller
    {
        NivelServico nivelServico;
        ProdutoTipoServico produtoTipoServico;
        ProdutoServico produtoServico;

        public HomeController(NivelServico nivelServico1, 
                              ProdutoServico produtoServico1,
                              ProdutoTipoServico produtoTipoServico1)
        {
            this.nivelServico = nivelServico1;
            this.produtoServico = produtoServico1;
            this.produtoTipoServico = produtoTipoServico1;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            DateTime dt = DateTime.Now;

            //Nivel nivel = nivelServico.ObterPorId(3);
            //nivel.Descricao = dt.ToString("MM/dd/yyyy HH:mm:ss.fff");
            //nivelServico.Atualizar(nivel);

            ProdutoTipo produtoTipo = new ProdutoTipo();
            produtoTipo.Descricao = "Produto tipo - " + dt.ToString("MM/dd/yyyy HH:mm:ss.fff");
            produtoTipoServico.Salvar(produtoTipo);

            //nivelServico.ObterExemplo1();
            //Nivel nivel2 = nivelServico.ObterCastObjeto();
            //ViewBag.Message = "Objeto encontrado: Id " + nivel.Id + " Descricao: " + nivel.Descricao;

            List<Nivel> niveis = nivelServico.ObteListaComParametroAnonimo();
            StringBuilder valores = new StringBuilder();

            foreach(Nivel nivel1 in niveis) {
                valores.AppendLine("Id: ");
                valores.AppendLine(nivel1.Id.ToString());
                valores.AppendLine("Descricao: ");
                valores.AppendLine(nivel1.Descricao);
            }

            ViewBag.Message = valores.ToString();


            return View();
        }

        public ActionResult Contact()
        {
            //Nivel nivel = new Nivel();
            //nivel.Descricao = "Minha Descricao linda";

            //nivelServico.Salvar(nivel);

            NovoProduto();

            return View();
        }

        public void NovoProduto()
        {
            DateTime dt = DateTime.Now;
            ProdutoTipo produtoTipo = produtoTipoServico.ObterPorId(1);

            Produto produto = new Produto();
            produto.Descricao = "Produto: " + dt.ToString("MM/dd/yyyy HH:mm:ss.fff");
            produto.Peso = 3.2;
            produto.ProdutoTipoId = produtoTipo.Id;

            produtoServico.Salvar(produto);

        }
    }
}