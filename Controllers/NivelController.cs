using EstudosAsp.Models;
using EstudosAsp.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EstudosAsp.Controllers
{
    public class NivelController : ApiController
    {

        NivelServico nivelServico;
        ProdutoTipoServico produtoTipoServico;
        ProdutoServico produtoServico;

        public NivelController(NivelServico nivelServico1,
                               ProdutoServico produtoServico1,
                               ProdutoTipoServico produtoTipoServico1)
        { 
            this.nivelServico = nivelServico1;
            this.produtoServico = produtoServico1;
            this.produtoTipoServico = produtoTipoServico1;
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            Nivel nivel = nivelServico.ObterPorId(1);
            return new string[] { "value1", "value2", nivel.Id.ToString(), nivel.Descricao};
            //throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}