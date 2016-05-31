using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HGenealogy.Data;
using HGenealogy.Models;
using HGenealogy.Areas.Genealogy.Models;
using HGenealogy.Services.Interface;

namespace HGenealogy.Areas.Genealogy.Controllers
{
    public class VisualGenealogyController : Controller
    {
        private hDatabaseEntities db = new hDatabaseEntities();
        private IGeneMetaService myGeneMetaService;
        private IFamilyService myFamilyService;

        public VisualGenealogyController(IGeneMetaService geneMetaService,
                                         IFamilyService familyService)
        {
            myGeneMetaService = geneMetaService;
            myFamilyService = familyService;
        }

        // GET: Genealogy/VisualGenealogy
        public ActionResult Index()
        {
            VisualGeneMetaViewModel result = new VisualGeneMetaViewModel();
            List<GenealogyMeta> geneMetas = myGeneMetaService.GetPublicOrAutorizedGeneMeta("userid") as List<GenealogyMeta>;
            List<SelectListItem> geneMetaSelectList = new List<SelectListItem>();
            List<SelectListItem> familiesSelectList = new List<SelectListItem>();
            //result.geneMetas = geneMetas;

            foreach (var g in geneMetas)
            {
                geneMetaSelectList.Add(new SelectListItem()
                {
                    Text = g.GName,
                    Value = g.GID,
                    Selected = g.GID == geneMetas.First().GID
                });
            }
 
            if (geneMetas.Count() >= 0)
            {
                result.currentGeneID = geneMetas.First().GID;
                familiesSelectList = GetFamiliesSelect(result.currentGeneID);  
            }

            ViewBag.geneMetaSelectList = geneMetaSelectList;
            ViewBag.familyPersonSelectList = familiesSelectList;

            // return View(db.Families.ToList());
            return View();
        }

        [HttpPost]
        public JsonResult GetFamiliesJson(string geneMetaId)
        {
            List<Family> myFamilyList = myFamilyService.GetFamiliesByGeneID(geneMetaId) as List<Family>;

            if (myFamilyList == null)
            {
                return null;
            }
            myFamilyList.Add(new Family { Id = 0, FName = "全部顯示", GenerationNo = 0 });
            return this.Json(myFamilyList.OrderBy(x => x.GenerationNo.ToString() + x.FName));
        }
 
        public List<SelectListItem> GetFamiliesSelect(string geneMetaId)
        {
            List<SelectListItem> mySelectListItem = new List<SelectListItem>();
            List<Family> myFamilyList = myFamilyService.GetFamiliesByGeneID(geneMetaId) as List<Family>;

            mySelectListItem.Add(new SelectListItem()
            {
                Text = "全部顯示",
                Value = "0",
                Selected = true
            });

            if (myFamilyList != null && myFamilyList.Count() > 0)
            {                
                foreach (var f in myFamilyList)
                {
                    mySelectListItem.Add(new SelectListItem()
                    {
                        Text = string.Format("{0}世 - {1}", f.GenerationNo ?? 0, f.FName),
                        Value = f.Id.ToString(),
                        Selected = f.Id == myFamilyList.First().Id
                    });
                }
            }
            return mySelectListItem;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
