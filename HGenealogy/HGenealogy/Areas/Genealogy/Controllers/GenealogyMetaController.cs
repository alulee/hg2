using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using HGenealogy.Data;
using HGenealogy.Models;
using HGenealogy.Services.Interface;
using AutoMapper;

namespace HGenealogy.Areas.Genealogy.Controllers
{
    public class GenealogyMetaController : Controller
    {
        private hDatabaseEntities db = new hDatabaseEntities();
        private IGeneMetaService myGeneMetaService;
       
        public GenealogyMetaController(IGeneMetaService geneMetaService)
        {
            myGeneMetaService = geneMetaService;
            Mapper.CreateMap<GeneMetaViewModel, GenealogyMeta>();
            Mapper.CreateMap<GenealogyMeta, GeneMetaViewModel>();
        }

        // GET: Genealogy/GenealogyMeta
        public ActionResult Index()
        {
            int privateGeneMetaCount = 0;
            int publicGeneMetaCount = 0;

            IndexGeneMetaViewModel vm = new IndexGeneMetaViewModel();
            var userId = User.Identity.GetUserId();

            if(!(string.IsNullOrEmpty(userId) ||userId == ""))
            {
                privateGeneMetaCount = (from geneMetaData in db.GenealogyMetas
                                        join userGeneMetaData in db.UserGeneMetas
                                             on geneMetaData.GID equals userGeneMetaData.GeneMetaID
                                        where userGeneMetaData.UserID == userId
                                        select geneMetaData).Count();

            }
            publicGeneMetaCount = db.GenealogyMetas.Where(x => x.IsPublic == true).Count();

            vm.privateGeneMetaCount = privateGeneMetaCount;
            vm.publicGeneMetaCount = publicGeneMetaCount;

            return View(vm);          
        }       

        // GET: Genealogy/GenealogyMeta/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenealogyMeta genealogyMeta = db.GenealogyMetas.Find(id);
            if (genealogyMeta == null)
            {
                return HttpNotFound();
            }
            return View(genealogyMeta);
        }


        public ActionResult GetGeneMetaList(bool isPrivate, bool isPublic)
        {
            List<GenealogyMeta> myGeneMetaList = null;
            List<GeneMetaViewModel> myReturnGeneMetaList = null;
            var userId = User.Identity.GetUserId();
            if (isPrivate && isPublic)
            {
                myGeneMetaList = myGeneMetaService.GetPublicOrAutorizedGeneMeta(userId) as List<GenealogyMeta>;
            }
            else if (isPrivate) 
            {
                myGeneMetaList = myGeneMetaService.GetAutorizedGeneMeta(userId) as List<GenealogyMeta>;
            }
            else
            {
                myGeneMetaList = myGeneMetaService.GetPublicGeneMeta() as List<GenealogyMeta>;
            }

            if (myGeneMetaList != null)
            {
                try
                {
                    myReturnGeneMetaList = Mapper.Map<List<GenealogyMeta>, List<GeneMetaViewModel>>(myGeneMetaList);
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }
            }
 
            return PartialView("_GeneMetaList", myReturnGeneMetaList);
        }
        
        
        // GET: Genealogy/GenealogyMeta/Create
        [Authorize]
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            var model = new EditGeneMetaViewModel();
            using (var Db = new ApplicationDbContext()) 
            {
                var user = Db.Users.Find(userId);
                if (user != null)
                {
                    model.currentUser = user;
                }                
            }

            return View(model);
        }

        // POST: Genealogy/GenealogyMeta/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EditGeneMetaViewModel myGeneMetaVM)
        {

            // 檢查族譜編號 或 族譜名稱是否重複
            if (db.GenealogyMetas.Where(x => x.GID == myGeneMetaVM.geneMeta.GID).Count() > 0)
            {
                ModelState.AddModelError("GID", "族譜編號重複");
            }
            if (db.GenealogyMetas.Where(x => x.GName == myGeneMetaVM.geneMeta.GName).Count() > 0)
            {
                ModelState.AddModelError("GName", "族譜名稱重複");
            }

            using (var Db = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();
                var user = Db.Users.Find(userId);
                if (user != null)
                {
                    myGeneMetaVM.currentUser = user;
                }
            }

            if (ModelState.IsValid)
            {                
                // 設定使用者族譜權限                
                // 檢查是否已存在
                var chkUserGene = db.UserGeneMetas.Where(x => x.UserID == myGeneMetaVM.currentUser.Id &&
                                                              x.GeneMetaID == myGeneMetaVM.geneMeta.GID)
                                        .FirstOrDefault();

                if (chkUserGene != null)
                {
                    chkUserGene.IsAdministrator = true;
                    chkUserGene.IsEditable = true;
                }
                else 
                {
                    var newUserGene = new UserGeneMeta();
                    newUserGene.UserID = myGeneMetaVM.currentUser.Id;
                    newUserGene.GeneMetaID = myGeneMetaVM.geneMeta.GID;
                    newUserGene.IsAdministrator = true;
                    newUserGene.IsEditable = true;

                    db.UserGeneMetas.Add(newUserGene);                    
                }
                
                GenealogyMeta newGeneMeta = Mapper.Map<GenealogyMeta>(myGeneMetaVM.geneMeta);
                newGeneMeta = db.GenealogyMetas.Add(newGeneMeta);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
 
                }
                return RedirectToAction("Index");
            }
            else
            {
                using (var Db = new ApplicationDbContext())
                {
                    var userId = User.Identity.GetUserId();
                    var user = Db.Users.Find(userId);
                    if (user != null)
                    {
                        myGeneMetaVM.currentUser = user;
                    }
                }
                return View(myGeneMetaVM);
            }
        }


        // GET: Genealogy/GenealogyMeta/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EditGeneMetaViewModel myEditViewModel = new EditGeneMetaViewModel();

            using (var Db = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();
                var user = Db.Users.Find(userId);
                if (user != null)
                {
                    myEditViewModel.currentUser = user;
                }
            }

            GenealogyMeta genealogyMeta = db.GenealogyMetas.Find(id);
            HGenealogy.Models.GeneMetaViewModel myViewModel = Mapper.Map<GeneMetaViewModel>(genealogyMeta);

            myEditViewModel.geneMeta = myViewModel;

            if (genealogyMeta == null)
            {
                return HttpNotFound();
            }
            return View(myEditViewModel);
        }

        // POST: Genealogy/GenealogyMeta/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditGeneMetaViewModel myGeneMetaVM)
        {

            // 檢查族譜編號 或 族譜名稱是否重複
            //if (db.GenealogyMetas.Where(x => x.GID == myGeneMetaVM.geneMeta.GID).Count() > 0)
            //{
            //    ModelState.AddModelError("GID", "族譜編號重複");
            //}
            //if (db.GenealogyMetas.Where(x => x.GName == myGeneMetaVM.geneMeta.GName).Count() > 0)
            //{
            //    ModelState.AddModelError("GName", "族譜名稱重複");
            //}

            using (var Db = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();
                var user = Db.Users.Find(userId);
                if (user != null)
                {
                    myGeneMetaVM.currentUser = user;
                }
            }

            if (ModelState.IsValid)
            {
                // 設定使用者族譜權限                
                // 檢查是否已存在
                var chkUserGene = db.UserGeneMetas.Where(x => x.UserID == myGeneMetaVM.currentUser.Id &&
                                                              x.GeneMetaID == myGeneMetaVM.geneMeta.GID)
                                        .FirstOrDefault();

                if (chkUserGene != null)
                {
                    chkUserGene.IsAdministrator = true;
                    chkUserGene.IsEditable = true;
                }
                else
                {
                    var newUserGene = new UserGeneMeta();
                    newUserGene.UserID = myGeneMetaVM.currentUser.Id;
                    newUserGene.GeneMetaID = myGeneMetaVM.geneMeta.GID;
                    newUserGene.IsAdministrator = true;
                    newUserGene.IsEditable = true;

                    db.UserGeneMetas.Add(newUserGene);
                }

                GenealogyMeta newGeneMeta = Mapper.Map<GenealogyMeta>(myGeneMetaVM.geneMeta);
                 
                try
                {
                    db.Entry(newGeneMeta).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {

                }
                return RedirectToAction("Index");
            }
            else
            {
                using (var Db = new ApplicationDbContext())
                {
                    var userId = User.Identity.GetUserId();
                    var user = Db.Users.Find(userId);
                    if (user != null)
                    {
                        myGeneMetaVM.currentUser = user;
                    }
                }
                return View(myGeneMetaVM);
            }
        }


        // GET: Genealogy/GenealogyMeta/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenealogyMeta genealogyMeta = db.GenealogyMetas.Find(id);
            if (genealogyMeta == null)
            {
                return HttpNotFound();
            }
            return View(genealogyMeta);
        }

        // POST: Genealogy/GenealogyMeta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GenealogyMeta genealogyMeta = db.GenealogyMetas.Find(id);
            db.GenealogyMetas.Remove(genealogyMeta);
            db.SaveChanges();
            return RedirectToAction("Index");
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
