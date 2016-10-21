using System;
using System.Collections.Generic;
using Dapper;
using DapperExtensions;
using TravelPeople.Commons.Objects;

namespace TravelPeople.DAL.Repositories
{
	/// <summary>
	/// Description of SliderRepository.
	/// </summary>
	public class SliderRepository : GenericRepository<Slider>
	{
		public void BatchDelete(IEnumerable<long> id)
        {
            try
            {
                _db.Execute("DELETE FROM slider WHERE id IN @id", new { id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    	
        public IEnumerable<Slider> GetByIDs(IEnumerable<long> id)
        {
            try
            {
                return _db.Query<Slider>("SELECT * FROM slider WHERE id IN @id", new { id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Slider> Search(string sliderName)
        {
            try
            {
                var pg = new PredicateGroup { Operator = GroupOperator.Or, Predicates = new List<IPredicate>() };
                pg.Predicates.Add(Predicates.Field<Block>(c => c.name, Operator.Like, "%" + sliderName + "%"));
                return _db.GetList<Slider>(pg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
	}
}
