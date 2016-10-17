using Dapper;
using DapperExtensions;
using DapperExtensions.Mapper;
using System;
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

    public class TravelerMapper : ClassMapper<Traveler>
    {
        public override void Table(string tableName)
        {
            base.Table("travelers");
        }

        public TravelerMapper()
        {
            base.Map(m => m.passport).Ignore();
            base.Map(m => m.visas).Ignore();
            base.AutoMap();
        }
    }


    public class CompanyMapper : PluralizedAutoClassMapper<Company>
    {
        public override void Table(string tableName)
        {
            base.Table("company");
        }
    }

    public class PassportMapper : PluralizedAutoClassMapper<Passport>
    {
        public override void Table(string tableName)
        {
            base.Table("passport");
        }
    }

    public class VisaMapper : PluralizedAutoClassMapper<Visa>
    {
        public override void Table(string tableName)
        {
            base.Table("visa");
        }
    }

}
