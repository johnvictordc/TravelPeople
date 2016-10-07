using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPeople.DAL.Repositories
{
    public class Repository
    {
        protected readonly IDbConnection _db;

        public Repository()
        {
            this._db = new SqlConnection(ConfigurationManager.ConnectionStrings["TravelPeople"].ConnectionString);
        }

    }
}
