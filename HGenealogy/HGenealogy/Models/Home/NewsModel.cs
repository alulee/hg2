using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace HGenealogy.Models.Home
{
    public class NewsModel
    {
        public int Id { get; set; }
        [DisplayName("標題")]
        public string Title { get; set; }
        [DisplayName("描述")]
        [Required]
        public string Content { get; set; }
        [DisplayName("開始日期")]
        [Required]
        public System.DateTime StartDate { get; set; }
        [DisplayName("結束日期")]
        [Required]
        public System.DateTime EndDate { get; set; }
    }
}