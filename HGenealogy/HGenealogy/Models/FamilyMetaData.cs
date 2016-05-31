using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HGenealogy.Models
{
    [System.ComponentModel.DataAnnotations.MetadataType(typeof(FamilyMetaData))]
    public partial class FamilyMetaData
    {
        [DisplayName("編號")]
        public string FId { get; set; }
        [DisplayName("名")]
        public string FName { get; set; }
        [DisplayName("族譜編號")]
        public string GId { get; set; }
        public string FatherId { get; set; }
        public string MotherId { get; set; }
        public Nullable<System.DateTime> BirthDay { get; set; }
        [DisplayName("住址")]
        public string Address { get; set; }
        [DisplayName("住址(經度)")]
        public Nullable<decimal> AddressLongitude { get; set; }
        [DisplayName("住址(緯度)")]
        public Nullable<decimal> AddressLatitude { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        [DisplayName("父")]
        public string FatherName { get; set; }
        [DisplayName("母")]
        public string MoterName { get; set; }
        public string GFatherName { get; set; }
        public string GGFatherName { get; set; }
        public string Gender { get; set; }
        public string Mate { get; set; }
        [DisplayName("世代")]
        public Nullable<int> GenerationNo { get; set; }
        public string Job { get; set; }
        public string Notes { get; set; }
        public string Childrens { get; set; }
    }
}
