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
    }
}
