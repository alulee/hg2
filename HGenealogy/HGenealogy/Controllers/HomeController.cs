using AutoMapper;
using HGenealogy.Data;
using HGenealogy.Models.Home;
using HGenealogy.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HGenealogy.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsService _newsService;

        public HomeController(
            INewsService newsService
            )
        {
            _newsService = newsService;
        }

        public ActionResult Index()
        {
            var newsList = GetNews();
            return View(newsList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "客家族譜平台";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "客家族譜平台";

            return View();
        }



        public List<NewsModel> GetNews()
        {
            var result = _newsService.GetAll().ToList(); //先取全部,之後要加入取有效日期區間
            if (result == null)
                result = new List<News>();

            Mapper.Initialize(p => p.CreateMap<News, NewsModel>()
                    );
            var resultList = Mapper.Map<List<News>, List<NewsModel>>(result);

            return resultList;
        }
    }
}