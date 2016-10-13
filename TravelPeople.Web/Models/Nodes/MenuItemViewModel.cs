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
    public class MenuItemViewModel : MenuItem, IMenuItem
    {

        [Required(ErrorMessage = "Name is required.")]
        [UIHint("TextBox")]
        [DisplayName("Name")]
        public string text { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Link is required.")]
        [UIHint("TextBox")]
        [DisplayName("Link / URL")]
        public string link { get; set; }

        public long menu { get; set; }

        [DisplayName("Enabled")]
        [UIHint("CheckBox")]
        public bool authenticated
        {
            get;

            set;
        }

    }
}