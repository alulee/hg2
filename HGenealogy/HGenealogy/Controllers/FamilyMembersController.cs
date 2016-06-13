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
using HGenealogy.SharedClass;
using HGenealogy.Models.Common;
using PagedList;

namespace HGenealogy.Controllers
{
    public class FamilyMembersController : Controller
    {
        private readonly IFamilyMemberService _familyMemberService;
        private readonly IAddressService _addressService;
        private readonly IPedigreeMetaService _pedigreeMetaService;

        #region 建構 / 解構

        public FamilyMembersController(
                IFamilyMemberService familyMemberService,
                IAddressService addressService,
                IPedigreeMetaService pedigreeMetaService
            )
        {
            this._familyMemberService = familyMemberService;
            this._addressService = addressService;
            this._pedigreeMetaService = pedigreeMetaService;

            Mapper.CreateMap<FamilyMemberViewModel, FamilyMember>();
            Mapper.CreateMap<FamilyMember, FamilyMemberViewModel>();
            Mapper.CreateMap<AddressViewModel, Address>();
            Mapper.CreateMap<Address, AddressViewModel>();
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
            if (model.CurrentAddressId != 0)
            {
                var address = _addressService.GetById(model.CurrentAddressId);
                model.currentAddress = Mapper.Map<AddressViewModel>(address);
                model.currentAddress.FullAdress = model.currentAddress.Country + " " +
                                                  model.currentAddress.StateProvince + " " +
                                                  model.currentAddress.City + " " +
                                                  model.currentAddress.Address1;
            }

            // 設定國家選單
            model.AvailableCountries.Add(new SelectListItem { Text = "國別", Value = "" , Selected = false});
            var allCountries = this._addressService.GetAllCountries();
            if (allCountries != null)
            {
                foreach (var country in allCountries)
                {
                    model.AvailableCountries.Add(new SelectListItem 
                    { 
                        Text = country.Name,
                        Value = country.Name,
                        Selected = country.Name == model.currentAddress.Country
                    });
                }
            }
            

            //設定省洲清單
            model.AvailableStateProvinces.Add(new SelectListItem { Text = "城市", Value = "", Selected = false });
            if(model.currentAddress != null && model.currentAddress.Country != "")
            {
                var countryName = model.currentAddress.Country;
                var stateProvinceName = model.currentAddress.StateProvince;
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
            model.AvailableCities.Add(new SelectListItem { Text = "區域", Value = "", Selected = false });
            if (model.currentAddress != null && model.currentAddress.StateProvince != "")
            {
                var stateProvinceName = model.currentAddress.StateProvince;
                var allcities = this._addressService.GetAllCityByStateProvinceName(stateProvinceName);
                var cityName = model.currentAddress.City;
                
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

            model.CountryName = model.currentAddress.Country;
            model.StateProvinceName = model.currentAddress.StateProvince;
            model.CityName = model.currentAddress.City;
            model.Address1 = model.currentAddress.Address1;

        }
        
        [NonAction]
        private IDictionary<string, string> getInfoTypeDic()
        {
            IDictionary<string, string> infoTypeDic = new Dictionary<string, string>();
            infoTypeDic.Add("Meta", "通訊資料");
            infoTypeDic.Add("Personage", "個人生命史");
            return infoTypeDic;
        }

        #endregion
 
        #region Actions

        // GET: FamilyMembersViewModel
        public ActionResult Index(int page = 1)
        {            
            if (Session["CurrentPedigreeId"] != null)
            {
            }
            var familyMemberList = this._familyMemberService
                                    .GetAll()
                                    .ToList<FamilyMember>();

            // session 讀取 gID
            int currentPage = page < 1 ? 1 : page;
           
            List<FamilyMemberViewModel> familyMemberViewModelList = Mapper.Map<List<FamilyMember>, List<FamilyMemberViewModel>>(familyMemberList);

            return View(familyMemberViewModelList.ToPagedList(currentPage, 15));
 
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
        public ActionResult Details(int familyMemberID, string infoType = "")
        {
            int currentPedigreeID = 0;

            if (Session["currentPedigreeId"] == null ||
                !int.TryParse(Session["currentPedigreeId"].ToString(), out currentPedigreeID))
            {
                Redirect(Url.Action("PedigreeMeta", "Index"));
            }
            
            var pedigreeMeta = _pedigreeMetaService.GetById(currentPedigreeID);
            if (pedigreeMeta == null)
                Redirect(Url.Action("PedigreeMeta", "Index"));

            if (string.IsNullOrWhiteSpace(infoType))
                infoType = "meta";

            if (familyMemberID == 0)
                Redirect(Url.Action("Index", "FamilyMembers"));
            
            FamilyMember familyMember = this._familyMemberService.GetById(familyMemberID); ;
            if (familyMember == null)
            {
                return HttpNotFound();
            }
            
            var familyMemberViewModel = Mapper.Map<FamilyMember, FamilyMemberViewModel>(familyMember);            
            PrepareFamilyMemberViewModel(familyMemberViewModel);

            
            ViewBag.Title = string.Concat(pedigreeMeta.Title, "族譜資料");
            ViewBag.currentPedigreeID = currentPedigreeID;
            ViewBag.currentInfoType = infoType;
            ViewBag.infoTypeDic = getInfoTypeDic();

            return View(familyMemberViewModel);
        }

        public ActionResult Meta(int id)
        {
            int currentPedigreeID = 0;

            /*
            if (Session["currentPedigreeId"] == null ||
                !int.TryParse(Session["currentPedigreeId"].ToString(), out currentPedigreeID))
            {
                Redirect(Url.Action("PedigreeMeta", "Index"));
            }

            var pedigreeMeta = _pedigreeMetaService.GetById(currentPedigreeID);
            if (pedigreeMeta == null)
                Redirect(Url.Action("PedigreeMeta", "Index"));
 
            if (familyMemberID == 0)
                Redirect(Url.Action("Index", "FamilyMembers"));
            */

            FamilyMember familyMember = this._familyMemberService.GetById(id); ;
            if (familyMember == null)
            {
                return HttpNotFound();
            }

            var familyMemberViewModel = Mapper.Map<FamilyMember, FamilyMemberViewModel>(familyMember);
            PrepareFamilyMemberViewModel(familyMemberViewModel);

            // ViewBag.Title = string.Concat(pedigreeMeta.Title, "族譜資料");
            ViewBag.currentPedigreeID = currentPedigreeID;
            ViewBag.infoTypeDic = getInfoTypeDic();

            return View(familyMemberViewModel);
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
                        familyMember.CreatedWho = "sa";
                        _familyMemberService.Insert(familyMember);

                        // 新增地址
                    }
                    else
                    {

                        // 修改
                        familyMember.CreatedWho = "sa";
                        familyMember.UpdatedWho = "sa";
                       
                        
                        var currentAddress = _addressService.GetById(familyMember.CurrentAddressId);
                        if (currentAddress == null)
                        {
                            // 新增地址
                            currentAddress = _addressService.GetNewAddress();
                        }
                                             
                        currentAddress.Country = editfamilyMember.CountryName;
                        currentAddress.StateProvince = editfamilyMember.StateProvinceName;
                        currentAddress.City = editfamilyMember.CityName;
                        currentAddress.Address1 = editfamilyMember.Address1;
                        

                        // 設定經緯度
                        string fulladdress = string.Format("{0} {1} {2} {3}", currentAddress.Country, currentAddress.StateProvince, currentAddress.City, currentAddress.Address1);
                        string jsonAddress = GeoUtil.convertAddressToJsonString(fulladdress);
                        double[] latlng = GeoUtil.getLatLng(jsonAddress);
                        decimal latitude, longitude;

                        if(Decimal.TryParse(latlng[0].ToString(), out latitude))
                            currentAddress.Latitude = latitude;

                        if (Decimal.TryParse(latlng[1].ToString(), out longitude))
                            currentAddress.Longitude = longitude;

                        if (currentAddress.Id == 0)
                        {                            
                            _addressService.Insert(currentAddress);
                            familyMember.CurrentAddressId = currentAddress.Id;
                        }
                        else
                            _addressService.Update(currentAddress);

                        
                        _familyMemberService.Update(familyMember);

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


        #region FamilyMember / Info

        [ChildActionOnly]
        public ActionResult FamilyMemberNavigation(int familyMemberId, int selectedTabId = 0)
        {
            var model = new FamilyMemberNavigationModel();
            model.CurrentFamilyMemberId = familyMemberId;
            model.HideMeta = false;
            model.HideBiography = false;            
            model.SelectedTab = (FamilyMemberNavigationEnum)selectedTabId;

            return PartialView(model);
        }

        #endregion

        #endregion

    }
}
