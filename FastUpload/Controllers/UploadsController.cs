using System;
using System.Collections.Generic;
using System.Web.Mvc;
using File = FastUpload.Models.File;

namespace FastUpload.Controllers
{
    public class UploadsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Send(string directory)
        {
            var files = new List<File>();

            foreach (string file in Request.Files)
            {
                var fileUploaded = Models.File.Upload(directory, Request.Files[file]);

                if (fileUploaded != null) files.Add(fileUploaded);
            }

            return new JsonResult{Data = files};
        }
    }
}