using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPeople.Commons.Interfaces;

namespace TravelPeople.Commons.Objects
{
    public class Content : INode, ICreator, IContent
    {
        public Content()
        {
            this.date_created = new DateTime();
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

        public string id
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

        
        public string content
        {
            get;

            set;
        }

     
        public long type
        {
            get;

            set;
        }

        public string alias
        {
            get;

            set;
        }

        public string meta_description
        {
            get;

            set;
        }

        public string meta_tags
        {
            get;

            set;
        }
    }
}
