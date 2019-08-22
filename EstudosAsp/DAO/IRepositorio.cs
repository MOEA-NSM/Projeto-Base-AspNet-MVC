using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace EstudosAsp.DAO
{
    public interface IRepositorio<T> where T : class
    {
        IQueryable<T> ConsultarTodos();
        IQueryable<T> ConsultarPor(Expression<Func<T, bool>> predicate);
        T ConsultarPorId(params object[] key);
        T First(Expression<Func<T, bool>> predicate);
        void Salvar(T entity);
        void Atualizar(T entity);
        void Deletar(Func<T, bool> predicate);
        void Dispose();
    }
}