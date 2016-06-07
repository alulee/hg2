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
        private readonly IFamilyMemberService _familyMemberService;
        private readonly IAddressService _addressService;

        #region 建構 / 解構

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

        protected override void Dispose(bool disposing)
        {         
            base.Dispose(disposing);
        }

        #endregion

        
        #region Utilities

        [NonAction]
        protected virtual void PrepareFamilyMemberViewModel(FamilyMemberViewModel model)
        {

            // 設定國家選單
            model.AvailableCountries.Add(new SelectListItem { Text = "國別", Value = "" , Selected = true});
            var allCountries = this._addressService.GetAllCountries();
            if (allCountries != null)
            {
                foreach (var country in allCountries)
                {
                    model.AvailableCountries.Add(new SelectListItem 
                    { 
                        Text = country.Name,
                        Value = country.Name,
                        Selected = country.Name == model.currentAddress.address.Country
                    });
                }
            }

            //設定省洲清單
            model.AvailableStateProvinces.Add(new SelectListItem { Text = "城市", Value = "0", Selected = true });
            if(model.currentAddress != null && model.currentAddress.address.Country != "")
            {
                var countryName = model.currentAddress.address.Country;
                var stateProvinceName = model.currentAddress.address.StateProvince;
                var allStateProvinces = this._addressService.GetAllStateProvincesByCountryName(countryName);
                
                if (allStateProvinces != null)
                {                    
                    foreach (var loopStateProvince in allStateProvinces)
                    {
                        model.AvailableStateProvinces.Add(new SelectListItem
                        {
                            Text = loopStateProvince,
                            Value = loopStateProvince,
                            Selected = loopStateProvince == stateProvinceName
                        });
                    }
                }

                if (stateProvinceName != "" && !allStateProvinces.Contains(stateProvinceName))
                {
                    model.AvailableStateProvinces.Add(new SelectListItem
                    {
                        Text = stateProvinceName,
                        Value = stateProvinceName,
                        Selected = true
                    });
                }
            }

            // 設定城市清單
            model.AvailableCities.Add(new SelectListItem { Text = "區域", Value = "0", Selected = true });
            if (model.currentAddress != null && model.currentAddress.address.StateProvince != "")
            {
                var stateProvinceName = model.currentAddress.address.StateProvince;
                var allcities = this._addressService.GetAllCityByStateProvinceName(stateProvinceName);
                var cityName = model.currentAddress.address.City;
                
                bool currnetCityNameExistsInList = false;

                if (allcities != null)
                {
                    foreach (var city in allcities)
                    {
                        model.AvailableCities.Add(new SelectListItem
                        {
                            Text = city.CityName,
                            Value = city.CityName,
                            Selected = city.CityName.Trim()  == cityName.Trim() 
                        });

                        if(cityName.Trim() == city.CityName.Trim())
                        {
                            currnetCityNameExistsInList = true;
                        }
                    }
                }
                if (!currnetCityNameExistsInList)
                {
                    model.AvailableCities.Add(new SelectListItem
                    {
                        Text = cityName,
                        Value = cityName,
                        Selected = true
                    });
                }
            }
        }
        
        #endregion
 

        #region Actions

        // GET: FamilyMembers
        public ActionResult Index()
        {            
            if (Session["CurrentPedigreeId"] != null)
            {
            }
            return View(this._familyMemberService.GetAll().ToList());
        }

        public ActionResult IndexByPedigree()
        {
            if (Session["CurrentPedigreeId"] != null)
            {
            }
            return View(this._familyMemberService.GetAll().ToList());
        }

        public ActionResult List()
        {
            return null;
        }

        // GET: FamilyMembers/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyMember familyMember = this._familyMemberService.GetById(id);
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
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            FamilyMember familyMember = this._familyMemberService.GetById(id); ;
            if (familyMember == null)
            {
                return HttpNotFound();
            }

            var familyMemberViewModel = Mapper.Map<FamilyMember, FamilyMemberViewModel>(familyMember);

            PrepareFamilyMemberViewModel(familyMemberViewModel);

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
                    if (familyMember.Id == 0)
                    {
                        // 新增
                        _familyMemberService.Insert(familyMember);

                        // 新增地址
                    }
                    else
                    {
                        // 修改
                        _familyMemberService.Update(familyMember);

                        // 修改地址
                    }
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
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyMember familyMember = this._familyMemberService.GetById(id);
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
            FamilyMember familyMember = this._familyMemberService.GetById(id);
            //db.FamilyMembers.Remove(familyMember);
            //db.SaveChanges();
            return RedirectToAction("Index");
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

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetCitiesByStateProvinceName(string stateProvinceName)
        {
            //this action method gets called via an ajax request
            if (String.IsNullOrEmpty(stateProvinceName))
                throw new ArgumentNullException("stateProvinceName");

            var result = _addressService.GetAllCityByStateProvinceName(stateProvinceName).ToList();
            if (result != null)
            {               
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return null;

        }
 
        #endregion

    }
}
