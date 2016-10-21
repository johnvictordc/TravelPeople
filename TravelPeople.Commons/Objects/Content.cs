using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPeople.Commons.Objects
{
    public class Content : Node
    {
    	[Required(ErrorMessage = "Name is required.")]
		[StringLength(50)]
		[UIHint("TextBox")]
		[DisplayName("Title")]
        public string name
        {
            get;

            set;
        }

        [UIHint("CKEditor")]
		[DisplayName("Body")]
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

        [StringLength(50)]
		[UIHint("TextBox")]
		[DisplayName("Meta Description")]
        public string metaDescription
        {
            get;

            set;
        }

        [StringLength(50)]
		[UIHint("TextBox")]
		[DisplayName("Meta Tags")]
        public string metaTags
        {
            get;

            set;
        }
    }
}
