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

                    SELECT CAST(SCOPE_IDENTITY() as int)
                ";

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
                    WHERE id = @id
                ";

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
                _db.Execute("DELETE FROM menu WHERE id IN(@id)", new { id = id.ToArray() });
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
    }
}
