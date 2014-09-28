using System.Linq;
using System.Web.Mvc;
using FastUpload.Filters;
using FastUpload.Models;

namespace FastUpload.Controllers
{
    [FastUploadSecurity]
    [RoutePrefix("api/uploads")]
    public class UploadsController : Controller
    {
        [Route]
        [HttpGet]
        public ActionResult Index(UploadSetting setting)
        {
            return View(setting);
        }

        [HttpPost]
        [Route("send")]
        public ActionResult Send(UploadSetting setting)
        {
            var files = Request.Files.Cast<string>().Select(
                file => Models.File.Upload(setting.Directory, Request.Files[file])
            ).Where(fileUploaded => fileUploaded != null).ToList();

            return new JsonResult{Data = files};
        }
    }
}