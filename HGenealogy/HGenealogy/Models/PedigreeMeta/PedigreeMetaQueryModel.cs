using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HGenealogy.Models.PedigreeMeta
{
    public class PedigreeMetaQueryModel
    {
        [DisplayName("族譜編號")]
        public int Id { get; set; }
        [DisplayName("族譜名稱")]
        public string Title { get; set; }
        [DisplayName("編纂者")]
        public string Editor { get; set; }
        [DisplayName("出版日期")]
        public DateTime PublishDate { get; set; }
        public int? PublishDateYY { get; set; }
        public int? PublishDateMM { get; set; }
        public int? PublishDateDD { get; set; }

        [DisplayName("姓氏")]
        public string FamilyName { get; set; }
        [DisplayName("始祖")]
        public string OriginalAncestor { get; set; }
        [DisplayName("入臺年代")]
        public string DateMoveToTaiwan { get; set; }
        [DisplayName("入臺祖")]
        public string AncestorToTaiwan { get; set; }
        [DisplayName("原籍")]
        public string OriginalAddress { get; set; }
        [DisplayName("世代數")]
        public int TotalGenerations { get; set; }
        [DisplayName("入臺世代")]
        public int GenerationToTaiwan { get; set; }
        [DisplayName("入臺包含地區")]
        public string LivingAreaInTaiwan { get; set; }
        [DisplayName("原件珍藏者(單位)")]
        public string OriginalCollector { get; set; }
        [DisplayName("堂號")]
        public string TangName { get; set; }
        [DisplayName("是否公開")]
        public bool IsPublic { get; set; }
    }
}