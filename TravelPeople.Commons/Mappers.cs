using Dapper;
using DapperExtensions;
using DapperExtensions.Mapper;
using System;
using TravelPeople.Commons.Objects;
using TravelPeople.Commons.Objects.Booking;

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
            base.Map(m => m.Passport).Ignore();
            base.Map(m => m.Visas).Ignore();
            base.AutoMap();
        }
    }

    public class SearchHeaderMapper : ClassMapper<SearchHeader>
    {
        public override void Table(string tableName)
        {
            base.Table("bkgSearchHeader");
        }

        public SearchHeaderMapper() 
        {
            base.Map(m => m.details).Ignore();
            base.AutoMap();
        }
    }

    public class SearchDetailsMapper : ClassMapper<SearchDetail>
    {
        public override void Table(string tableName)
        {
            base.Table("bkgSearchDetails");
        }

        public SearchDetailsMapper()
        {
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

    public class EmployeeMapper : PluralizedAutoClassMapper<Employee>
    {
        public override void Table(string tableName)
        {
            base.Table("employee");
        }
    }

}
