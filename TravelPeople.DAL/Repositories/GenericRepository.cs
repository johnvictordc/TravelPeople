using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPeople.DAL.Interfaces;
using Dapper;
using DapperExtensions;
using System.Linq.Expressions;

namespace TravelPeople.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly IDbConnection _db;

        public GenericRepository()
        {
            this._db = new SqlConnection(ConfigurationManager.ConnectionStrings["TravelPeople"].ConnectionString);
        }

        public virtual long Insert(T entity)
        {
            return _db.Insert(entity);
        }

        public bool Update(T entity)
        {
            return _db.Update(entity);
        }

        public T GetByID(long id)
        {
            return _db.Get<T>(id);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _db.GetList<T>(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _db.GetList<T>();
        }


        public bool Delete(long id)
        {
            return _db.Delete<T>(GetByID(id));
        }
    }
}
