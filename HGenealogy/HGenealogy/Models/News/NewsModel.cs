using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HGenealogy.Models.News
{
    public class NewsModel
    {
        public int Id { get; set; }
        [DisplayName("標題")]
        [Required]
        public string Title { get; set; }
        [DisplayName("描述")]
        [Required]
        public string Content { get; set; }
        [DisplayName("関始日期")]
        [Required]
        public System.DateTime StartDate { get; set; }
        [DisplayName("結束日期")]
        [Required]
        public System.DateTime EndDate { get; set; }
        public System.DateTime CreatedOnUtc { get; set; }
        public System.DateTime UpdatedOnUtc { get; set; }
        public string CreatedWho { get; set; }
        public string UpdatedWho { get; set; }
    }
}