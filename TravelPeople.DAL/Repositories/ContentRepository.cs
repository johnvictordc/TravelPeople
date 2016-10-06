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
    public class ContentRepository : IContentRepository
    {
        private readonly IDbConnection _db;

        public ContentRepository()
        {
            _db = new SqlConnection(ConfigurationManager.ConnectionStrings["TravelPeople"].ConnectionString);
        }

        public void Create(Content content)
        {

            try
            {
                _db.Execute("INSERT INTO content(name,content,type,created_by,date_created,updated_by,date_updated,alias,meta_description,meta_tags,enabled) VALUES (@name,@content,@type,@created_by,@date_created,@updated_by,@date_updated,@alias,@meta_description,@meta_tags,@enabled)", content);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
