using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HGenealogy.Models.PedigreeMeta
{
    public class PedigreeMetaModel
    {
        [DisplayName("族譜編號")]
        public int Id { get; set; }
        [DisplayName("族譜名稱")]
        [Required]
        public string Title { get; set; }
        [DisplayName("編纂者")]
        [Required]
        public string Editor { get; set; }
        [DisplayName("簡述")]
        [Required]
        public string Description { get; set; }
        [DisplayName("族譜圖片")]
        public string Image { get; set; }
        [DisplayName("出版日期")]
        public DateTime PublishDate { get; set; }
        [DisplayName("卷數（冊）")]
        public int Volumes { get; set; }
        [DisplayName("頁數")]
        public int Pages { get; set; }
        [DisplayName("姓氏")]
        [Required]
        public string FamilyName { get; set; }
        [DisplayName("始祖")]
        public string OriginalAncestor { get; set; }
        [DisplayName("來臺年代")]
        public string DateMoveToTaiwan { get; set; }
        [DisplayName("來臺祖")]
        public string AncestorToTaiwan { get; set; }
        [DisplayName("原籍")]
        public string OriginalAddress { get; set; }
        [DisplayName("世代數")]
        public int TotalGenerations { get; set; }
        [DisplayName("來臺世代")]
        public int GenerationToTaiwan { get; set; }
        [DisplayName("來臺包含地區")]
        public string LivingAreaInTaiwan { get; set; }
        [DisplayName("原件珍藏者(單位)")]
        public string OriginalCollector { get; set; }
        [DisplayName("附註")]
        public string ContentNotes { get; set; }
        [DisplayName("堂號")]
        public string TangName { get; set; }
        [DisplayName("是否公開")]
        public bool IsPublic { get; set; }
        [DisplayName("建立日期")]
        public DateTime CreatedOnUtc { get; set; }
        [DisplayName("修改日期")]
        public DateTime UpdatedOnUtc { get; set; }
        [DisplayName("建立人")]
        public string CreatedWho { get; set; }
        [DisplayName("修改人")]
        public string UpdatedWho { get; set; }
    }
}