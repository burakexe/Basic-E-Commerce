using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Tekno.CORE.Entity;
using Tekno.CORE.Service;
using Tekno.MODEL;

namespace Tekno.SERVICE.Base
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        //ProjectContext db = new ProjectContext();
        private static TeknoDB _db;
        public TeknoDB Db
        {

            get
            {
                if (_db == null)
                {
                    _db = new TeknoDB();
                    return _db;
                }
                return _db;
            }
        }

        public void Add(T item)
        {
            Db.Set<T>().Add(item);
            Save();
        }

        public void Add(List<T> items)
        {
            Db.Set<T>().AddRange(items);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp) => Db.Set<T>().Any(exp);

        public List<T> GetActive()
        {
            return Db.Set<T>().Where(x => x.Status == CORE.Entity.Enum.Status.Active).ToList();
        }

        public List<T> GetAll()
        {
            return Db.Set<T>().ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return Db.Set<T>().FirstOrDefault(exp);
        }

        public T GetById(Guid id)
        {
            return Db.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return Db.Set<T>().Where(exp).ToList();
        }

        public void Remove(T item)
        {
            item.Status = CORE.Entity.Enum.Status.Deleted;
            Update(item);
        }

        public void Remove(Guid id)
        {
            T item = GetById(id);
            item.Status = CORE.Entity.Enum.Status.Deleted;
            Update(item);
        }

        public void RemoveAll(Expression<Func<T, bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.Status = CORE.Entity.Enum.Status.Deleted;
                Update(item);
            }
        }

        public int Save()
        {
            return Db.SaveChanges();
        }

        public void Update(T item)//chai
        {
            //aşağıdaki işlemde parametreden gelen bilgiler ile veritabanında kayıtlı olan bilgiler kıyaslanarak değişiklikleri güncel şeklinde (CurrentValues) set (ayarla) işlemi gerçekleştirildi.
            T updated = GetById(item.ID);
            DbEntityEntry entry = Db.Entry(updated);
            entry.CurrentValues.SetValues(item);
            Save();
        }
    }
}