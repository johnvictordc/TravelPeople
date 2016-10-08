using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TravelPeople.Commons.Interfaces;
using TravelPeople.Commons.Objects;

namespace TravelPeople.Web.Models.Nodes
{
    public class MenuViewModel : Menu
    {

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


        [Required(ErrorMessage = "This is required.")]
        [DisplayName("Header Text")]
        [UIHint("TextBox")]
        [MaxLength(50)]
        public string header_text
        {
            get;
            set;
        }

    }
}