using Dapper;
using DapperExtensions;
using DapperExtensions.Mapper;
using TravelPeople.Commons.Objects;

namespace TravelPeople.Commons
{
    public class MenuMapper : ClassMapper<Menu>
    {
        public MenuMapper()
        {
            base.Map(m => m.items).Ignore();
            base.AutoMap();
        }
    }

    public class CompanyMapper : PluralizedAutoClassMapper<Company>
    {
        public CompanyMapper()
        {
            base.Table("company");
        }
    }

    public class TravelerMapper : PluralizedAutoClassMapper<Traveler>
    {
        public TravelerMapper()
        {
            base.Table("traveler");
        }
    }
}
