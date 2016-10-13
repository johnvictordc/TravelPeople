using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPeople.Commons.Objects;

namespace TravelPeople.DAL.Interfaces
{
    interface IUserRepository
    {

        List<User> GetAll();

        User Login(User user);

    }
}
