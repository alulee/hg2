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
using HGenealogy.Models.FamilyMember;
using HGenealogy.Services.Interface;

namespace HGenealogy.Controllers
{
    public class FamilyMembersController : Controller
    {
        private hDatabaseEntities db = new hDatabaseEntities();
        private readonly IFamilyMemberService _familyMemberService;
        private readonly IAddressService _addressService;

        public FamilyMembersController(
                IFamilyMemberService familyMemberService,
                IAddressService addressService
            )
        {
            this._familyMemberService = familyMemberService;
            this._addressService = addressService;

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

            FamilyMember familyMember = new FamilyMember();
            var familyMemberViewModel = Mapper.Map<FamilyMember, FamilyMemberViewModel>(familyMember);

            ViewBag.Title = "建立新的家族成員";
            return View("CreateOrUpdate", familyMemberViewModel);
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

            var familyMemberViewModel = Mapper.Map<FamilyMember, FamilyMemberViewModel>(familyMember);

            familyMemberViewModel.AvailableCountries.Add(new SelectListItem { Text = "請挑選國別", Value = "0" });
            var allCountries = this._addressService.GetAllCountries();
            if (allCountries != null)
            {
                foreach (var country in allCountries)
                {
                    familyMemberViewModel.AvailableCountries.Add(new SelectListItem { Text = country.Name, Value = country.Id.ToString() });
                }
            }



            ViewBag.Title = "修改家族成員資料";
            return View("CreateOrUpdate", familyMemberViewModel);       
        }

        // POST: FamilyMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveFamilyMember(FamilyMemberViewModel editfamilyMember)
        {
            if (ModelState.IsValid)
            {
                var familyMember = Mapper.Map<FamilyMember>(editfamilyMember);

                try
                {
                    if (familyMember.Id == 0)//新增
                        _familyMemberService.Insert(familyMember);
                    else
                        _familyMemberService.Update(familyMember);


                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    Console.Write(e.ToString());
                }
 
            }
            return RedirectToAction("Index");
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


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetStateProvincesByCountryName(string countryName)
        {
            //this action method gets called via an ajax request
            if (String.IsNullOrEmpty(countryName))
                throw new ArgumentNullException("countryName");

            var result = _addressService.GetAllStateProvincesByCountryName(countryName).ToList();
            if (result != null)
            {
                var toReturn = (from s in result
                                select new { stateProvinceName = s }).ToList();
                return Json(toReturn, JsonRequestBehavior.AllowGet);
            }

            return null;

        }
    
    }
}
