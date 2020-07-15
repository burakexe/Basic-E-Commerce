using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Tekno.CORE.Entity;

namespace Tekno.CORE.Service
{
    public interface ICoreService<T> where T : CoreEntity // Business Logic Layer - İş Katmanı
    {
        void Add(T item);
        void Add(List<T> items);
        void Update(T item);
        void Remove(T item);
        void Remove(Guid id);
        void RemoveAll(Expression<Func<T, bool>> exp);
        T GetById(Guid id);
        T GetByDefault(Expression<Func<T, bool>> exp);
        List<T> GetDefault(Expression<Func<T, bool>> exp);
        List<T> GetAll();
        List<T> GetActive();
        bool Any(Expression<Func<T, bool>> exp);
        int Save();
    }
}