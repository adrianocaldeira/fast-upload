using System.Collections.Generic;
using System.Linq;

namespace FastUpload
{
    /// <summary>
    /// Content type
    /// </summary>
    public class ContentType
    {
        /// <summary>
        /// Initializa new static instace of <see cref="ContentType"/>
        /// </summary>
        static ContentType()
        {
            Types = new List<ContentType>();
        }

        /// <summary>
        /// Get or set type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Get or set extension
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Get or set list of <see cref="ContentType"/>
        /// </summary>
        public static IList<ContentType> Types { get; set; }

        /// <summary>
        /// Get type of file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string Get(string file)
        {
            var contentyType = Types.FirstOrDefault(x => x.Extension == System.IO.Path.GetExtension(file));
            return contentyType == null ? "application/octet-stream" : contentyType.Type;
        }
    }
}