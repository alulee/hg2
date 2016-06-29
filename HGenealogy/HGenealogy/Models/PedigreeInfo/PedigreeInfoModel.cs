using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HGenealogy.Models.PedigreeInfo
{
    public class PedigreeInfoModel
    {
        public int Id { get; set; }
        public int PedigreeID { get; set; }
        public string InfoType { get; set; }
        [DisplayName("資料抬頭")]
        [Required]
        public string InfoTitle { get; set; }
        [DisplayName("描述")]
        [Required]
        public string InfoContent { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public string CreatedWho { get; set; }
        public string UpdatedWho { get; set; }

        //public HGenealogy.Models.PedigreeMeta.PedigreeMetaModel pedigreeMetaModel { get; set; }
    }
}