using System.IO;
using System.Web;

namespace FastUpload.Models
{
    /// <summary>
    ///     File
    /// </summary>
    public class File
    {
        /// <summary>
        ///     Get or set file name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Get or set path of file
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        ///     Get or set size
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        ///     Get or set type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     Upload file
        /// </summary>
        /// <param name="baseDirectory"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static File Upload(string baseDirectory, HttpPostedFileBase file)
        {
            if (file.ContentLength.Equals(0)) return null;

            if (baseDirectory == null) baseDirectory = "";

            var directory = baseDirectory.Replace("/", @"\");
            var storageDirectory = System.IO.Path.Combine(Settings.StoragePath, directory);
            var path = System.IO.Path.Combine(directory, file.FileName);

            if (!Directory.Exists(storageDirectory))
            {
                Directory.CreateDirectory(storageDirectory);
            }

            file.SaveAs(System.IO.Path.Combine(Settings.StoragePath, path));

            return new File
            {
                Name = file.FileName,
                Path = path.Replace(@"\", "/"),
                Size = file.ContentLength,
                Type = file.ContentType
            };
        }

        /// <summary>
        ///     Get file path with storage directory
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetFilePath(string file)
        {
            return System.IO.Path.Combine(Settings.StoragePath, file);
        }
    }
}