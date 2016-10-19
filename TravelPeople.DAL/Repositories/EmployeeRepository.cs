using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperExtensions;
using TravelPeople.Commons.Objects;

namespace TravelPeople.DAL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>
    {
        public void BatchDelete(IEnumerable<long> id)
        {
            try
            {
                _db.Execute("DELETE FROM employees WHERE UserID IN @id", new { id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Employee> GetByIDs(IEnumerable<long> id)
        {
            try
            {
                return _db.Query<Employee>("SELECT * FROM employees WHERE UserID IN @id", new { id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Employee> Search(string name)
        {
            try
            {
                var pg = new PredicateGroup { Operator = GroupOperator.Or, Predicates = new List<IPredicate>() };
                pg.Predicates.Add(Predicates.Field<Employee>(c => c.lastName, Operator.Like, "%" + name + "%"));
                pg.Predicates.Add(Predicates.Field<Employee>(c => c.firstName, Operator.Like, "%" + name + "%"));
                return _db.GetList<Employee>(pg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
