using TravelPeople.Commons.Interfaces;

namespace TravelPeople.Commons.Objects
{
    public class User : IUser
    {

        public long id { get; set; }

        public string username { get; set; }

        public string password { get; set; }

    }
}
