using Dapper;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPeople.Commons.Objects;

namespace TravelPeople.DAL.Repositories
{
    public class VisaRepository : GenericRepository<Visa>
    {
        public IEnumerable<Visa> GetByTraveler(int traveler)
        {
            try
            {
                return _db.Query<Visa>("SELECT * FROM visas WHERE travelerID = @id", new { id = traveler }).ToList();
                //var predicate = Predicates.Field<Visa>(p => p.travelerID, Operator.Eq, traveler);
                //return _db.GetList<Visa>(predicate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
