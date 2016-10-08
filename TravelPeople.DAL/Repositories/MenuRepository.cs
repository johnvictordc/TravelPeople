using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPeople.Commons.Objects;
using TravelPeople.DAL.Interfaces;
using Dapper;
using Llama.Helpers;

namespace TravelPeople.DAL.Repositories
{
    public class MenuRepository : Repository, IMenuRepository
    {

        public MenuRepository() : base()
        {

        }

        public long Add(Menu menu)
        {
            try
            {
                int count = _db.QuerySingle<int>("SELECT COUNT(*) FROM menu WHERE name = @name", new { name = menu.name });
                menu.alias = StringHelpers.GetAlias(count, menu.name);

                string sql = @"
                    INSERT INTO menu (name, alias, position, created_by, date_created, updated_by, date_updated, enabled, header_text) 
                    VALUES(@name, @alias, @position, @created_by, @date_created, @updated_by, @date_updated, @enabled, @header_text);

                    SELECT CAST(SCOPE_IDENTITY() as int)";

                return _db.Query<long>(sql, menu).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Update(Menu menu)
        {
            try
            {
                string sql = @"
                    UPDATE menu SET 
                            name = @name, 
                            position = @position, 
                            updated_by = @updated_by, 
                            date_updated = @date_updated, 
                            enabled = @enabled, 
                            header_text = @header_text 
                    WHERE id = @id";

                _db.Execute(sql, menu);
                return menu.id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(long id)
        {
            try
            {
                // DELETE ITEMS FIRST BEFORE DELETING THE MENU
                DeleteItemsByMenu(id);
                _db.Execute("DELETE FROM menu WHERE id = @id", new { id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(IEnumerable<long> id)
        {
            try
            {
                DeleteItemsByMenus(id);
                _db.Execute("DELETE FROM menu WHERE id IN @id", new { id = id.ToArray() });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Menu> GetAll()
        {
            try
            {
                return _db.Query<Menu>("SELECT * FROM menu").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Menu> GetAll(bool withItems)
        {
            try
            {
                List<Menu> menus = _db.Query<Menu>("SELECT * FROM menu").ToList();

                if (withItems == true)
                {
                    foreach (var menu in menus)
                    {
                        menu.items = GetItems(menu.id);
                    }
                }

                return menus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Menu> GetByPosition(long position)
        {
            try
            {
                return _db.Query<Menu>("SELECT * FROM menu WHERE position = @position", new { position = position }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Menu> GetByPosition(long position, bool withItems)
        {
            try
            {
                List<Menu> menus = _db.Query<Menu>("SELECT * FROM menu WHERE position = @position", new { position = position }).ToList();

                if (withItems == true)
                {
                    foreach (var menu in menus)
                    {
                        menu.items = GetItems(menu.id);
                    }
                }

                return menus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Menu GetById(long id)
        {
            try
            {
                return _db.QuerySingleOrDefault<Menu>("SELECT * FROM menu WHERE id = @id", new { id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Menu GetById(long id, bool withItems)
        {
            try
            {
                Menu menu = _db.QuerySingleOrDefault<Menu>("SELECT * FROM menu WHERE id = @id", new { id = id });

                if (withItems == true) 
                {
                    menu.items = GetItems(id);
                }

                return menu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Menu GetByAlias(string alias)
        {
            try
            {
                return _db.QuerySingleOrDefault<Menu>("SELECT * FROM menu WHERE alias = @alias", new { alias = alias });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Menu GetByAlias(string alias, bool withItems)
        {
            try
            {
                Menu menu = _db.QuerySingleOrDefault<Menu>("SELECT * FROM menu WHERE alias = @alias", new { alias = alias });

                if (withItems == true) 
                {
                    menu.items = GetItems(menu.id);
                }

                return menu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long AddItem(MenuItem item)
        {
            try
            {
                string sql = @"
                    INSERT INTO menuItems (text, link, menu, created_by, date_created, updated_by, date_updated, authenticated, enabled) 
                    VALUES(@text, @link, @menu, @created_by, @date_created, @updated_by, @date_updated, @authenticated, @enabled);

                    SELECT CAST(SCOPE_IDENTITY() as int)";

                return _db.Query<long>(sql, item).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long UpdateItem(MenuItem item)
        {
            try
            {
                string sql = @"
                    UPDATE menuItems SET 
                            text = @text, 
                            link = @link,
                            menu = @menu,
                            updated_by = @updated_by,
                            date_updated = @date_updated,
                            authenticated = @authenticated,
                            enabled = @enabled
                    WHERE id = @id";

                _db.Execute(sql, item);
                return item.id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteItem(long id)
        {
            try
            {
                _db.Execute("DELETE FROM menuItems WHERE id = @id", new { id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteItems(IEnumerable<long> id)
        {
            try
            {
                _db.Execute("DELETE FROM menuItems WHERE id IN @id", new { id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteItemsByMenu(long menu)
        {
            try
            {
                _db.Execute("DELETE FROM menuItems WHERE menu = @menu", new { menu = menu });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteItemsByMenus(IEnumerable<long> menus)
        {
            try
            {
                _db.Execute("DELETE FROM menuItems WHERE menu IN @menu", new { menu = menus });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MenuItem> GetItems(long menu)
        {
            try
            {
                return _db.Query<MenuItem>("SELECT * FROM menuItems WHERE menu = @menu", new { menu = menu }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MenuItem> GetItems(long menu, bool enabled, bool authenticated)
        {
            try
            {
                return _db.Query<MenuItem>("SELECT * FROM menuItems WHERE menu = @menu AND enabled = @enabled AND authenticated = @authenticated", new { menu = menu, enabled = enabled, authenticated = authenticated }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Menu> SelectMenu()
        {
            try
            {
                return _db.Query<Menu>("SELECT id, name FROM menu").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
