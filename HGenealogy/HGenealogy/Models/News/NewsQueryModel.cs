using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HGenealogy.Models.News
{
    public class NewsQueryModel
    {
        public int Id { get; set; }
        [DisplayName("標題")]
        public string Title { get; set; }
        public string StartDateYY { get; set; }
        public string StartDateMM { get; set; }
        public string StartDateDD { get; set; }
        [DisplayName("結束日期")]
        public System.DateTime EndDate { get; set; }
    }
}