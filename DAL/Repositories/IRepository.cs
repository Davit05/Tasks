using DAL.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public interface IRepository<T> where T:EntityBase
    {
        void Add(T entity);
        IQueryable<T> GetItems();
        T GetItemByID(int id);
        void Update(T updatedEntity);
        void Delete(T entity);
        void OpenConnection();
        void CloseConnection();
    }
}
