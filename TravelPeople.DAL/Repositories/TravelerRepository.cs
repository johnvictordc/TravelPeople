using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPeople.Commons.Objects;

namespace TravelPeople.DAL.Repositories
{
    public class TravelerRepository : GenericRepository<Traveler>
    {
        public Traveler GetWithPassportVisa(int id)
        {
            try
            {
                PassportRepository passportRepo = new PassportRepository();
                VisaRepository visaRepo = new VisaRepository();

                Traveler traveler = base.GetByID(id);
                traveler.passport = passportRepo.GetByTraveler(id);
                traveler.visas = visaRepo.GetByTraveler(id);

                return traveler;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Traveler> Search(string name)
        {
            try
            {
                var pg = new PredicateGroup { Operator = GroupOperator.Or, Predicates = new List<IPredicate>() };
                pg.Predicates.Add(Predicates.Field<Traveler>(c => c.LastName, Operator.Like, "%" + name + "%"));
                pg.Predicates.Add(Predicates.Field<Traveler>(c => c.FirstName, Operator.Like, "%" + name + "%"));
                pg.Predicates.Add(Predicates.Field<Traveler>(c => c.MiddleName, Operator.Like, "%" + name + "%"));
                return _db.GetList<Traveler>(pg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
