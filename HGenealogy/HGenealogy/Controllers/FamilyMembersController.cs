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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Web.Configuration;
using HGenealogy.Infrastructure.Helpers;
using LinqToExcel;
using System.Text;
using LinqKit;
using System.Web.Script.Serialization;
 

namespace HGenealogy.Controllers
{
    public class FamilyMembersController : Controller
    {
        #region 變數宣告

        private readonly IFamilyMemberService _familyMemberService;
        private readonly IFamilyMemberInfoService _familyMemberInfoService;
        private readonly IAddressService _addressService;
        private readonly IPedigreeMetaService _pedigreeMetaService;
        private static Queue<string> myMessageQuere = new Queue<string>();
        private static int myCurrentRow = 0;
        private string fileSavedPath = WebConfigurationManager.AppSettings["UploadPath"];

        #endregion

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
                int currentPedigreeMetaId = Session["currentPedigreeId"] == null ? 0 : Convert.ToInt16(Session["currentPedigreeId"]);
                if (currentPedigreeMetaId != 0)
                {
                    var pedigreeMeta = _pedigreeMetaService.GetById(currentPedigreeMetaId);
                    if (pedigreeMeta != null)
                    {
                        model.CurrentPedigreeMeta = Mapper.Map<PedigreeMetaModel>(pedigreeMeta);
                        model.FamilyName = model.CurrentPedigreeMeta.FamilyName;
                    }
                }
            }
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
 
        #region Actions

        #region FamilyMember 

        // GET: FamilyMembersViewModel
        public ActionResult Index(int page = 1)
        {
            int currentPedigreeId = 0;
 
            if (Session["currentPedigreeId"] == null ||
                !int.TryParse(Session["currentPedigreeId"].ToString(), out currentPedigreeId))
            {
                return RedirectToAction("Index", "PedigreeMeta");
               
            }

            var pedigreeMeta = _pedigreeMetaService.GetById(currentPedigreeId);
            if (pedigreeMeta == null)
                return RedirectToAction("Index", "PedigreeMeta");
 
            var familyMemberList = this._familyMemberService
                                    .GetAll()
                                    .ToList<FamilyMember>();

            int currentPage = page < 1 ? 1 : page;
           
            List<FamilyMemberViewModel> familyMemberViewModelList = Mapper.Map<List<FamilyMember>, List<FamilyMemberViewModel>>(familyMemberList);
            ViewBag.currentPedigreeId = currentPedigreeId;
            ViewBag.currentPedigreeName = pedigreeMeta.Title;

            foreach (var item in familyMemberViewModelList)
            {
                try
                {
                    if (item.CurrentAddressId != 0)
                        item.CurrentAddress = Mapper.Map<AddressViewModel>(_addressService.GetById(item.CurrentAddressId));

                    if (item.CurrentAddress != null)
                    {
                        item.CurrentAddress.FullAdress = item.CurrentAddress.Country + " " +
                                                          item.CurrentAddress.StateProvince + " " +
                                                          item.CurrentAddress.City + " " +
                                                          item.CurrentAddress.Address1;
                    }
                }
                catch { }
            }

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
                return RedirectToAction("Index", "PedigreeMeta");
            }
            
            var pedigreeMeta = _pedigreeMetaService.GetById(currentPedigreeID);
            if (pedigreeMeta == null)
                return RedirectToAction("Index", "PedigreeMeta");

            if (string.IsNullOrWhiteSpace(infoType))
                infoType = "meta";

            if (familyMemberId == 0)
                return RedirectToAction("Index", "FamilyMembers");
            
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

        public ActionResult Meta(int id = 0)
        {
            int currentPedigreeId = 0;
            int currentFamilyMemberId = id;

            if (Session["currentPedigreeId"] == null ||
                !int.TryParse(Session["currentPedigreeId"].ToString(), out currentPedigreeId))
            {
                return RedirectToAction("Index", "PedigreeMeta");
            }

            var pedigreeMeta = _pedigreeMetaService.GetById(currentPedigreeId);
            if (pedigreeMeta == null)
                return RedirectToAction("Index", "PedigreeMeta");


            if (currentFamilyMemberId == 0)
            {
                if (Session["currentFamilyMemberId"] == null ||
                    !int.TryParse(Session["currentFamilyMemberId"].ToString(), out currentFamilyMemberId))

                  return RedirectToAction("Index", "FamilyMembers");
            }


            FamilyMember familyMember = this._familyMemberService.GetById(currentFamilyMemberId); ;
            if (familyMember == null)
            {
                return HttpNotFound();
            }

            var familyMemberViewModel = Mapper.Map<FamilyMember, FamilyMemberViewModel>(familyMember);
            familyMemberViewModel.IsLoadCurrentPedigreeMeta = true;
            PrepareFamilyMemberViewModel(familyMemberViewModel);

            // ViewBag.Title = string.Concat(pedigreeMeta.Title, "族譜資料");
            ViewBag.currentPedigreeId = currentPedigreeId;
            ViewBag.currentPedigreeTitle = pedigreeMeta.Title;
            ViewBag.currentFamilyMemberId = currentFamilyMemberId;
            Session["currentFamilyMemberId"] = currentFamilyMemberId;

            return View(familyMemberViewModel);
        }

        // GET: FamilyMembers/Create
        public ActionResult Create()
        {
            int currentPedigreeId = 0;

            if (Session["currentPedigreeId"] == null ||
                !int.TryParse(Session["currentPedigreeId"].ToString(), out currentPedigreeId))
            {
                return RedirectToAction("Index", "PedigreeMeta");
            }

            var pedigreeMeta = _pedigreeMetaService.GetById(currentPedigreeId);
            if (pedigreeMeta == null)
                return RedirectToAction("Index", "PedigreeMeta");
 
            FamilyMember familyMember = new FamilyMember();
            var familyMemberViewModel = Mapper.Map<FamilyMember, FamilyMemberViewModel>(familyMember);

            familyMemberViewModel.IsLoadAddressSelectList = true;
            familyMemberViewModel.IsLoadCurrentPedigreeMeta = true;

            PrepareFamilyMemberViewModel(familyMemberViewModel);

            ViewBag.Title = "建立新的家族成員";
            return View("CreateOrUpdate", familyMemberViewModel);
        }
 
        // GET: FamilyMembers/Edit/5
        public ActionResult Edit(int id)
        {
            int currentPedigreeId = 0;

            if (Session["currentPedigreeId"] == null ||
                !int.TryParse(Session["currentPedigreeId"].ToString(), out currentPedigreeId))
            {
                return RedirectToAction("Index", "PedigreeMeta");
            }

            var pedigreeMeta = _pedigreeMetaService.GetById(currentPedigreeId);
            if (pedigreeMeta == null)
                return RedirectToAction("Index", "PedigreeMeta");

            if (id == 0)
                return RedirectToAction("Index", "FamilyMembers");

            FamilyMember familyMember = this._familyMemberService.GetById(id); ;
            if (familyMember == null)
            {
                return HttpNotFound();
            }

            var familyMemberViewModel = Mapper.Map<FamilyMember, FamilyMemberViewModel>(familyMember);
            familyMemberViewModel.IsLoadAddressSelectList = true;
            familyMemberViewModel.IsLoadCurrentPedigreeMeta = true;

            PrepareFamilyMemberViewModel(familyMemberViewModel);

            ViewBag.Title = "修改家族成員資料";
            return View("CreateOrUpdate", familyMemberViewModel);       
        }

        // POST: FamilyMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveFamilyMember(FamilyMemberViewModel editfamilyMember, bool isAutoGenerateParents=false)
        {
            ViewBag.Validation = ModelState.IsValid;

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
                        familyMember.UpdatedWho = "sa";
                        _familyMemberService.Insert(familyMember);

                        // 新增地址
                        // currentAddress = _addressService.GetNewAddress();
                    }
                    else
                    {
                        // 修改
                        familyMember.CreatedWho = "sa";
                        familyMember.UpdatedWho = "sa";
                    }

                    #region 地址處理

                    string country = editfamilyMember.CountryName == null ? "" : editfamilyMember.CountryName;                    
                    string stateProvince = editfamilyMember.StateProvinceName == null ? "" : editfamilyMember.StateProvinceName;
                    string city = editfamilyMember.CityName == null ? "" : editfamilyMember.CityName;
                    string address1 = editfamilyMember.Address1 == null ? "" : editfamilyMember.Address1;


                    // 設定經緯度
                    try
                    {
                        string fulladdress = string.Format("{0} {1} {2} {3}", country, stateProvince, city, address1);
                        
                        if (fulladdress.Trim() != "")
                        {
                            currentAddress = _addressService.GetById(familyMember.CurrentAddressId);
                            if (currentAddress == null)
                            {
                                // 新增地址
                                currentAddress = _addressService.GetNewAddress();                                
                            }
                            currentAddress.Country = country;
                            currentAddress.StateProvince = stateProvince;
                            currentAddress.City = city;
                            currentAddress.Address1 = address1;
 
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
                        }
                    }
                    catch { }

                   
                    #endregion

                    #region 父母自動建立

                    if (isAutoGenerateParents)
                    {
                        if (familyMember.FatherMemberId == 0 && editfamilyMember.FatherName != "")
                        {
                            FamilyMemberViewModel father = new FamilyMemberViewModel();

                            FamilyMember newfather = Mapper.Map<FamilyMember>(father);

                            newfather.PedigreeId = editfamilyMember.PedigreeId;
                            newfather.FamilyName = editfamilyMember.FamilyName;
                            newfather.GivenName = editfamilyMember.FatherName;
                            newfather.GenerationSeq = editfamilyMember.GenerationSeq - 1;

                            _familyMemberService.Insert(newfather);
                            familyMember.FatherMemberId = newfather.Id;
                        }
                    }

                    #endregion

                    _familyMemberService.Update(familyMember);

                    editfamilyMember.Id = familyMember.Id;

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    Console.Write(e.ToString());
                }
             }

            return View("CreateOrUpdate", editfamilyMember);
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
 
        #endregion

        #region FamilyMemberInfo

        public ActionResult Info(string infoType = "", int familyMemberid = 0)
        {
            int currentPedigreeId = 0;
            int currentFamilyMemberId = familyMemberid;

            if (Session["currentPedigreeId"] == null ||
                !int.TryParse(Session["currentPedigreeId"].ToString(), out currentPedigreeId))
            {
                return RedirectToAction("Index", "PedigreeMeta");
            }

            if (currentFamilyMemberId == 0)
            {
                if (Session["currentFamilyMemberId"] == null ||
                    !int.TryParse(Session["currentFamilyMemberId"].ToString(), out currentFamilyMemberId))

                    return RedirectToAction("Index", "FamilyMembers");
            }
 
            if(infoType == "")
            {
                return this.Meta(currentFamilyMemberId);
            }

            var pedigreeMeta = _pedigreeMetaService.GetById(currentPedigreeId);
            if (pedigreeMeta == null)
                return RedirectToAction("Index", "PedigreeMeta");

            FamilyMember familyMember = this._familyMemberService.GetById(currentFamilyMemberId); ;
            if (familyMember == null)
            {
                return HttpNotFound();
            }

            var familyMemberInfoList = this._familyMemberInfoService.GetInfosByFamilyMemberId(currentFamilyMemberId);
            if (familyMemberInfoList == null)
            {
                return HttpNotFound();
            }

            var familyMemberInfoModelList = Mapper.Map<List<FamilyMemberInfoModel>>(familyMemberInfoList);

            ViewBag.currentPedigreeId = currentPedigreeId;
            ViewBag.currentPedigreeName = "";
            ViewBag.currentFamilyMemberId = currentFamilyMemberId;            
            ViewBag.currentFamilyMemberName = familyMember.FamilyName + " " + familyMember.GivenName;
            ViewBag.currentInfoType = FamilyMemberNavigationEnum.Biography.ToString();
            Session["currentFamilyMemberId"] = currentFamilyMemberId;

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

        #region FamilyMemberUpload

        public ActionResult Upload()
        {
            int currentPedigreeId = 0;

            if (Session["currentPedigreeId"] == null ||
                !int.TryParse(Session["currentPedigreeId"].ToString(), out currentPedigreeId))
            {
                return RedirectToAction("Index", "PedigreeMeta");
            }

            var pedigreeMeta = _pedigreeMetaService.GetById(currentPedigreeId);
            if (pedigreeMeta == null)
                return RedirectToAction("Index", "PedigreeMeta");

            ViewBag.currentPedigreeId = currentPedigreeId;
            ViewBag.currentPedigreeName = pedigreeMeta.Title;

            return View();
        }

        [HttpPost]
        public ActionResult UploadConfirm(HttpPostedFileBase file)
        {           
            JObject jo = new JObject();
            string result = string.Empty;

            if (file == null)
            {
                jo.Add("Result", false);
                jo.Add("Msg", "請上傳檔案!");
                result = JsonConvert.SerializeObject(jo);
                return Content(result, "application/json");
            }
            if (file.ContentLength <= 0)
            {
                jo.Add("Result", false);
                jo.Add("Msg", "請上傳正確的檔案.");
                result = JsonConvert.SerializeObject(jo);
                return Content(result, "application/json");
            }

            string fileExtName = Path.GetExtension(file.FileName).ToLower();

            if (!fileExtName.Equals(".xls", StringComparison.OrdinalIgnoreCase)
                &&
                !fileExtName.Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                jo.Add("Result", false);
                jo.Add("Msg", "請上傳 .xls 或 .xlsx 格式的檔案");
                result = JsonConvert.SerializeObject(jo);
                return Content(result, "application/json");
            }

            try
            {
                var uploadResult = this.FileUploadHandler(file);

                return this.Import(file.FileName);
 
                //jo.Add("Result", !string.IsNullOrWhiteSpace(uploadResult));
                //jo.Add("Msg", !string.IsNullOrWhiteSpace(uploadResult) ? uploadResult : "");
                //result = JsonConvert.SerializeObject(jo);
            }
            catch (Exception ex)
            {
                jo.Add("Result", false);
                jo.Add("Msg", ex.Message);
                result = JsonConvert.SerializeObject(jo);
            }
            return Content(result, "application/json");
        }
 

        /// <summary>
        /// Files the upload handler.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">file;上傳失敗：沒有檔案！</exception>
        /// <exception cref="System.InvalidOperationException">上傳失敗：檔案沒有內容！</exception>
        private string FileUploadHandler(HttpPostedFileBase file)
        {
            string result;

            if (file == null)
            {
                throw new ArgumentNullException("file", "上傳失敗：沒有檔案！");
            }
            if (file.ContentLength <= 0)
            {
                throw new InvalidOperationException("上傳失敗：檔案沒有內容！");
            }

            try
            {
                string virtualBaseFilePath = Url.Content(fileSavedPath);
                string filePath = HttpContext.Server.MapPath(virtualBaseFilePath);

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                if (System.IO.File.Exists(Path.Combine(filePath, file.FileName))) // 驗證檔案是否存在
                {
                    System.IO.File.Delete(Path.Combine(filePath, file.FileName));
                }

                //string newFileName = string.Concat(
                //    DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                //    Path.GetExtension(file.FileName).ToLower());

                string fullFilePath = Path.Combine(Server.MapPath(fileSavedPath), file.FileName);
                file.SaveAs(fullFilePath);

                result = file.FileName;
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        [HttpPost]
        public ActionResult Import(string savedFileName)
        {            
            var jo = new JObject();
            string result = "";

            try
            {
                var fileName = string.Concat(Server.MapPath(fileSavedPath), "/", savedFileName);

                var importFamilies = new List<FamilyMemberViewModel>();
                var saveResult = this.CheckAndSaveFamilyMemberData(fileName, importFamilies);
                jo.Add("Result", saveResult.Success);
                jo.Add("Msg",  saveResult.ErrorMessage);
            }
            catch (Exception ex)
            {
                jo.Add("Result", false);
                jo.Add("Msg", ex.Message);
            }
            result = JsonConvert.SerializeObject(jo);
            return Content(result, "application/json");
        }


        [HttpPost]
        public ActionResult HasData()
        {
            JObject jo = new JObject();
            bool result = true;
            jo.Add("Msg", result.ToString());
            return Content(JsonConvert.SerializeObject(jo), "application/json");
        }


        [HttpPost]
        public string UploadStart()
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                string extension =
                    System.IO.Path.GetExtension(file.FileName);

                if (extension == ".xls" || extension == ".xlsx")
                {
                    string fileLocation = Server.MapPath("~/Content/") + file.FileName;
                    if (System.IO.File.Exists(fileLocation)) // 驗證檔案是否存在
                    {
                        System.IO.File.Delete(fileLocation);
                    }
                    file.SaveAs(fileLocation); // 存放檔案到伺服器上
                }

                return file.FileName;
            }
            return "";
            //return this.RedirectToAction("Upload");

        }

        [HttpPost]
        public string Progress(string taskid)
        {
            string returnString = "";

            myCurrentRow++;
            if (myCurrentRow > 100)
            {
                myMessageQuere.Enqueue("done");
            }
            else
            {
                myMessageQuere.Enqueue(string.Format("目前正在處理第 {0} 筆資料...", myCurrentRow));
            }

            lock (myMessageQuere)
            {
                if (myMessageQuere.Count > 0)
                {
                    returnString = myMessageQuere.Dequeue();
                }
            }

            return returnString;
        }

        /// <summary>
        /// 檢查匯入的族譜 Excel 資料.
        /// </summary>    
        [NonAction]
        public CheckResult CheckAndSaveFamilyMemberData(
            string fileName,
            List<FamilyMemberViewModel> importFamilies)
        {
            var result = new CheckResult();
            var targetFile = new FileInfo(fileName);

            int currentPedigreeId = 0;

            if (Session["currentPedigreeId"] == null ||
                !int.TryParse(Session["currentPedigreeId"].ToString(), out currentPedigreeId))
            {
                result.Success = false;
                result.ErrorMessage = "族譜資料錯誤";
                return result;
            }

            var pedigreeMeta = _pedigreeMetaService.GetById(currentPedigreeId);
            if (pedigreeMeta == null)
            {
                result.Success = false;
                result.ErrorMessage = "族譜資料錯誤";
                return result;
            }

            #region 由 Excel 讀入要匯入的資料

            if (!targetFile.Exists)
            {
                result.ID = Guid.NewGuid();
                result.Success = false;
                result.ErrorCount = 0;
                result.ErrorMessage = "匯入的資料檔案不存在";
                return result;
            }

            var excelFile = new ExcelQueryFactory(fileName);

            //欄位對映
            //編號	曾祖	祖	父	母	本人	住址	E-MAIL	配偶	代別	電話	工作	備註	子女	子女	子女	子女	子女		 
            excelFile.AddMapping<FamilyMemberViewModel>(x => x.ImportSeqNo, "序號");
            excelFile.AddMapping<FamilyMemberViewModel>(x => x.GGrandFatherName, "曾祖");
            excelFile.AddMapping<FamilyMemberViewModel>(x => x.GrandFatherName, "祖");
            excelFile.AddMapping<FamilyMemberViewModel>(x => x.FatherName, "父");
            excelFile.AddMapping<FamilyMemberViewModel>(x => x.GivenName, "本人");
            excelFile.AddMapping<FamilyMemberViewModel>(x => x.Address1, "住址");
            excelFile.AddMapping<FamilyMemberViewModel>(x => x.Email, "E-MAIL");
            excelFile.AddMapping<FamilyMemberViewModel>(x => x.WifeName, "配偶");
            excelFile.AddMapping<FamilyMemberViewModel>(x => x.GenerationSeq, "代別");
            excelFile.AddMapping<FamilyMemberViewModel>(x => x.MobilePhone, "電話");
            excelFile.AddMapping<FamilyMemberViewModel>(x => x.JobDescription, "工作");
            excelFile.AddMapping<FamilyMemberViewModel>(x => x.Description, "備註");
            //excelFile.AddMapping<Family>(x => x.Childrens, "子女");

            //SheetName
            var excelContent = excelFile.Worksheet<FamilyMemberViewModel>("工作表1").ToList();

            #endregion

            #region 逐筆檢查匯入

            int errorCount = 0;
            int successCount = 0;
            int generationSeq = 0;
            int rowIndex = 1;
            bool isRowSuccessImported = false;
            var importMessages = new List<string>();
            var errorMessage = new StringBuilder();

            foreach (var row in excelContent)
            {
                errorMessage.Clear();
                generationSeq = 0;
                isRowSuccessImported = false;

                try
                {
                    // 檢查編號
                    if (row.ImportSeqNo == null || row.ImportSeqNo == "")
                    {
                        errorMessage.AppendFormat("名字= {0} 的編號欄位不正確，請檢查!", row.GivenName);
                        continue;
                    }

                    // 檢查名字
                    if (row.GivenName == null || row.GivenName == "")
                    {
                        errorMessage.AppendFormat("序號 {0} 的名字不正確，請檢查!", row.ImportSeqNo);
                        continue;
                    }

                    // 檢查是否重複
                    var filter = PredicateBuilder.True<FamilyMember>();
                    filter = filter.And(p => p.PedigreeId.Equals(pedigreeMeta.Id) && p.ImportSeqNo.Equals(row.ImportSeqNo));
                    var queryresult = _familyMemberService.GetList(filter);

                    if (queryresult != null && queryresult.Count > 0)
                    {
                        errorMessage.AppendFormat("編號{0}, 名字={1} 的資料已存在，不重新匯入，請檢查!", row.ImportSeqNo, row.GivenName);
                        continue;
                    }

                    if (row.GenerationSeq == null || !Int32.TryParse(row.GenerationSeq.ToString(), out generationSeq))
                    {
                        errorMessage.AppendFormat("編號{0}, 名字={1} 的世代別錯誤，請於匯入後重新修正!", row.ImportSeqNo, row.GivenName);
                        continue;
                    }

                    row.PedigreeId = pedigreeMeta.Id;
                    row.FamilyName = pedigreeMeta.FamilyName;
                    row.Description = row.Description == null ? " " : row.Description;
                    row.MobilePhone = row.MobilePhone == null ? " " : row.MobilePhone;
                    row.JobDescription = row.JobDescription == null ? " " : row.JobDescription;
                    row.Phone = row.Phone == null ? " " : row.Phone;
                    row.Email = row.Email == null ? " " : row.Email;
                    row.MobilePhone = row.MobilePhone == null ? " " : row.MobilePhone;

                    this.SaveFamilyMember(row, false);

                    isRowSuccessImported = true;
                    errorMessage.AppendFormat("編號{0}, 名字={1} 匯入成功!", row.ImportSeqNo, row.GivenName);
                    //errorMessage.AppendFormat("編號{0}, 名字= {0} 匯入失敗，請檢查資料是否正確!", row.ImportSeqNo, row.GivenName);
                }
                catch (Exception ex)
                {
                    errorMessage.AppendFormat("編號{0}, 名字={1} 匯入失敗，請檢查資料是否正確!", row.ImportSeqNo, row.GivenName);
                }
                finally
                {
                    if (isRowSuccessImported == false)
                    {
                        errorCount++;

                        importMessages.Add(string.Format(
                            "<p class='error'> 第 {0} 列 ：{1}</p>",
                            rowIndex,
                            errorMessage));
                    }
                    else
                    {
                        successCount++;

                        importMessages.Add(string.Format(
                        "<p class='success'> 第 {0} 列：{1}</p>",
                        rowIndex,
                        errorMessage));
                    }
                    rowIndex++;
                }
            }

            #endregion

            #region 建立滙入成功的成員 父母連結
            
            foreach (var row in excelContent)
            {
                if (row.Id == 0)
                    continue;
 
                FamilyMemberViewModel editFamilyMember = null; 
                var currentfamilymember = _familyMemberService.GetById(row.Id);
                if (currentfamilymember == null)
                    continue;

                // 尋找 father
                var father = excelContent.Where(x => x.GivenName == row.FatherName && x.GenerationSeq == (row.GenerationSeq - 1)).FirstOrDefault();
                if (father != null)
                {
                    var filter = PredicateBuilder.True<FamilyMember>();
                    filter = filter.And(p => p.PedigreeId.Equals(father.PedigreeId));
                    filter = filter.And(p => p.ImportSeqNo.Equals(father.ImportSeqNo));
                    filter = filter.And(p => p.GivenName.Equals(father.GivenName));

                    var queryresult = _familyMemberService.GetList(filter).FirstOrDefault();
                    if (queryresult != null)
                    {
                        currentfamilymember.FatherMemberId = queryresult.Id;
                        _familyMemberService.Update(currentfamilymember);
                    }
                }

            }

            #endregion

            #region 匯入結果

            try
            {
                result.ID = Guid.NewGuid();
                result.Success = errorCount.Equals(0);
                result.SuccessCount = successCount;
                result.RowCount = importFamilies.Count;
                result.ErrorCount = errorCount;

                string allErrorMessage = string.Empty;

                foreach (var message in importMessages)
                {
                    allErrorMessage += message;
                }

                result.ErrorMessage = allErrorMessage;

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }

            #endregion
        }


        #endregion
        
        #region 家庭樹 - d3

        public ActionResult FamilyTreeA()
        {
            List<SelectListItem> pedigreeMetaSelectList = new List<SelectListItem>();
            List<SelectListItem> familyMemberSelectList = new List<SelectListItem>();
            
            int currentPedigreeId = 0;
            if (Session["currentPedigreeId"] != null)
                int.TryParse(Session["currentPedigreeId"].ToString(), out currentPedigreeId);
                        
            ViewBag.currentPedigreeId = currentPedigreeId;
            ViewBag.AvailablePedigreeSelectList = _pedigreeMetaService.GetAvailablePedigreeSelectList(currentPedigreeId);
            ViewBag.FamilyMemberSelectList = _familyMemberService.GetFamilyMembersSelectList(currentPedigreeId);

            ViewBag.Title = "家庭樹";


            return View();
        }

        [HttpPost]
        public JsonResult GetFamiliesJson(string pedigreeId, bool isLoadLinks = true)
        {
            var filter = PredicateBuilder.True<FamilyMember>();
            filter = filter.And(p => p.PedigreeId.ToString().Equals(pedigreeId));
            var queryresult = _familyMemberService.GetList(filter);
             
            if (queryresult != null)
            {
                Mapper.CreateMap<FamilyMember, node>()
                        .ForMember(x => x.name, y => y.MapFrom(a => a.GenerationSeq.ToString() + "世_" + a.FamilyName + a.GivenName))
                        .ForMember(x => x.gid, y => y.MapFrom(a => a.Id))
                        .ForMember(x => x.groupid, y => y.MapFrom(a => a.GenerationSeq.ToString()));

                FamilyTreeViewModel myreturn = new FamilyTreeViewModel();
                myreturn.nodes = Mapper.Map<List<FamilyMember>, List<node>>(queryresult);

                myreturn.nodes.Add(
                    new node
                    {
                        name = "先祖",
                        gid = "0",
                        groupid = "0",
                        id = "0",
                        imageurl = "",
                    });

                if (myreturn.nodes != null && isLoadLinks)
                {
                    List<link> mylinks = new List<link>();
 
                    // 取得關係 links
                    foreach (var member in queryresult)
                    {
                        int sourceid = member.Id;

                        #region 增加父親關聯
                        if (member.FatherMemberId > 0)
                        {
                            var father = _familyMemberService.GetById(member.FatherMemberId);
                            if (father != null)
                            {
                                link newlink = new link();
                                newlink.source = father.Id.ToString();
                                newlink.target = member.Id.ToString();
                                newlink.name = "父子(女)";
                                newlink.value = "1";
                                mylinks.Add(newlink);

                                if (myreturn.nodes.Where(x => x.id == father.Id.ToString()) == null)
                                {
                                    myreturn.nodes.Add(new node
                                        {
                                            id = father.Id.ToString(),
                                            gid = father.Id.ToString(),
                                            groupid = father.Id.ToString(),
                                            name = member.FamilyName + member.GivenName + " 父"
                                        });
                                }
                            }
                        }
                        #endregion

                        #region 增加母親關聯
                        if (member.MotherMemberId > 0)
                        {                            
                            var mother = _familyMemberService.GetById(member.MotherMemberId);
                            if (mother != null)
                            {
                                link newlink = new link();
                                newlink.source = mother.Id.ToString();
                                newlink.target = member.Id.ToString();
                                newlink.name = "母子(女)";
                                newlink.value = "1";                                
                                mylinks.Add(newlink);

                                if (myreturn.nodes.Where(x => x.id == mother.Id.ToString()) == null)
                                {
                                    myreturn.nodes.Add(new node
                                    {
                                        id = mother.Id.ToString(),
                                        gid = mother.Id.ToString(),
                                        groupid = mother.Id.ToString(),
                                        name = member.FamilyName + member.GivenName + " 母"
                                    });
                                }
                            }
                        }
                        #endregion

                        #region 增加與 root 的連結

                        if (member.FatherMemberId == 0 && member.MotherMemberId == 0)
                        {
                            link newlink = new link();
                            newlink.source = "0";
                            newlink.target = member.Id.ToString();
                            newlink.name = "子孫";
                            newlink.value = "1";
                            mylinks.Add(newlink);
                        }
                        
                        #endregion
                    }
                    myreturn.links = mylinks;
                }
                
                return this.Json(myreturn);
            }

            return null;
        }

        #endregion

        #region Navigation

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
