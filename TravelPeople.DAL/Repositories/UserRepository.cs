using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TravelPeople.DAL.Interfaces;
using TravelPeople.Commons.Interfaces;
using TravelPeople.Commons.Objects;

namespace TravelPeople.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _db;

        public UserRepository()
        {
            _db = new SqlConnection(ConfigurationManager.ConnectionStrings["TravelPeople"].ConnectionString);
        }
        
        public List<User> GetAll()
        {
            try
            {
                return _db.Query<User>("Select * From cmsUsers").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public User Login(User user)
        {
            try
            {
                return _db.QuerySingleOrDefault<User>("SELECT * FROM cmsUsers WHERE username = @username AND password = @password", user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
