using AgriInvestment.Core.Contracts;
using AgriInvestment.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace AgriInvestment.DataAccess.InMemory
{
    public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ObjectCache cache = MemoryCache.Default;
        private List<T> items;
        private readonly string className;

        public InMemoryRepository()
        {
            className = typeof(T).Name;
            items = cache[className] as List<T>;

            if (items == null)
                items = new List<T>();
        }

        public void Commit()
        {
            cache[className] = items;
        }

        public void Insert(T t)
        {
            items.Add(t);
        }

        public void Update(T t, int Id)
        {
            T tToUpdate = items.Find(i => i.Id == Id);

            if (tToUpdate == null)
                throw new Exception("No " + className + " to update!");

            tToUpdate = t;
        }

        public T Find(int Id)
        {
            T tToFind = items.Find(i => i.Id == Id);

            if (tToFind == null)
                throw new Exception(className + " not found!");

            return tToFind;
        }

        public IQueryable<T> Collection()
        {
            return items.AsQueryable();
        }

        public void Delete(int Id)
        {
            T tToDelete = items.Find(i => i.Id == Id);

            if (tToDelete == null)
                throw new Exception("No " + className + " to delete!");

            items.Remove(tToDelete);
        }
    }
}
