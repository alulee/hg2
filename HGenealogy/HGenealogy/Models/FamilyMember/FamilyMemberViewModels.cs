using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HGenealogy.Data;
using HGenealogy.Models.Common;
using System.Web.Mvc;
using HGenealogy.Models.PedigreeMeta;

namespace HGenealogy.Models.FamilyMember
{
    public class FamilyMemberViewModel 
    {
        public FamilyMemberViewModel()
        {
            Id = 0;
            PedigreeId = 0;
            GenerationSeq = 0;
            FamilyName = "";
            GivenName = "";
            Description = "";
            FatherMemberId = 0;
            MotherMemberId = 0;
            MateMemberId = 0;
            BirthYear = "";
            BirthMonth = "";
            BirthDate = "";
            CurrentAddressId = 0;
            Email = "";
            Phone = "";
            MobilePhone = "";
            Gender = "";
            LungName = "";
            HakkaName = "";
            JobDescription = "";
            ImageUrl = "";

            IsPublic = false;
            IsPublished = false;
            IsDeleted = false;
            DisplayOrder = 0;
            CreatedOnUtc = DateTime.UtcNow;
            UpdatedOnUtc = DateTime.UtcNow;
            CreatedWho = "";
            UpdatedWho = "";

            // Address
            CountryName = "";
            StateProvinceName = "";
            CityName = "";
            Address1 = "";
            CurrentAddressId = 0;
            CurrentAddress = new AddressViewModel();

            IsLoadCurrentPedigreeMeta = false;
            IsLoadParentPedigreeMeta = false;
            IsLoadAddressSelectList = false;
            IsLoadFamilyMemberInfos = false;
            IsLoadPedigreeMembers = false;

            AvailableCountries = new List<SelectListItem>();
            AvailableStateProvinces = new List<SelectListItem>();
            AvailableCities = new List<SelectListItem>();
            AvailablePedigreeMeta = new List<SelectListItem>();
            AvailableFatherMemberList = new List<SelectListItem>();
            AvailableMotherMemberList = new List<SelectListItem>();
            AvailableMateMemberList = new List<SelectListItem>(); 
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "姓")]
        public string FamilyName { get; set; }

        [Required]
        [Display(Name = "名")]
        public string GivenName { get; set; }

        [Required]
        [Display(Name = "個人摘要")]
        public string Description { get; set; }

        public int PedigreeId { get; set; }

        [Display(Name = "世代")]
        public int GenerationSeq { get; set; }
 
        public int FatherMemberId { get; set; }
        public int MotherMemberId { get; set; }
        public int MateMemberId { get; set; }
        public string GGrandFatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string WifeName { get; set; }

        
        public string BirthYear { get; set; }
        public string BirthMonth { get; set; }
        public string BirthDate { get; set; }
        public int CurrentAddressId { get; set; }                

        //[EmailAddress]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }

        [Display(Name = "電話")]
        public string Phone { get; set; }

        [Display(Name = "行動電話")]
        public string MobilePhone { get; set; }
        public string Gender { get; set; }

        [DisplayName("稱謂")]
        public string Title { get; set; }

        [DisplayName("郎名")]
        public string LungName { get; set; }

        [DisplayName("客家名")]
        public string HakkaName { get; set; }

        public string ImportSeqNo { get; set; }
        public string JobDescription { get; set; }
        public string ImageUrl { get; set; }

        public bool IsPublic { get; set; }
        public bool IsPublished { get; set; }
        public bool IsDeleted { get; set; }
        public int DisplayOrder { get; set; }        
        public System.DateTime CreatedOnUtc { get; set; }
        public System.DateTime UpdatedOnUtc { get; set; }
        public string CreatedWho { get; set; }
        public string UpdatedWho { get; set; }
        
        public AddressViewModel CurrentAddress { get; set; }
        public string CountryName { get; set; }
        public string StateProvinceName { get; set; }
        public string CityName { get; set; }
        public string Address1 { get; set; }
        public string FullAddress { get; set; }
                
        public bool IsLoadCurrentPedigreeMeta { get; set; }
        public PedigreeMetaModel CurrentPedigreeMeta{ get; set; }

        public bool IsLoadParentPedigreeMeta { get; set; }
        public PedigreeMetaModel FatherPedigreeMeta { get; set; }
        public PedigreeMetaModel MotherPedigreeMeta { get; set; }
 
        public bool IsLoadAddressSelectList { get; set; }
        public IList<SelectListItem> AvailableCountries { get; set; }
        public IList<SelectListItem> AvailableStateProvinces { get; set; }
        public IList<SelectListItem> AvailableCities { get; set; }
        public IList<SelectListItem> AvailablePedigreeMeta { get; set; }

        public bool IsLoadPedigreeMembers { get; set; } 
        public IList<SelectListItem> AvailableFatherMemberList { get; set; }
        public IList<SelectListItem> AvailableMotherMemberList { get; set; }
        public IList<SelectListItem> AvailableMateMemberList { get; set; }

        public bool IsLoadFamilyMemberInfos { get; set; }
        public IList<FamilyMemberInfoModel> FamilyMemberInfos { get; set; }


    }

 
 
}