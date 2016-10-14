using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPeople.Commons.Objects
{
    public class Passport
    {

        public int passportID
        {
            get;

            set;
        }

        public string PassportNumber
        {
            get;

            set;
        }

        public int Country
        {
            get;

            set;
        }

        public int Nationality
        {
            get;

            set;
        }

        public string PlaceIssue
        {
            get;

            set;
        }

        public DateTime DateIssued
        {
            get;

            set;
        }

        public DateTime ExpiryDate
        {
            get;

            set;
        }

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
