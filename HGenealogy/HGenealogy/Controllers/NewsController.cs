using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HGenealogy.Models.PedigreeMeta;
using HGenealogy.Services.Interface;
using AutoMapper;
using HGenealogy.Data;
using HGenealogy.Models.News;

namespace HGenealogy.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(
            INewsService NewsService
            )
        {
            _newsService = NewsService;
            //mappingInit();//暫時先這樣處理
        }

        // GET: News
        public ActionResult Index()
        {
            ViewBag.Title = "新聞瀏覽";
            List<News> modelList = new List<News>();
            var result = _newsService.GetAll();

            Mapper.Initialize(p => p.CreateMap<News, NewsModel>());
            var models = Mapper.Map<List<News>, List<NewsModel>>(result.ToList());
            return View(models);
        }


        //新增族譜基本資料
        public ActionResult Create()
        {
            NewsModel model = new NewsModel();
            model.StartDate = System.DateTime.Now;
            model.EndDate = System.DateTime.Now.AddMonths(1);
            ViewBag.Title = "建立新聞";
            return View("CreateOrUpdate", model);
        }

        //修改族譜基本資料
        public ActionResult Edit(int id)
        {
            var news = _newsService.GetById(id);

            Mapper.Initialize(p => p.CreateMap<News, NewsModel>());
            var model = Mapper.Map<News, NewsModel>(news);

            ViewBag.Title = "修改新聞";
            return View("CreateOrUpdate", model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveNews(NewsModel model)
        {

            Mapper.Initialize(p => p.CreateMap<NewsModel, News>());
            var newsEntity = Mapper.Map<NewsModel, News>(model);

            if (newsEntity.Id == 0)//新增
            {
                newsEntity.CreatedOnUtc = System.DateTime.Now;
                newsEntity.CreatedWho = "???";
            }

            newsEntity.UpdatedOnUtc = System.DateTime.Now;
            newsEntity.UpdatedWho = "???";

            if (newsEntity.Id == 0)//新增
                _newsService.Insert(newsEntity);
            else
                _newsService.Update(newsEntity);

            return RedirectToAction("Index", "News");
        }
    }
}