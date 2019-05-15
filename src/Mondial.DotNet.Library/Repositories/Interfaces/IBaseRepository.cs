using System;
using System.Collections.Generic;
using System.Linq;
using Mondial.DotNet.Library.Models;

namespace Mondial.DotNet.Library.Repositories.Interfaces
{
    public interface IBaseRepository<T>
        where T : BaseModel<T>
    {
        IQueryable<T> Context { get; }
        void SaveChanges();

        T Single(int id);

        void Update(T entity);
        void Delete(int id);
        void Delete(T entity);

        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> predicate);
    }
}