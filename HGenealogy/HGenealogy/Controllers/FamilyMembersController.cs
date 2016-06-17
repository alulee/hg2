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
using HGenealogy.Models.PedigreeMeta;

namespace HGenealogy.Controllers
{
    public class FamilyMembersController : Controller
    {
        private readonly IFamilyMemberService _familyMemberService;
        private readonly IFamilyMemberInfoService _familyMemberInfoService;
        private readonly IAddressService _addressService;
        private readonly IPedigreeMetaService _pedigreeMetaService;

        #region 建構 / 解構

        public FamilyMembersController(
                IFamilyMemberService familyMemberService,
                IFamilyMemberInfoService familyMemberInfoService,
                IAddressService addressService,
                IPedigreeMetaService pedigreeMetaService
            )
        {
            this._familyMemberService = familyMemberService;
            this._familyMemberInfoService = familyMemberInfoService;
            this._addressService = addressService;
            this._pedigreeMetaService = pedigreeMetaService;

            Mapper.CreateMap<FamilyMemberViewModel, FamilyMember>();
            Mapper.CreateMap<FamilyMember, FamilyMemberViewModel>();
            Mapper.CreateMap<FamilyMemberInfoModel, FamilyMemberInfo>();
            Mapper.CreateMap<FamilyMemberInfo, FamilyMemberInfoModel>();
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
                model.CurrentAddress = Mapper.Map<AddressViewModel>(address);
                model.CurrentAddress.FullAdress = model.CurrentAddress.Country + " " +
                                                  model.CurrentAddress.StateProvince + " " +
                                                  model.CurrentAddress.City + " " +
                                                  model.CurrentAddress.Address1;

                model.CountryName = model.CurrentAddress.Country;
                model.StateProvinceName = model.CurrentAddress.StateProvince;
                model.CityName = model.CurrentAddress.City;
                model.Address1 = model.CurrentAddress.Address1;
            }

            // 是否載入地址下拉選項
            if (model.IsLoadAddressSelectList)
            {
                #region 設定國家選單
                model.AvailableCountries.Add(new SelectListItem { Text = "國別", Value = "", Selected = false });
                var allCountries = this._addressService.GetAllCountries();
                if (allCountries != null)
                {
                    foreach (var country in allCountries)
                    {
                        model.AvailableCountries.Add(new SelectListItem
                        {
                            Text = country.Name,
                            Value = country.Name,
                            Selected = country.Name == model.CurrentAddress.Country
                        });
                    }
                }
                #endregion

                #region 設定省洲清單
                model.AvailableStateProvinces.Add(new SelectListItem { Text = "城市", Value = "", Selected = false });
                if (model.CurrentAddress != null && model.CurrentAddress.Country != "")
                {
                    var countryName = model.CurrentAddress.Country;
                    var stateProvinceName = model.CurrentAddress.StateProvince;
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
                #endregion

                #region 設定城市清單
                model.AvailableCities.Add(new SelectListItem { Text = "區域", Value = "", Selected = false });
                if (model.CurrentAddress != null && model.CurrentAddress.StateProvince != "")
                {
                    var stateProvinceName = model.CurrentAddress.StateProvince;
                    var allcities = this._addressService.GetAllCityByStateProvinceName(stateProvinceName);
                    var cityName = model.CurrentAddress.City;

                    bool currnetCityNameExistsInList = false;

                    if (allcities != null)
                    {
                        foreach (var city in allcities)
                        {
                            model.AvailableCities.Add(new SelectListItem
                            {
                                Text = city.CityName,
                                Value = city.CityName,
                                Selected = city.CityName.Trim() == cityName.Trim()
                            });

                            if (cityName.Trim() == city.CityName.Trim())
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
                #endregion
            }
            
            // 讀取目前選取的族譜
            if (model.IsLoadCurrentPedigreeMeta)
            {
                int currentPedigreeMetaId = Session["currentPedigreeMetaId"] == null ? 0 : Convert.ToInt16(Session["currentPedigreeMetaId"]);
                if (currentPedigreeMetaId != 0)
                {
                    var pedigreeMeta = _pedigreeMetaService.GetById(currentPedigreeMetaId);
                    if (pedigreeMeta != null)
                    {
                        model.CurrentPedigreeMeta = Mapper.Map<PedigreeMetaModel>(pedigreeMeta);
                    }
                }
            }
        }
 
        #endregion
 
        #region Actions

        #region FamilyMember 

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
        public ActionResult Details(int familyMemberId, string infoType = "")
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

            if (familyMemberId == 0)
                Redirect(Url.Action("Index", "FamilyMembers"));
            
            FamilyMember familyMember = this._familyMemberService.GetById(familyMemberId); ;
            if (familyMember == null)
            {
                return HttpNotFound();
            }
            
            var familyMemberViewModel = Mapper.Map<FamilyMember, FamilyMemberViewModel>(familyMember);            
            PrepareFamilyMemberViewModel(familyMemberViewModel);

            
            ViewBag.Title = string.Concat(pedigreeMeta.Title, "族譜資料");
            ViewBag.currentPedigreeID = currentPedigreeID;
            ViewBag.currentInfoType = infoType;
            ViewBag.currentFamilyMemberId = familyMemberId;

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
                    Address currentAddress = null;
                    if (familyMember.Id == 0)
                    {
                        // 新增
                        familyMember.CreatedWho = "sa";
                        _familyMemberService.Insert(familyMember);

                        // 新增地址
                        currentAddress = _addressService.GetNewAddress();
                    }
                    else
                    {
                        // 修改
                        familyMember.CreatedWho = "sa";
                        familyMember.UpdatedWho = "sa";

                        currentAddress = _addressService.GetById(familyMember.CurrentAddressId);
                        if (currentAddress == null)
                        {
                            // 新增地址
                            currentAddress = _addressService.GetNewAddress();
                        }
                    }

                    #region 地址處理

                    currentAddress.Country = editfamilyMember.CountryName;
                    currentAddress.StateProvince = editfamilyMember.StateProvinceName;
                    currentAddress.City = editfamilyMember.CityName;
                    currentAddress.Address1 = editfamilyMember.Address1;


                    // 設定經緯度
                    string fulladdress = string.Format("{0} {1} {2} {3}", currentAddress.Country, currentAddress.StateProvince, currentAddress.City, currentAddress.Address1);
                    string jsonAddress = GeoUtil.convertAddressToJsonString(fulladdress);
                    double[] latlng = GeoUtil.getLatLng(jsonAddress);
                    decimal latitude, longitude;

                    if (Decimal.TryParse(latlng[0].ToString(), out latitude))
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

                    #endregion

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

        #region FamilyMemberInfo

        public ActionResult Info(int familyMemberid, string infoType)
        {
            int currentPedigreeId = 0;

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
            FamilyMember familyMember = this._familyMemberService.GetById(familyMemberid); ;
            if (familyMember == null)
            {
                return HttpNotFound();
            }

            var familyMemberInfoList = this._familyMemberInfoService.GetInfosByFamilyMemberId(familyMemberid);
            if (familyMemberInfoList == null)
            {
                return HttpNotFound();
            }

            var familyMemberInfoModelList = Mapper.Map<List<FamilyMemberInfoModel>>(familyMemberInfoList);

            ViewBag.currentPedigreeId = currentPedigreeId;
            ViewBag.currentPedigreeName = "";
            ViewBag.currentFamilyMemberId = familyMemberid;            
            ViewBag.currentFamilyMemberName = familyMember.FamilyName + " " + familyMember.GivenName;
            ViewBag.currentInfoType = FamilyMemberNavigationEnum.Biography.ToString();

            if (infoType == FamilyMemberNavigationEnum.Biography.ToString())
            {
                return View("Biography", familyMemberInfoModelList);
            }

            return View(familyMemberInfoModelList);
        }

        public ActionResult CreateInfo(int familyMemberId, string infoType)
        {
            FamilyMember familyMember = this._familyMemberService.GetById(familyMemberId); ;
            if (familyMember == null)
            {
                return HttpNotFound();
            }
            var familyMemberInfo = new FamilyMemberInfo();
            var familyMemberInfoModel = Mapper.Map<FamilyMemberInfoModel>(familyMemberInfo);

            familyMemberInfoModel.FamilyMemberId = familyMemberId;
            familyMemberInfoModel.Id = 0;
            familyMemberInfoModel.InfoType = infoType;
            familyMemberInfoModel.FamilyName = familyMember.FamilyName;
            familyMemberInfoModel.GivenName = familyMember.GivenName;
            familyMemberInfoModel.Address = "";

            ViewBag.Title = "新增家族成員生命史記錄";
            ViewBag.currentFamilyMemberId = familyMemberId;
            ViewBag.currentInfoType = infoType;
             
            return View("CreateOrUpdateInfo", familyMemberInfoModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveFamilyMemberInfo(FamilyMemberInfoModel model)
        {
            if (ModelState.IsValid)
            {

                var familyMemberInfo = Mapper.Map<FamilyMemberInfo>(model);

                if (familyMemberInfo.Id == 0)//新增
                {
                    familyMemberInfo.CreatedOnUtc = System.DateTime.UtcNow;
                    familyMemberInfo.CreatedWho = "";
                }

                familyMemberInfo.UpdatedOnUtc = System.DateTime.UtcNow;
                familyMemberInfo.UpdatedWho = "";
                if(familyMemberInfo.Address == null)
                    familyMemberInfo.Address = "";

                if (familyMemberInfo.Id == 0)//新增
                    _familyMemberInfoService.Insert(familyMemberInfo);
                else
                    _familyMemberInfoService.Update(familyMemberInfo);


                return RedirectToAction("Info", "FamilyMembers", new { familyMemberid = model.FamilyMemberId, infoType = model.InfoType });
            }

            return RedirectToAction("Meta", "FamilyMembers", new { familyMemberid = model.FamilyMemberId });
        }


        #endregion

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

    }
}
