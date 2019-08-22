using EstudosAsp.DAO;
using EstudosAsp.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace EstudosAsp.Servico
{

    public class NivelServico: Servico<Nivel>
    {
        private NivelDAO nivelDAO; 

        public NivelServico(NivelDAO nivelDAO)
        {
            this.nivelDAO = nivelDAO;
        }

        public void ObterExemplo1()
        {
            nivelDAO.ConsultarSQLNativoPuro();
        }

        public Nivel ObterCastObjeto()
        {
            return nivelDAO.ConsultarCastObjeto();
        }

        public List<Nivel> ObteListaComParametroAnonimo() 
        {
            return nivelDAO.ConsultarListaComParametroAnonimo();
        }
    }
}