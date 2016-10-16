using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPeople.Commons.Objects;

namespace TravelPeople.DAL.Repositories
{
    public class PassportRepository : GenericRepository<Passport>
    {

        public Passport GetByTraveler(int traveler)
        {
            try
            {
                var predicate = Predicates.Field<Passport>(p => p.travelerID, Operator.Eq, traveler);
                return _db.Get<Passport>(predicate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
