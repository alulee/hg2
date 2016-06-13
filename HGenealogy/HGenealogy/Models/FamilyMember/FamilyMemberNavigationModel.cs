 
namespace HGenealogy.Models.FamilyMember
{
    public partial class FamilyMemberNavigationModel
    {
        public bool HideMeta { get; set; }
        public bool HideBiography { get; set; }
        public int CurrentFamilyMemberId { get; set; }
        public FamilyMemberNavigationEnum SelectedTab { get; set; }
    }

    public enum FamilyMemberNavigationEnum
    {
        Meta = 0,
        Biography = 10 
    }
}