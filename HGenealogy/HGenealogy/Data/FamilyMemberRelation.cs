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
    
    public partial class FamilyMemberRelation
    {
        public int Id { get; set; }
        public int FamilyMemberId { get; set; }
        public int RelatedFamilyMemberId { get; set; }
        public string RelationType { get; set; }
        public System.DateTime CreatedOnUtc { get; set; }
        public System.DateTime UpdatedOnUtc { get; set; }
        public string CreatedWho { get; set; }
        public string UpdatedWho { get; set; }
        public byte[] LastChanged { get; set; }
    }
}
