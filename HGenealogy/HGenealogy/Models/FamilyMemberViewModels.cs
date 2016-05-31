using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HGenealogy.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HGenealogy.Models
{
    public class FamilyMemberViewModel 
    {
        public FamilyMemberViewModel()
        {
            Id = 0;
            FamilyName = "";
            GivenName = "";
            Description = "";
            FatherMemberId = 0;
            MotherMemberId = 0;
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
            IsPublic = false;
            IsPublished = false;
            IsDeleted = false;
            DisplayOrder = 0;
            CreatedOnUtc = DateTime.UtcNow;
            UpdatedOnUtc = DateTime.UtcNow;
            CreatedWho = "";
            UpdatedWho = "";
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "姓")]
        public string FamilyName { get; set; }

        [Required]
        [Display(Name = "名")]
        public string GivenName { get; set; }

        [Display(Name = "個人摘要")]
        public string Description { get; set; }
                
        public int FatherMemberId { get; set; }
        public int MotherMemberId { get; set; }
        public string BirthYear { get; set; }
        public string BirthMonth { get; set; }
        public string BirthDate { get; set; }
        public int CurrentAddressId { get; set; }

        //[EmailAddress]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }

        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Gender { get; set; }

        [DisplayName("郎名")]
        public string LungName { get; set; }

        [DisplayName("客家名")]
        public string HakkaName { get; set; }

        public string JobDescription { get; set; }
        public bool IsPublic { get; set; }
        public bool IsPublished { get; set; }
        public bool IsDeleted { get; set; }
        public int DisplayOrder { get; set; }
        public System.DateTime CreatedOnUtc { get; set; }
        public System.DateTime UpdatedOnUtc { get; set; }
        public string CreatedWho { get; set; }
        public string UpdatedWho { get; set; }
    }


    public class FamilyMembersViewModel
    {
        public GenealogyMeta geneMeta { get; set; }
        public IList<FamilyViewModel> families { get; set; }
    }

    public class AddFamilyMemberViewModel
    {
        public GenealogyMeta pedigreeMeta { get; set; }
        public FamilyMemberViewModel familyMember { get; set; }
    }

}