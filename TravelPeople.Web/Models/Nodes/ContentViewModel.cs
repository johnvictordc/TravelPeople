using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelPeople.Commons.Interfaces;
using TravelPeople.Commons.Objects;

namespace TravelPeople.Web.Models.Nodes
{
    public class ContentViewModel : Node, IContent
    {

        [Required(ErrorMessage = "This is required.")]
        [DisplayName("Title")]
        [UIHint("TextBox")]
        [MaxLength(50)]
        public new string name
        {
            get;

            set;
        }

        [DisplayName("Enabled")]
        [UIHint("CheckBox")]
        public new bool enabled
        {
            get;

            set;
        }
        
        [AllowHtml]
        [DisplayName("Content")]
        [UIHint("CKEditor")]
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