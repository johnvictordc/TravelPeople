using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPeople.Commons.Objects
{
    public class Node
    {
        public Node()
        {
            this.dateCreated = DateTime.Now;
            this.dateUpdated = DateTime.Now;
        }

        public DateTime dateCreated
        {
            get;

            set;
        }

        public DateTime dateUpdated
        {
            get;

            set;
        }

        public long createdBy
        {
            get;

            set;
        }

        public long updatedBy
        {
            get;

            set;
        }

        public long id
        {
            get;

            set;
        }

        [DisplayName("Enabled")]
        [UIHint("CheckBox")]
        public bool enabled
        {
            get;

            set;
        }
    }

}
