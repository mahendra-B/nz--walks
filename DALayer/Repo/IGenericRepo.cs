using System;
using System.Collections.Generic;
using System.Text;

namespace DALayer.Repo
{
    public interface IGenericRepo<T> where T : class
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> GetById(object id);

        void Insert(T obj);

        void Update(T obj);

        void Delete(object id);

    }
}
