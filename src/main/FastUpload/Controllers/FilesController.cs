using System.Web.Mvc;

namespace FastUpload.Controllers
{
    public class FilesController : Controller
    {
        //[OutputCache(Duration = 300, VaryByParam = "file")]
        public ActionResult Read(string file)
        {
            if (string.IsNullOrEmpty(file))
                return new HttpNotFoundResult();

            var filePath = Models.File.GetFilePath(file);

            if (!System.IO.File.Exists(filePath))
                return new HttpNotFoundResult();

            return File(filePath, ContentType.Get(file));
        }

        //[OutputCache(Duration = 300, VaryByParam = "file")]
        public ActionResult Download(string file)
        {
            if (string.IsNullOrEmpty(file))
                return new HttpNotFoundResult();

            var filePath = Models.File.GetFilePath(file);

            if (!System.IO.File.Exists(filePath))
                return new HttpNotFoundResult();

            return File(filePath, ContentType.Get(file), System.IO.Path.GetFileName(filePath));            
        }
    }
}