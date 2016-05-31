using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HGenealogy.Data;
using System.ComponentModel;

namespace HGenealogy.Models
{
    public class FamilyViewModel 
    {
        [DisplayName("編號")]
        public string Id { get; set; }

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
        
        [DisplayName("郎名")]
        public string LungName { get; set; }
        
        [DisplayName("客家名")]
        public string HakkaName { get; set; }
    }


    public class FamiliesViewModel
    {
        public GenealogyMeta geneMeta { get; set; }
        public IList<FamilyViewModel> families { get; set; }
    }

    public class AddFamilyViewModel
    {
        public GenealogyMeta geneMeta { get; set; }
        public FamilyViewModel family { get; set; }
    }

}