using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPeople.Commons.Interfaces
{
    public interface ICreator
    {
        DateTime date_created { get; set; }

        DateTime date_updated { get; set; }

        long created_by { get; set; }

        long updated_by { get; set; }
    }
}
