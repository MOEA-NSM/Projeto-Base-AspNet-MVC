using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace EstudosAsp.Servico
{
    public interface IServico<T> where T : class
    {
        IQueryable<T> ObterTodos();
        IQueryable<T> ObterPor(Expression<Func<T, bool>> predicate);
        T ObterPorId(params object[] key);
        T First(Expression<Func<T, bool>> predicate);
        void Salvar(T entity);
        void Atualizar(T entity);
        void Deletar(Func<T, bool> predicate);
        void Dispose();
    }
}