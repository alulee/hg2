using HGenealogy.Data;
using HGenealogy.Models.PedigreeInfo;
using HGenealogy.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace HGenealogy.Controllers
{
    public class PedigreeInfoController : Controller
    {
        private readonly IPedigreeMetaService _pedigreeMetaService;
        private readonly IPedigreeInfoService _pedigreeInfoService;
        private readonly IPedigreeEventService _pedigreeEventService;
        private readonly int _pedigreeId;

        public PedigreeInfoController(
            IPedigreeMetaService pedigreeMetaService,
            IPedigreeInfoService pedigreeInfoService,
            IPedigreeEventService pedigreeEventService
            )
        {
            _pedigreeMetaService = pedigreeMetaService;
            _pedigreeInfoService = pedigreeInfoService;
            _pedigreeEventService = pedigreeEventService;

            //mappingInit();//暫時先這樣處理
        }

        // GET: PedigreeInfo
        public ActionResult Index(int pedigreeID, string infoType = "Meta")
        {
            if (string.IsNullOrWhiteSpace(infoType))
                infoType = "Meta";

            if (pedigreeID == 0)
                Redirect(Url.Action("PedigreeMeta", "Index"));

            var hGPedigreeMeta = _pedigreeMetaService.GetById(pedigreeID);
            Mapper.Initialize(p => p.CreateMap<PedigreeMeta, PedigreeMetaModel>());
            var hGPedigreeMetaModel = Mapper.Map<PedigreeMeta, PedigreeMetaModel>(hGPedigreeMeta);

            if (infoType=="Event")
            {
                var pedigreeEvenList = GetPedigreeEventList(pedigreeID);
                hGPedigreeMetaModel.pedigreeEventList = pedigreeEvenList;
            }
            else if (infoType != "Meta")
            {
                var pedigreeInfoList = GetPedigreeInfoList(pedigreeID, infoType);
                hGPedigreeMetaModel.pedigreeInfoList = pedigreeInfoList;
            }

            ViewBag.Title = string.Concat(hGPedigreeMeta.Title, "族譜資料");
            ViewBag.currentPedigreeID = pedigreeID;
            ViewBag.currentInfoType = infoType;
            ViewBag.infoTypeDic = getInfoTypeDic();

            Session["currentPedigreeId"] = pedigreeID;
            Session["currentPedigreeTitle"] = hGPedigreeMeta.Title;

            return View(hGPedigreeMetaModel);
        }

        public ActionResult Create(int pedigreeID, string infoType)
        {
            PedigreeInfoModel model = new PedigreeInfoModel();
            model.PedigreeID = pedigreeID;
            model.InfoType = infoType;

            var infoTypeDic = getInfoTypeDic();
            var infoTypeC = infoTypeDic.Where(p => p.Key == infoType).FirstOrDefault().Value;
            ViewBag.Title = string.Concat(infoTypeC, "-新增");
            ViewBag.currentPedigreeID = pedigreeID;
            ViewBag.currentInfoType = infoType;
            ViewBag.infoTypeDic = infoTypeDic;

            return View("CreateOrUpdate", model);
        }

        public ActionResult Edit(int id)
        {
            var pedigreeInfo = _pedigreeInfoService.GetById(id);

            Mapper.Initialize(p => p.CreateMap<PedigreeInfo, PedigreeInfoModel>());
            var model = Mapper.Map<PedigreeInfo, PedigreeInfoModel>(pedigreeInfo);
            var infoTypeDic = getInfoTypeDic();
            var infoTypeC = infoTypeDic.Where(p => p.Key == model.InfoType).FirstOrDefault().Value;
            ViewBag.Title = string.Concat(infoTypeC, "-修改");
            ViewBag.currentPedigreeID = model.PedigreeID;
            ViewBag.currentInfoType = model.InfoType;
            ViewBag.infoTypeDic = infoTypeDic;

            ViewBag.infoTypeSelectList = getInfoTypeSelectList(model.InfoType);
            return View("CreateOrUpdate", model);
        }

        public ActionResult CreatePedigreeEvent(int pedigreeID, string infoType)
        {
            PedigreeEventModel model = new PedigreeEventModel();
            model.PedigreeID = pedigreeID;

            var infoTypeDic = getInfoTypeDic();
            var infoTypeC = infoTypeDic.Where(p => p.Key == infoType).FirstOrDefault().Value;
            ViewBag.Title = string.Concat(infoTypeC, "-新增");
            ViewBag.currentPedigreeID = pedigreeID;
            ViewBag.currentInfoType = infoType;
            ViewBag.infoTypeDic = infoTypeDic;

            return View("CreateOrUpdatePedigreeEvent", model);
        }

        public ActionResult EditPedigreeEvent(int id)
        {
            var pedigreeEvent = _pedigreeEventService.GetById(id);

            Mapper.Initialize(p => p.CreateMap<PedigreeEvent, PedigreeEventModel>());
            var model = Mapper.Map<PedigreeEvent, PedigreeEventModel>(pedigreeEvent);
            var infoTypeDic = getInfoTypeDic();
            var infoTypeC = infoTypeDic.Where(p => p.Key == "Event").FirstOrDefault().Value;
            ViewBag.Title = string.Concat(infoTypeC, "-修改");
            ViewBag.currentPedigreeID = model.PedigreeID;
            ViewBag.currentInfoType = "Event";
            ViewBag.infoTypeDic = infoTypeDic;

            ViewBag.infoTypeSelectList = getInfoTypeSelectList("Event");
            return View("CreateOrUpdatePedigreeEvent", model);
        }

        private List<PedigreeInfoModel> GetPedigreeInfoList(int pedigreeId, string infoType)
        {
            var tempList = _pedigreeInfoService.GetAll()
                                .Where(x => x.PedigreeID == pedigreeId && x.InfoType == infoType)
                                .ToList()
                                ;

            Mapper.Initialize(p => p.CreateMap<PedigreeInfo, PedigreeInfoModel>());
            var models = Mapper.Map<List<PedigreeInfo>, List<PedigreeInfoModel>>(tempList);
            if (models==null)
                models = new List<PedigreeInfoModel>();
            return models;
        }

        private List<PedigreeEventModel> GetPedigreeEventList(int pedigreeId)
        {
            var tempList = _pedigreeEventService.GetAll()
                                .Where(x => x.PedigreeID == pedigreeId)
                                .ToList()
                                ;
            Mapper.Initialize(p => p.CreateMap<PedigreeEvent, PedigreeEventModel>());
            var models = Mapper.Map<List<PedigreeEvent>, List<PedigreeEventModel>>(tempList);
            if (models == null)
                models = new List<PedigreeEventModel>();

            return models;
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SavePedigreeInfo(PedigreeInfoModel model)
        {

            Mapper.Initialize(p => p.CreateMap<PedigreeInfoModel, PedigreeInfo>());
            var pedigreeInfo = Mapper.Map<PedigreeInfoModel, PedigreeInfo>(model);

            if (pedigreeInfo.Id == 0)//新增
            {
                pedigreeInfo.CreatedOnUtc = System.DateTime.Now;
                pedigreeInfo.CreatedWho = "???";
            }

            pedigreeInfo.UpdatedOnUtc = System.DateTime.Now;
            pedigreeInfo.UpdatedWho = "???";

            if (pedigreeInfo.Id == 0)//新增
                _pedigreeInfoService.Insert(pedigreeInfo);
            else
                _pedigreeInfoService.Update(pedigreeInfo);

            return RedirectToAction("Index", "PedigreeInfo", new { pedigreeID = model.PedigreeID, infoType = model.InfoType });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SavePedigreeEvent(PedigreeEventModel model)
        {

            Mapper.Initialize(p => p.CreateMap<PedigreeEventModel, PedigreeEvent>());
            var pedigreeEvent = Mapper.Map<PedigreeEventModel, PedigreeEvent>(model);

            if (pedigreeEvent.Id == 0)//新增
            {
                pedigreeEvent.CreatedOnUtc = System.DateTime.Now;
                pedigreeEvent.CreatedWho = "???";
            }

            pedigreeEvent.UpdatedOnUtc = System.DateTime.Now;
            pedigreeEvent.UpdatedWho = "???";

            if (pedigreeEvent.Id == 0)//新增
                _pedigreeEventService.Insert(pedigreeEvent);
            else
                _pedigreeEventService.Update(pedigreeEvent);

            return RedirectToAction("Index", "PedigreeInfo", new { pedigreeID = model.PedigreeID, infoType = "Event" });
        }

        private SelectList getInfoTypeSelectList(string defalutValue)
        {
            SelectList returnSelectList = null;

            IDictionary<string, string> infoTypeDic = getInfoTypeDic();

            if (string.IsNullOrWhiteSpace(defalutValue))
                returnSelectList = new SelectList(infoTypeDic, "Key", "Value");
            else
                returnSelectList = new SelectList(infoTypeDic, "Key", "Value", defalutValue);
            return returnSelectList;
        }

        private IDictionary<string, string> getInfoTypeDic()
        {
            IDictionary<string, string> infoTypeDic = new Dictionary<string, string>();
            infoTypeDic.Add("Meta", "族譜資料");
            infoTypeDic.Add("Preface", "序言凡例");
            infoTypeDic.Add("History", "家族歷史");
            infoTypeDic.Add("RootDescription", "姓氏源流");
            infoTypeDic.Add("Personage", "名人傳記");
            infoTypeDic.Add("NameRank", "字輩昭穆");
            infoTypeDic.Add("Precept", "族規家訓");
            infoTypeDic.Add("Tomb", "祠宇墳塋");
            infoTypeDic.Add("Event", "族譜事件");
            return infoTypeDic;
        }
    }
}