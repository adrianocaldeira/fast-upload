using System;
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

        public static File Upload(string baseDirectory, HttpPostedFileBase file)
        {
            if (file.ContentLength.Equals(0)) return null;

            if (baseDirectory == null) baseDirectory = "";

            var newFileName = String.Concat(Guid.NewGuid().ToString("N"), System.IO.Path.GetExtension(file.FileName));
            var directory = System.IO.Path.Combine(Settings.StoragePath, baseDirectory);
            var path = System.IO.Path.Combine(baseDirectory, newFileName);

            if (!System.IO.Directory.Exists(directory))
            {
                System.IO.Directory.CreateDirectory(directory);
            }

            file.SaveAs(System.IO.Path.Combine(Settings.StoragePath, path));

            return new File
            {
                Name = file.FileName,
                Path = path,
                Size = file.ContentLength,
                Type = file.ContentType
            };
        }
    }
}