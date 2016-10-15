using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TravelPeople.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {

        long Insert(T entity);

        bool Update(T entity);

        bool Delete(long id);

        T GetByID(long id);
        
        IEnumerable<T> GetAll();

    }
}