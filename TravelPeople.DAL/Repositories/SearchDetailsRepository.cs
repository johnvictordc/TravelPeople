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
    public class SearchDetailsRepository : GenericRepository<SearchDetail>
    {

        public override long Insert(SearchDetail detail)
        {
            try
            {
                _db.Query(@"
                    insert into bkgSearchDetails(OriginCode, DestinationCode, EDD, BookingReference)
                    values(@OriginCode, @DestinationCode, @EDD, @BookingReference)
                ", detail);

                return _db.GetList<SearchDetail>().OrderByDescending(x => x.BookingLine).FirstOrDefault().BookingLine;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsertMultiple(IEnumerable<SearchDetail> details)
        {
            using(var tx = _db.BeginTransaction())
            {
                try
                {
                    foreach (var detail in details)
                    {
                        _db.Insert(detail);
                    }
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw ex;
                }
            }
        }

    }
}
