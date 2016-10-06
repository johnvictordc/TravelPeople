using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelPeople.Commons.Interfaces;

namespace TravelPeople.Web.Models.Node
{
    public class ContentViewModel : INode, ICreator, IContent
    {

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

        [Required(ErrorMessage = "This is required.")]
        [DisplayName("Title")]
        [UIHint("TextBox")]
        [MaxLength(50)]
        public string name
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
        
        [AllowHtml]
        [DisplayName("Content")]
        public string content
        {
            get;

            set;
        }

        [Required(ErrorMessage = "Type is required.")]
        [DisplayName("Type")]
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

        [UIHint("TextArea")]
        [DisplayName("Meta Description")]
        [MaxLength(200)]
        public string meta_description
        {
            get;

            set;
        }

        [DisplayName("Meta Tags")]
        [MaxLength(100)]
        public string meta_tags
        {
            get;

            set;
        }
    }
}