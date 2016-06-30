using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HGenealogy.Models.Home
{
    public class HomeModel
    {
        public List<NewsModel> newsList { get; set; }
        public List<PedigreeMetaModel> pedigreeMetaList { get; set; }
    }
}