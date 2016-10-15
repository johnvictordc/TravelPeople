using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPeople.Commons.Objects;
using Dapper;
using DapperExtensions;
using TravelPeople.Commons;

namespace TravelPeople.DAL.Repositories
{
    public class CompanyRepository : GenericRepository<Company>
    {
        public void BatchDelete(IEnumerable<long> id)
        {
            try
            {
                _db.Execute("DELETE FROM companies WHERE companyID IN @id", new { id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Company> GetByIDs(IEnumerable<long> id)
        {
            try
            {
                return _db.Query<Company>("SELECT * FROM companies WHERE companyID IN @id", new { id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Company> Search(string companyName)
        {
            try
            {
                var pg = new PredicateGroup { Operator = GroupOperator.Or, Predicates = new List<IPredicate>() };
                pg.Predicates.Add(Predicates.Field<Company>(c => c.companyName, Operator.Like, "%" + companyName + "%"));
                pg.Predicates.Add(Predicates.Field<Company>(c => c.otherName, Operator.Like, "%" + companyName + "%"));
                return _db.GetList<Company>(pg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}