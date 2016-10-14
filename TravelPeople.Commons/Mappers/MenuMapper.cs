using DapperExtensions.Mapper;
using TravelPeople.Commons.Objects;

namespace TravelPeople.Commons.Mappers
{
    public class MenuMapper : ClassMapper<Menu>
    {
        public MenuMapper()
        {
            base.Map(m => m.items).Ignore();
            base.AutoMap();
        }
    }
}
