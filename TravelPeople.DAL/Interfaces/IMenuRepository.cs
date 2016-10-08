using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPeople.Commons.Interfaces;
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

        List<Menu> GetAll(bool withItems);

        List<Menu> GetByPosition(long position);

        List<Menu> GetByPosition(long position, bool withItems);

        Menu GetById(long id);

        Menu GetById(long id, bool withItems);

        Menu GetByAlias(string alias);

        Menu GetByAlias(string alias, bool withItems);

        long AddItem(MenuItem item);

        long UpdateItem(MenuItem item);

        void DeleteItem(long id);

        void DeleteItems(IEnumerable<long> id);

        void DeleteItemsByMenu(long menu);

        void DeleteItemsByMenus(IEnumerable<long> menus);

        List<MenuItem> GetItems(long menu);

        List<MenuItem> GetItems(long menu, bool enabled, bool authenticated);

        List<Menu> SelectMenu();

    }
}
