//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HGenealogy.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class FamilyMember
    {
        public int Id { get; set; }
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        public string Description { get; set; }
        public int FatherMemberId { get; set; }
        public int MotherMemberId { get; set; }
        public string BirthYear { get; set; }
        public string BirthMonth { get; set; }
        public string BirthDate { get; set; }
        public int CurrentAddressId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Gender { get; set; }
        public string LungName { get; set; }
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
        public byte[] LastChanged { get; set; }
    }
}
