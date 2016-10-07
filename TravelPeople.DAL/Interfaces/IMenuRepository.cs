using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPeople.Commons.Objects;

namespace TravelPeople.DAL.Interfaces
{
    public interface IMenuRepository
    {

        long Add(Menu menu);

        long Update(Menu menu);

        void Delete(long id);

        void Delete(IEnumerable<long> id);

        List<Menu> GetAll();

        List<Menu> GetByPosition(long position);

        Menu GetById(long id);

        Menu GetByAlias(string alias);

    }
}
