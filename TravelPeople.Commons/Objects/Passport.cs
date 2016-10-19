using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPeople.Commons.Objects
{
    public class Passport
    {

        public Passport() 
        {
            this.DateIssued = DateTime.Now;
            this.ExpiryDate = DateTime.Now;
        }

        public Passport(int travelerID)
        {
            this.travelerID = travelerID;
            this.DateIssued = DateTime.Now;
            this.ExpiryDate = DateTime.Now;
        }

        public int passportID
        {
            get;

            set;
        }

        [Required(ErrorMessage = "Passport Number is required.")]
        [StringLength(20)]
        [UIHint("TextBox")]
        [DisplayName("Passport Number")]
        public string PassportNumber
        {
            get;

            set;
        }

        [Required(ErrorMessage = "Country is required.")]
        [UIHint("SelectCountry")]
        [DisplayName("Country")]
        public int Country
        {
            get;

            set;
        }

        [Required(ErrorMessage = "Nationality is required.")]
        [UIHint("SelectCountry")]
        [DisplayName("Nationality")]
        public int Nationality
        {
            get;

            set;
        }

        [Required(ErrorMessage = "Place Issued is required.")]
        [StringLength(50)]
        [UIHint("TextBox")]
        [DisplayName("Place Issued")]
        public string PlaceIssue
        {
            get;

            set;
        }

        [Required(ErrorMessage = "Date Issued is required.")]
        [UIHint("TextDate")]
        [DisplayName("DateIssued")]
        public DateTime DateIssued
        {
            get;

            set;
        }

        [Required(ErrorMessage = "Expiry Date is required.")]
        [UIHint("TextDate")]
        [DisplayName("Expiry Date")]
        public DateTime ExpiryDate
        {
            get;

            set;
        }

        [UIHint("CheckBox")]
        [DisplayName("Dual Citizen")]
        public bool DualCitizen
        {
            get;

            set;
        }

        public int travelerID
        {
            get;

            set;
        }

    }
}
