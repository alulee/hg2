using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HGenealogy.Data;
using AutoMapper;
using HGenealogy.Models;

namespace HGenealogy.Controllers
{
    public class FamilyMembersController : Controller
    {
        private hDatabaseEntities db = new hDatabaseEntities();

        public FamilyMembersController()
        {           
            Mapper.CreateMap<FamilyMemberViewModel, FamilyMember>();
            Mapper.CreateMap<FamilyMember, FamilyMemberViewModel>();
        }

        // GET: FamilyMembers
        public ActionResult Index()
        {            
            if (Session["CurrentPedigreeId"] != null)
            {
            }
            return View(db.FamilyMembers.ToList());
        }

        public ActionResult IndexByPedigree()
        {
            if (Session["CurrentPedigreeId"] != null)
            {
            }
            return View(db.FamilyMembers.ToList());
        }

        public ActionResult List()
        {
            if (Session["CurrentPedigreeId"] != null)
            {
            }
            return View(db.FamilyMembers.ToList());
        }

        // GET: FamilyMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyMember familyMember = db.FamilyMembers.Find(id);
            if (familyMember == null)
            {
                return HttpNotFound();
            }
            return View(familyMember);
        }

        // GET: FamilyMembers/Create
        public ActionResult Create()
        {
            if (Session["CurrentPedigreeId"] != null)
            {
            }

            AddFamilyMemberViewModel newFamily = new AddFamilyMemberViewModel
            {
                familyMember = new FamilyMemberViewModel()
            };            

            return View(newFamily); 
        }

        // POST: FamilyMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddFamilyMemberViewModel addfamilyMember)
        {
            if (ModelState.IsValid)
            {
                var newFamilyMember = Mapper.Map<FamilyMember>(addfamilyMember.familyMember);
                db.FamilyMembers.Add(newFamilyMember);
                try
                {
                    db.SaveChanges();
                }catch(Exception ex)
                {
                    string s = ex.Message;
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: FamilyMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyMember familyMember = db.FamilyMembers.Find(id);
            if (familyMember == null)
            {
                return HttpNotFound();
            }
            return View(familyMember);
        }

        // POST: FamilyMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FamilyName,GivenName,Description,FatherMemberId,MotherMemberId,BirthDay,CurrentAddressId,Email,Phone,MobilePhone,Gender,LungName,HakkaName,JobDescription,IsPublic,IsPublished,IsDeleted,DisplayOrder,CreatedOnUtc,UpdatedOnUtc,CreatedWho,UpdatedWho,LastChanged")] FamilyMember familyMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(familyMember).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(familyMember);
        }

        // GET: FamilyMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyMember familyMember = db.FamilyMembers.Find(id);
            if (familyMember == null)
            {
                return HttpNotFound();
            }
            return View(familyMember);
        }

        // POST: FamilyMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FamilyMember familyMember = db.FamilyMembers.Find(id);
            db.FamilyMembers.Remove(familyMember);
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
