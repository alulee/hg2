using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using HGenealogy.Core;
//using Nop.Services.Security;
//using Nop.Web.Framework.Security;

namespace HGenealogy.Controllers
{
    /// <summary>
    /// Controller used by jbimages (JustBoil.me) plugin (TimyMCE)
    /// </summary>
    //do not validate request token (XSRF)
    //[AdminAntiForgery(true)]
    public partial class JbimagesController : BaseAdminController
    {
        //private readonly IPermissionService _permissionService;
        private readonly IWebHelper _webHelper;
        private readonly string Directory = "~/content/images/uploaded/";


        //public JbimagesController(IPermissionService permissionService,
        //    IWebHelper webHelper)
        public JbimagesController(IWebHelper webHelper)
        {
            //this._permissionService = permissionService;
            this._webHelper = webHelper;
        }

        [NonAction]
        protected virtual IList<string> GetAllowedFileTypes()
        {
            return new List<string> { ".gif", ".jpg", ".jpeg", ".png", ".bmp" };
        }

        [HttpPost]
        public ActionResult Upload()
        {
            //if (!_permissionService.Authorize(StandardPermissionProvider.HtmlEditorManagePictures))
            //{
            //    ViewData["resultCode"] = "failed";
            //    ViewData["result"] = "No access to this functionality";
            //    return View();
            //}

            if (Request.Files.Count == 0)
                throw new Exception("No file uploaded");

            var uploadFile = Request.Files[0];
            if (uploadFile == null)
            {
                ViewData["resultCode"] = "failed";
                ViewData["result"] = "No file name provided";
                return View();
            }

            var fileName = Path.GetFileName(uploadFile.FileName);
            if (String.IsNullOrEmpty(fileName))
            {
                ViewData["resultCode"] = "failed";
                ViewData["result"] = "No file name provided";
                return View();
            }

            //var directory = "~/content/images/uploaded/";
            var filePath = Path.Combine(_webHelper.MapPath(Directory), fileName);

            var fileExtension = Path.GetExtension(filePath);
            if (!GetAllowedFileTypes().Contains(fileExtension.ToLower()))
            {
                ViewData["resultCode"] = "failed";
                ViewData["result"] = string.Format("Files with {0} extension cannot be uploaded", fileExtension);
                return View();
            }

            uploadFile.SaveAs(filePath);

            ViewData["resultCode"] = "success";
            ViewData["result"] = "success";
            ViewData["filename"] = this.Url.Content(string.Format("{0}{1}", Directory, fileName));
            return View();
        }



        //改寫成頁面可直接使用的方法
        [HttpPost]
        public ActionResult Upload2()
        {
            //if (!_permissionService.Authorize(StandardPermissionProvider.HtmlEditorManagePictures))
            //{
            //    ViewData["resultCode"] = "failed";
            //    ViewData["result"] = "No access to this functionality";
            //    return View();
            //}

            if (Request.Files.Count == 0)
                throw new Exception("No file uploaded");

            var uploadFile = Request.Files[0];
            if (uploadFile == null)
            {
                //ViewData["resultCode"] = "failed";
                //ViewData["result"] = "No file name provided";
                //return View();
                return Json(new { resultCode = "failed", result = "No file name provided" });
            }

            var fileName = Path.GetFileName(uploadFile.FileName);
            if (String.IsNullOrEmpty(fileName))
            {
                //ViewData["resultCode"] = "failed";
                //ViewData["result"] = "No file name provided";
                //return View();
                return Json(new { resultCode = "failed", result = "No file name provided" });
            }

            //var directory = "~/content/images/uploaded/";
            var filePath = Path.Combine(_webHelper.MapPath(Directory), fileName);

            var fileExtension = Path.GetExtension(filePath);
            //if (!GetAllowedFileTypes().Contains(fileExtension))
            //{
            //    ViewData["resultCode"] = "failed";
            //    ViewData["result"] = string.Format("Files with {0} extension cannot be uploaded", fileExtension);
            //    return View();
            //}

            if (!GetAllowedFileTypes().Contains(fileExtension.ToLower()))
            {
                //ViewData["resultCode"] = "failed";
                //ViewData["result"] = string.Format("Files with {0} extension cannot be uploaded", fileExtension);
                return Json(new { resultCode = "failed", result = string.Format("Files with {0} extension cannot be uploaded", fileExtension) });
            }

            uploadFile.SaveAs(filePath);

            //ViewData["resultCode"] = "success";
            //ViewData["result"] = "success";
            //ViewData["filename"] = this.Url.Content(string.Format("{0}{1}", directory, fileName));
            //return View();
            return Json(new { resultCode = "success", result = "success", filename = this.Url.Content(string.Format("{0}{1}", Directory, fileName)) });
        }
    }
}
