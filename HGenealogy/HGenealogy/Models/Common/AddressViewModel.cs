using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HGenealogy.Models.Common
{
    public class AddressViewModel
    {
        public AddressViewModel()
        {
            Country = "";
            StateProvince = "";
            City = "";
            Address1 = "";
            Address2 = "";
            ZipPostalCode = "";
            ContactName = "";
            ContactEmail = "";
            ContactPhone = "";
            ContactFax = "";
            Longitude = null;
            Latitude = null;
            CustomAttributes = "";
            IsDeleted = false;
            CreatedWho = "";
            UpdatedWho = ""; 
            DisplayOrder = 0;
        }

        public int? Id { get; set; }
        public string Country { get; set; }
        public string StateProvince { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipPostalCode { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string ContactFax { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public string CustomAttributes { get; set; }
        public bool IsDeleted { get; set; }
        public int DisplayOrder { get; set; }
        public System.DateTime? CreatedOnUtc { get; set; }
        public System.DateTime? UpdatedOnUtc { get; set; }
        public string CreatedWho { get; set; }
        public string UpdatedWho { get; set; }
        public byte[] LastChanged { get; set; }

        public string FullAdress { get; set; }                     
    }
}