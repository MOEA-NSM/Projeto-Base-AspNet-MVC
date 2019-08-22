using EstudosAsp.Contexts;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace EstudosAsp.DAO
{
    public class Repositorio<T> : IRepositorio<T>, IDisposable where T : class
    {
        protected EstudoContext context;

        public Repositorio()
        {
            //Recupera uma instancia do respectivo Repotorio do injetor de dependencia
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            this.context = kernel.Get<EstudoContext>();
        }

        public IQueryable<T> ConsultarTodos()
        {
            return context.Set<T>();
        }

        public IQueryable<T> ConsultarPor(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        public T ConsultarPorId(params object[] key)
        {
            return context.Set<T>().Find(key);
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public void Salvar(T entity)
        {
            context.Set<T>().Add(entity);
            Commit();
        }

        public void Atualizar(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            Commit();
        }

        public void Deletar(Func<T, bool> predicate)
        {
            context.Set<T>()
           .Where(predicate).ToList()
           .ForEach(del => context.Set<T>().Remove(del));
            Commit();
        }

        private void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}