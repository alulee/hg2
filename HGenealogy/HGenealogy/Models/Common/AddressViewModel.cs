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
            address = new HGenealogy.Data.Address
            {
                Id = 0,
                Country = "",
                StateProvince = "",
                City = "",
                Address1 = "",
                Address2 = "",
                ZipPostalCode = "",
                ContactName = "",
                ContactEmail = "",
                ContactPhone = "",
                ContactFax = "",
                Longitude = null,
                Latitude = null,
                CustomAttributes = "",
                IsDeleted = false,
                DisplayOrder = 0
            };
        }
        
        public HGenealogy.Data.Address address { get; set; }
        public string FullAdress { get; set; }                     
    }
}