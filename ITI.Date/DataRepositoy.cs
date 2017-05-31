using ITI.Data.DBmodel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;



namespace ITI.Data.DataRepositoy
{
    
    public interface IGenericRepository<T> where T : class
    {
        T Get(int id);
      //  T Get(string username,string pass);

        IQueryable<T> GetAll();
     
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T FindobjBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        IEnumerable<T> AddAll(IEnumerable<T> tList);
        bool Delete(T entity);
        bool Delete(int key);
        bool Edit(T entity);
        T Edit(T updated, int key);
        void Save();
        int Count();
    }
    public abstract class DataRepositoy<C, T> : IGenericRepository<T>
        where T : class
        where C : ITIEntities, new()
    {

        private C _entities = new C();
        public C Context
        {

            get { return _entities; }
            set { _entities = value; }
        }

        public virtual IQueryable<T> GetAll()
        {

            IQueryable<T> query = _entities.Set<T>();
            return query;
        }
       


       
        public T Get(int id)
        {
            return _entities.Set<T>().Find(id);
        }
        //public T Get(string username,string pass)
        //{
        //    return _entities.Set<T>().Where();
        //}

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }
        public virtual T Add(T entity)
        {
            T result = null;
            _entities.Set<T>().Add(entity);
            if (_entities.SaveChanges()>0)
            {
                result = entity;
            }
            
             return result;

        }
        public IEnumerable<T> AddAll(IEnumerable<T> tList)
        {
            _entities.Set<T>().AddRange(tList);
            _entities.SaveChanges();
            return tList;
        }
        public virtual bool Delete(T entity)
        {
            //bool result = false;
            //_entities.Set<T>().Remove(entity);
            //if (_entities.SaveChanges() > 0)
            //{
            //    result = true;
            //}

            //return result;
           // _entities.Set<T>().Remove(entity);
            bool result = false;
            if (entity !=null)
            {
                
           
           
            _entities.Entry(entity).State = EntityState.Deleted; // System.Data.EntityState.Modified;
            if (_entities.SaveChanges() > 0)
            {
                result = true;
            }
            }
            return result;
        }
        public virtual bool Delete(int key)
        {
            T entity = _entities.Set<T>().Find(key);
            bool result = false;
            _entities.Entry(entity).State = EntityState.Deleted; // System.Data.EntityState.Modified;
            if (_entities.SaveChanges() > 0)
            {
                result = true;
            }

            return result;
        }
        public virtual bool Edit(T entity)
        {
            bool result = false;
            _entities.Entry(entity).State = EntityState.Modified; // System.Data.EntityState.Modified;
            if (_entities.SaveChanges() > 0)
            {
                result = true;
            }

            return result;
        }
        public T Edit(T updated, int key)
        {
            if (updated == null)
                return null;

            T existing = _entities.Set<T>().Find(key);
            if (existing != null)
            {
                _entities.Entry(existing).CurrentValues.SetValues(updated);
                _entities.SaveChanges();
            }
            return existing;
        }
        public int Count()
        {
            return _entities.Set<T>().Count();
        }
        public virtual void Save()
        {
            _entities.SaveChanges();
        }

        public T FindobjBy(Expression<Func<T, bool>> predicate)
        {
            T query = _entities.Set<T>().Where(predicate).First();
            return query;
        }
    }
}