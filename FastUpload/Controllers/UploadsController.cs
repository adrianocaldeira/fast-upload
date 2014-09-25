using System.Collections.Generic;
using System.Web.Mvc;
using FastUpload.Models;
using File = FastUpload.Models.File;

namespace FastUpload.Controllers
{
    public class UploadsController : Controller
    {
        [HttpGet]
        public ActionResult Index(UploadSetting setting)
        {
            return View(setting);
        }

        [HttpPost]
        public ActionResult Send(UploadSetting setting)
        {
            var files = new List<File>();

            foreach (string file in Request.Files)
            {
                var fileUploaded = Models.File.Upload(setting.Directory, Request.Files[file]);

                if (fileUploaded != null) files.Add(fileUploaded);
            }

            return new JsonResult{Data = files};
        }
    }
}