using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPeople.Commons.Objects;
using TravelPeople.DAL.Interfaces;
using Dapper;

namespace TravelPeople.DAL.Repositories
{
    public class ContentRepository : Repository, IContentRepository
    {
        public ContentRepository() : base()
        {
            
        }

        public void Create(Content content)
        {
            
            try
            {

                int count = _db.ExecuteScalar<int>("SELECT COUNT(*) FROM content WHERE name = @name", new {name = content.name});

                if (count == 0)
                {
                    content.alias = content.name.ToLower().Replace(" ", "_");
                }
                else
                {
                    content.alias = content.name.ToLower().Replace(" ", "_") + "_" + count;
                }

                content.type = 1;

                _db.Execute("INSERT INTO content(name,content,type,created_by,date_created,updated_by,date_updated,alias,meta_description,meta_tags,enabled) VALUES (@name,@content,@type,@created_by,@date_created,@updated_by,@date_updated,@alias,@meta_description,@meta_tags,@enabled)", content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Content> GetContents()
        {
            try
            {
               return _db.Query<Content>("SELECT * FROM content").ToList();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }

        public Content GetSingle(long id)
        {
            try
            {
                return _db.QuerySingleOrDefault<Content>("SELECT * FROM content WHERE ID = @id", new {id = id});
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
