using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HGenealogy.Models.PedigreeInfo
{
    public class PedigreeEventModel
    {
        public int Id { get; set; }
        public int PedigreeID { get; set; }
        [DisplayName("抬頭")]
        [Required]
        public string EventTitle { get; set; }
        [DisplayName("內容")]
        [Required]
        public string EventContent { get; set; }
        [DisplayName("日期")]
        [Required]
        [DataType(DataType.Date)]
        public System.DateTime EventDateOnUtc { get; set; }
        [DisplayName("地點")]
        [Required]
        public string EventPlace { get; set; }
        [DisplayName("經度")]
        public Nullable<decimal> Longitude { get; set; }
        [DisplayName("緯度")]
        public Nullable<decimal> Latitude { get; set; }
        [DisplayName("關鍵字")]
        public string MetaKeywords { get; set; }
        public System.DateTime CreatedOnUtc { get; set; }
        public System.DateTime UpdatedOnUtc { get; set; }
        public string CreatedWho { get; set; }
        public string UpdatedWho { get; set; }
    }
}