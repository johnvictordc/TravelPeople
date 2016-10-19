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
    public class PassportRepository : GenericRepository<Passport>
    {

        public Passport GetByTraveler(int traveler)
        {
            try
            {
                Passport passport = _db.QuerySingleOrDefault<Passport>("SELECT * FROM passports WHERE travelerID = @id", new { id = traveler});
                if (passport == null)
                {
                    return new Passport();
                }
                else
                {
                    return passport;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
