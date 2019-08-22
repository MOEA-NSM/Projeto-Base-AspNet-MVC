using EstudosAsp.DAO;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace EstudosAsp.Servico
{
    public class Servico<T> : IServico<T> where T : class
    {

        IRepositorio<T> repositorio;

        public Servico()
        {
            //Recupera uma instancia do respectivo Repotorio do injetor de dependencia
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            this.repositorio = kernel.Get<Repositorio<T>>();
        }

        public void Salvar(T entity)
        {
            repositorio.Salvar(entity);
        }

        public void Atualizar(T entity)
        {
            repositorio.Atualizar(entity);
        }

        public void Deletar(Func<T, bool> predicate)
        {
            repositorio.Deletar(predicate);
        }

        public void Dispose()
        {
            repositorio.Dispose();
        }

        public T ObterPorId(params object[] key)
        {
            return repositorio.ConsultarPorId(key);
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return repositorio.First(predicate);
        }

        public IQueryable<T> ObterPor(Expression<Func<T, bool>> predicate)
        {
            return repositorio.ConsultarPor(predicate);
        }

        public IQueryable<T> ObterTodos()
        {
            return repositorio.ConsultarTodos();
        }
    }
}