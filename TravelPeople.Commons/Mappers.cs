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
            base.Map(m => m.passport).Ignore();
            base.Map(m => m.visas).Ignore();
            base.AutoMap();
            base.Table("traveler");
        }
    }

    public class PassportMapper : PluralizedAutoClassMapper<Passport>
    {
        public PassportMapper()
        {
            base.Table("passport");
        }
    }

    public class VisaMapper : PluralizedAutoClassMapper<Visa>
    {
        public VisaMapper()
        {
            base.Table("visa");
        }
    }
}
