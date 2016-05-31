using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using HGenealogy.Data;
using HGenealogy.Models;
using HGenealogy.Services.Interface;
using HGenealogy.SharedClass;
using System.Threading.Tasks;
using AutoMapper;

namespace HGenealogy.Areas.Genealogy.Controllers
{
    public class FamiliesController : Controller
    {
        private hDatabaseEntities db = new hDatabaseEntities();
        private IGeneMetaService myGeneMetaService;
        private IFamilyService myFamilyService;

        public FamiliesController(IGeneMetaService geneMetaService,
                                  IFamilyService familyService)
        {
            myGeneMetaService = geneMetaService;
            myFamilyService = familyService;

            Mapper.CreateMap<FamilyViewModel, Family>();
            Mapper.CreateMap<Family, FamilyViewModel>();
        }


        // GET: Genealogy/Families
        public ActionResult Index(int page = 1)
        {
            // session 讀取 gID
            int currentPage = page < 1 ? 1 : page;

            var query = db.Families.OrderBy(x => x.GenerationNo)
                                    .ThenBy(x => x.Id)
                                    .ThenBy(x => x.BirthDay)
                                    .ToList<Family>();

            List<FamilyViewModel> familyViewModeList = Mapper.Map<List<Family>, List<FamilyViewModel>>(query);

            return View(familyViewModeList.ToPagedList(currentPage, 15));
        }

        // GET: Genealogy/Families/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Family family = db.Families.Find(id);
            if (family == null)
            {
                return HttpNotFound();
            }
            return View(family);
        }

        // GET: Genealogy/Families/GetTree/5
        public ActionResult GetFamilyTreeList(string geneID, string id)
        {
            int fid = 0;
            if (id == null || !int.TryParse(id, out fid))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Family> familyTree = myFamilyService.GetFamilyTreeByID(geneID, fid) as List<Family>;
            if (familyTree == null)
            {
                return HttpNotFound();
            }
            var orderedfamilyTree = familyTree.OrderBy(x => x.GenerationNo);
            return PartialView("_FamilyTreeList", orderedfamilyTree);
 
        }

        // GET: Genealogy/Families/GetTree/5
        [HttpPost]
        public JsonResult GetFamilyTreeListJson(string geneID, string id)
        {
            List<Family> familyTree = new List<Family>();
            
            int fid = 0;
            if (id == null || !int.TryParse(id, out fid))
            {
                return Json(familyTree);
            }
            familyTree = myFamilyService.GetFamilyTreeByID(geneID, fid) as List<Family>;

            if (familyTree == null)
            {
                return Json(familyTree);
            }
            var orderedfamilyTree = familyTree.OrderBy(x => x.GenerationNo);
            List<Family[]> familychain = new List<Family[]>();

            foreach (var f in orderedfamilyTree)
            {
                Family ftemp = f;
                List<Family> newfamilychain = new List<Family>();
                while (true)
                {
                    newfamilychain.Add(ftemp); 
                    if (string.IsNullOrEmpty(ftemp.FatherId) || ftemp.FatherId == "")
                        break;

                    var father = orderedfamilyTree.Where(x => x.Id.ToString() == ftemp.FatherId).FirstOrDefault();
                    if (father != null)
                    {
                        ftemp = father;
                    }
                }
                familychain.Add(newfamilychain.ToArray());
            }

            return Json(new KeyValuePair<Family[], List<Family[]>>(orderedfamilyTree.ToArray(), familychain));

        }

        // GET: Genealogy/Families/Create
        public ActionResult Create(string gID)
        {
            GenealogyMeta gmata = db.GenealogyMetas.Find(gID);

            if (gmata != null)
            {
                AddFamilyViewModel newFamily = new AddFamilyViewModel
                {
                    geneMeta = gmata,
                    family = new FamilyViewModel() 
                };

                newFamily.family.GId = gID;

                return View(newFamily);
            }
            else
            {
                return View("GenealogyNotSelected");
            }
        }

        // POST: Genealogy/Families/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddFamilyViewModel newfamily)
        {
            if (ModelState.IsValid)
            {
                var Family = Mapper.Map<Family>(newfamily.family);
                db.Families.Add(Family);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newfamily.family);
        }

        // GET: Genealogy/Families/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Family family = db.Families.Find(id);
            FamilyViewModel familyViewModel = new FamilyViewModel();            
            if (family == null)
            {
                return HttpNotFound();
            }

            familyViewModel = Mapper.Map<FamilyViewModel>(family);
            return View(familyViewModel);
        }

        // POST: Genealogy/Families/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FamilyViewModel familyViewModel)
        {
            Family family = Mapper.Map<Family>(familyViewModel);
            if (ModelState.IsValid)
            {
                db.Entry(family).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(familyViewModel);

        }

        // GET: Genealogy/Families/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Family family = db.Families.Find(id);
            if (family == null)
            {
                return HttpNotFound();
            }
            return View(family);
        }

        // POST: Genealogy/Families/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {            
            Family family = db.Families.Find(id);
            db.Families.Remove(family);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public bool CorrectEmptyFatherID(string Id)
        {
            if (!string.IsNullOrEmpty(Id) && Id != "")
            {
                List<Family> myFamilyList = myFamilyService.GetFamiliesWithNoFatherIDByGeneID(Id) as List<Family>;
                foreach (var family in myFamilyList)
                {
                    if(string.IsNullOrEmpty(family.FatherName) || family.FatherName == "")
                        continue;

                    var father = myFamilyService.GetFamilyByName(Id, family.FatherName, family.GFatherName);
                    if (father != null) 
                    {
                        // 1. found family data by fathername
                        Family updatefamily = db.Families.Find(family.Id);
                        updatefamily.FatherId = father.Id.ToString();
                        db.SaveChanges();
                        
                    }
                    else 
                    {
                        // 2. not exist father in family, create one
                        var newFamily = new Family 
                                        {
                                            GId = Id, 
                                            FName = family.FatherName,
                                            FatherName = family.GFatherName,
                                            GenerationNo = family.GenerationNo - 1
                                        };
                        db.Families.Add(newFamily);
                        db.SaveChanges();
                    }
                }
            }

            return true;
        }

        public bool CorrectLatLng(string geneMetaId)
        {
            if (!string.IsNullOrEmpty(geneMetaId) && geneMetaId != "")
            {
                List<Family> myFamilyList = myFamilyService.GetFamiliesWithNoLatLng(geneMetaId) as List<Family>;
                foreach (var family in myFamilyList)
                {
                    if (string.IsNullOrEmpty(family.Address) || family.Address == "")
                        continue;

                    double[] latlng = GeoUtil.GetGeoPointFromGoogleAPI(family.Address);

                    if (latlng != null)
                    {
                        Family updatefamily = db.Families.Find(family.Id);
                        updatefamily.AddressLatitude = Convert.ToDecimal(latlng[0]);
                        updatefamily.AddressLongitude = Convert.ToDecimal(latlng[1]);
                        db.SaveChanges();
                    }       
                }
            }

            return true;
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
