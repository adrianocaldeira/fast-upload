using System.Web.Mvc;

namespace FastUpload.Controllers
{
    public class FilesController : Controller
    {
        public ActionResult Read(string file)
        {
            if (string.IsNullOrEmpty(file))
                return new HttpNotFoundResult();

            var filePath = Models.File.GetFilePath(file);

            if (!System.IO.File.Exists(filePath))
                return new HttpNotFoundResult();

            return File(filePath, ContentyType.Get(file));
        }
    }
}