﻿using System.Runtime.Serialization;

namespace SACS.Library.Rest.Models.BargainFinderMax
{
    [DataContract]
    public class RequestType
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }
    }
}