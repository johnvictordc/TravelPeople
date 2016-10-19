using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPeople.Commons.Objects.Booking;
using Dapper;
using DapperExtensions;

namespace TravelPeople.DAL.Repositories
{
    public class SearchHeaderRepository : GenericRepository<SearchHeader>
    {

        public override long Insert(SearchHeader header)
        {
            try
            {
                _db.Query(@"
                    insert into bkgSearchHeader(source, DateCreated, agent, BookingType, WorkDone, LastUpdated, UpdatedBy)
                    values(@Source, @DateCreated, @Agent, @BookingType, @WorkDone, @LastUpdated, @UpdatedBy)
                ", header);

                return _db.GetList<SearchHeader>().OrderByDescending(x => x.BookingReference).FirstOrDefault().BookingReference;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

    }
}
