using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HGenealogy.Models;
using HGenealogy.Data;
using System.ComponentModel;

namespace HGenealogy.Models
{
    public class VisualGeneMetaViewModel
    {
        public string currentUserID { get; set; }
        public string currentGeneID { get; set; }
        public string currentFamilyID { get; set; }
        public GeneMetaViewModel geneMeta { get; set; }
    }

    public class GeneMetaViewModel
    {
        [DisplayName("族譜編號")]
        public string GID { get; set; }
        [DisplayName("族譜名稱")]
        public string GName { get; set; }
        [DisplayName("是否公開")]
        public bool IsPublic { get; set; }
        [DisplayName("編纂者")]
        public string Editor { get; set; }
        [DisplayName("出版日期")]
        public string PublishDate { get; set; }
        [DisplayName("卷數（冊）")]
        public string Volumes { get; set; }
        [DisplayName("頁數")]
        public int Pages { get; set; }
        [DisplayName("面談者")]
        public string Interviewer { get; set; }
        [DisplayName("姓氏宗派")]
        public string FamilyName { get; set; }
        [DisplayName("始祖")]
        public string OriginalAncestor { get; set; }
        [DisplayName("入臺年代")]
        public string DateMoveToTaiwan { get; set; }
        [DisplayName("入臺祖")]
        public string AncestorToTaiwan { get; set; }
        [DisplayName("原籍")]
        public string OriginalAddress { get; set; }
        [DisplayName("世代")]
        public int Generations { get; set; }
        [DisplayName("入臺世代")]
        public string GenerationToTaiwan { get; set; }
        [DisplayName("原件珍藏者")]
        public string Collector { get; set; }
        [DisplayName("昭穆詞")]
        public string ZhaoMu { get; set; }
        [DisplayName("堂號")]
        public string TangName { get; set; }
    }

    public class IndexGeneMetaViewModel
    {
        public int privateGeneMetaCount { get; set; }
        public int publicGeneMetaCount { get; set; }
    }

    public class EditGeneMetaViewModel
    {
        public ApplicationUser currentUser { get; set; }
        public GeneMetaViewModel geneMeta { get; set; } 
    }

 
}