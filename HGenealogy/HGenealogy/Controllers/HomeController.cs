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
        private readonly IPedigreeMetaService _pedigreeMetaService;
        private readonly string NoImageUrl = "~/Content/Images/pedi.gif";

        public HomeController(
            INewsService newsService,
            IPedigreeMetaService pedigreeMetaService
            )
        {
            _newsService = newsService;
            _pedigreeMetaService = pedigreeMetaService;
        }

        public ActionResult Index()
        {
            var homeModel = new HomeModel();
            homeModel.newsList = GetNews();
            homeModel.pedigreeMetaList = GetPedigreeMeta();

            var newsList = GetNews();
            return View(homeModel);
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

        public List<PedigreeMetaModel> GetPedigreeMeta()
        {
            var result = _pedigreeMetaService.GetAll().ToList(); //先取全部,之後要加入取有效日期區間
            if (result == null)
                result = new List<PedigreeMeta>();

            Mapper.Initialize(p => p.CreateMap<PedigreeMeta, PedigreeMetaModel>()
                    );
            var resultList = Mapper.Map<List<PedigreeMeta>, List<PedigreeMetaModel>>(result);

            foreach (var item in resultList)
            {
                try
                {
                    if (string.IsNullOrEmpty(item.Image))
                    {
                        item.Image = NoImageUrl;
                    }
                    else
                    {
                        if (!item.Image.StartsWith("~/"))
                            item.Image =  "~/" + item.Image;
                    }
                }
                catch { }
            }
            return resultList;
        }
    }
}