using Dapper;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Llama.Helpers;
using TravelPeople.Commons.Objects;

namespace TravelPeople.DAL.Repositories
{
    public class BlockRepository : GenericRepository<Block>
    {
    	
    	public override long Insert(Block content)
        {
            try
            {

                int count = _db.ExecuteScalar<int>("SELECT COUNT(*) FROM name WHERE name = @name", new { name = content.name });
                content.alias = StringHelpers.GetAlias(count, content.name);

                return _db.Insert<Block>(content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    	
    	public void BatchDelete(IEnumerable<long> id)
        {
            try
            {
                _db.Execute("DELETE FROM block WHERE id IN @id", new { id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    	
        public IEnumerable<Block> GetByIDs(IEnumerable<long> id)
        {
            try
            {
                return _db.Query<Block>("SELECT * FROM block WHERE id IN @id", new { id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Block> Search(string blockName)
        {
            try
            {
                var pg = new PredicateGroup { Operator = GroupOperator.Or, Predicates = new List<IPredicate>() };
                pg.Predicates.Add(Predicates.Field<Block>(c => c.name, Operator.Like, "%" + blockName + "%"));
                return _db.GetList<Block>(pg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
