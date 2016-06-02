using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using System.IO;
using HGenealogy.Data;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using PagedList;
using HGenealogy.Infrastructure.Helpers;
using HGenealogy.Areas.Genealogy.Models;

namespace HGenealogy.Areas.Genealogy.Controllers
{
    public class GeneExcelController : Controller
    {
        private hDatabaseEntities db = new hDatabaseEntities();
        private static Queue<string> myMessageQuere = new Queue<string>();
        private static int myCurrentRow = 0;
        private string fileSavedPath = WebConfigurationManager.AppSettings["UploadPath"];

        // GET: Genealogy/GeneExcelUpload
        public ActionResult Upload(int page = 1)
        {
            // session 讀取 gID
            int currentPage = page < 1 ? 1 : page;

            var query = db.Families.OrderBy(x => x.GenerationNo)
                                    .ThenBy(x => x.FName)
                                    .ThenBy(x => x.BirthDay);

            return View(query.ToPagedList(currentPage, 15)); 
        }
                
        public ActionResult UploadTest(int page = 1)
        {
            // session 讀取 gID
            int currentPage = page < 1 ? 1 : page;

            var query = db.Families.OrderBy(x => x.GenerationNo)
                                    .ThenBy(x => x.FName)
                                    .ThenBy(x => x.BirthDay);

            return View(query.ToPagedList(currentPage, 15));
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

                jo.Add("Result", !string.IsNullOrWhiteSpace(uploadResult));
                jo.Add("Msg", !string.IsNullOrWhiteSpace(uploadResult) ? uploadResult : "");

                result = JsonConvert.SerializeObject(jo);
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
                if (System.IO.File.Exists(Path.Combine(filePath,file.FileName))) // 驗證檔案是否存在
                {
                    System.IO.File.Delete(Path.Combine(filePath,file.FileName));
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
            string result="";

            try
            {
                var fileName = string.Concat(Server.MapPath(fileSavedPath), "/", savedFileName);

                var importFamilies = new List<Family>();

                var helper = new ImportDataHelper();
                var checkResult = helper.CheckImportGeneData(fileName, importFamilies);

                if (checkResult.Success)
                {
                    //儲存匯入的資料
                    CheckResult saveResult = helper.SaveImportGeneData(importFamilies);

                    if (saveResult.ErrorMessage != "")
                        saveResult.Success = false;

                    jo.Add("Result", saveResult.Success);
                    jo.Add("Msg", saveResult.Success ? string.Empty : checkResult.ErrorMessage);
                }
                else
                {
                    jo.Add("Result", checkResult.Success);
                    jo.Add("Msg", checkResult.Success ? string.Empty : checkResult.ErrorMessage);
                }
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
            bool result = !db.Families.Count().Equals(0);
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
