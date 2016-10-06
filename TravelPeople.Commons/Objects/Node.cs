using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPeople.Commons.Interfaces;

namespace TravelPeople.Commons.Objects
{
    public class Node : INode, ICreator
    {
        public Node()
        {
            this.date_created = DateTime.Now;
            this.date_updated = DateTime.Now;
        }

        public DateTime date_created
        {
            get;

            set;
        }

        public DateTime date_updated
        {
            get;

            set;
        }

        public long created_by
        {
            get;

            set;
        }

        public long updated_by
        {
            get;

            set;
        }

        public long id
        {
            get;

            set;
        }


        public string name
        {
            get;

            set;
        }


        public bool enabled
        {
            get;

            set;
        }
    }

}
