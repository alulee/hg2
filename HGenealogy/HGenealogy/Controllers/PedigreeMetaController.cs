using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HGenealogy.Models.PedigreeMeta;
using HGenealogy.Services.Interface;
using AutoMapper;
using HGenealogy.Data;
using HGenealogy.Models;

namespace HGenealogy.Controllers
{
    public class PedigreeMetaController : Controller
    {
        private readonly IPedigreeMetaService _pedigreeMetaService;
        private readonly string NoImageUrl = "/Content/Images/pedi.gif";
        //private readonly IPedigreeInfoService _hGPedigreeInfoService;

        public PedigreeMetaController(
            IPedigreeMetaService PedigreeMetaService
            )
        {
            _pedigreeMetaService = PedigreeMetaService;
            //mappingInit();//暫時先這樣處理
        }


        // GET: PedigreeMeta
        public ActionResult Index()
        {
            ViewBag.Title = "族譜瀏覽";
            List<PedigreeMetaModel> modelList = new List<PedigreeMetaModel>();
            var result = _pedigreeMetaService.GetAll();

            Mapper.Initialize(p => p.CreateMap<PedigreeMeta, PedigreeMetaModel>());
            var models = Mapper.Map<List<PedigreeMeta>, List<PedigreeMetaModel>>(result.ToList());
            return View(models);
        }

        public ActionResult Query()
        {
            return View();
        }

        public ActionResult GetPedigreeMeta(PedigreeMetaQueryModel queryModel)
        {
            var result = _pedigreeMetaService.GetPedigreeMetaList(queryModel);
            if (result == null)
                result = new List<PedigreeMeta>();

            Mapper.Initialize(p => p.CreateMap<PedigreeMeta, PedigreeMetaModel>()
                    .ForMember(org => org.Image, y => y.MapFrom(s => string.IsNullOrWhiteSpace(s.Image) ? NoImageUrl : s.Image))
                    );
            var resultList = Mapper.Map<List<PedigreeMeta>, List<PedigreeMetaModel>>(result);
            return View("Index", resultList);
        }

        //新增族譜基本資料
        public ActionResult Create()
        {
            PedigreeMetaModel model = new PedigreeMetaModel();
            model.PublishDate = System.DateTime.Now;
            ViewBag.Title = "建立您的族譜";
            return View("CreateOrUpdate", model);
        }

        //修改族譜基本資料
        public ActionResult Edit(int id)
        {
            var hGPedigreeMeta = _pedigreeMetaService.GetById(id);

            Mapper.Initialize(p => p.CreateMap<PedigreeMeta, PedigreeMetaModel>());
            var model = Mapper.Map<PedigreeMeta, PedigreeMetaModel>(hGPedigreeMeta);

            ViewBag.Title = "修改您的族譜";
            return View("CreateOrUpdate", model);
        }

        [HttpPost]
        public ActionResult SaveHGPedigreeMeta(PedigreeMetaModel model)
        {
            PedigreeMeta pedigreeMeta = new PedigreeMeta();
            Mapper.Initialize(p => p.CreateMap<PedigreeMetaModel, PedigreeMeta>());
            pedigreeMeta = Mapper.Map<PedigreeMetaModel, PedigreeMeta>(model);

            if (model.Id == 0)//新增
            {
                //pedigreeMeta.Editor = "???";
                //pedigreeMeta.Volumes = 0;
                //pedigreeMeta.Pages = 0;
                //pedigreeMeta.FamilyName = "abc";
                //pedigreeMeta.OriginalAncestor = "";
                //pedigreeMeta.DateMoveToTaiwan = "";
                //pedigreeMeta.TotalGenerations = 0;
                //pedigreeMeta.GenerationToTaiwan = 0;
                //pedigreeMeta.IsPublic = false;
                pedigreeMeta.CreatedOnUtc = System.DateTime.Now;
                pedigreeMeta.CreatedWho = "???";
            }
            if (string.IsNullOrWhiteSpace(pedigreeMeta.FamilyName))
                pedigreeMeta.FamilyName = "";
            if (string.IsNullOrWhiteSpace(pedigreeMeta.AncestorToTaiwan))
                pedigreeMeta.AncestorToTaiwan = "";

            pedigreeMeta.UpdatedOnUtc = System.DateTime.Now;
            pedigreeMeta.UpdatedWho = "???";

            if (pedigreeMeta.Id == 0)//新增
                _pedigreeMetaService.Insert(pedigreeMeta);
            else
                _pedigreeMetaService.Update(pedigreeMeta);

            return RedirectToAction("Index");
            //return Json(new { success = true, message = "" });
        }


        [ChildActionOnly]
        public ActionResult PedigreeSecondMenu(int id)
        {
            var hGPedigreeMeta = _pedigreeMetaService.GetById(id);

            Mapper.Initialize(p => p.CreateMap<PedigreeMeta, PedigreeMetaModel>());
            var model = Mapper.Map<PedigreeMeta, PedigreeMetaModel>(hGPedigreeMeta);
            ViewBag.AvailablePedigreeSelectList = GetAvailablePedigreeSelectList();

            return PartialView("_PedigreeSecondMenu", model);
        }


        public List<SelectListItem> GetAvailablePedigreeSelectList()
        {
            List<SelectListItem> availablePedigreeList = new List<SelectListItem>();
            availablePedigreeList.Add(new SelectListItem { Text = "請選擇族譜", Value = "", Selected = true });
            var result = _pedigreeMetaService.GetAll().ToList();
            if (result != null)
            {
                foreach (var item in result)
                {
                    availablePedigreeList.Add(new SelectListItem
                    {
                        Text = item.Id.ToString(),
                        Value = item.Title
                    });
                }
            }

            return availablePedigreeList;
        }

    }
}