using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TravelPeople.Commons.Interfaces;

namespace TravelPeople.Service.Models.ViewModels
{
    public class LoginViewModel : IUser
    {
        [Required(ErrorMessage = "Username is required.")]
        [DisplayName("Username")]
        [UIHint("TextBox")]
        public string username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DisplayName("Password")]
        [UIHint("TextPassword")]
        public string password { get; set; }
    }
}