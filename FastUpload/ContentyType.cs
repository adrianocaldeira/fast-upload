using System.Collections.Generic;
using System.Linq;

namespace FastUpload
{
    public class ContentyType
    {
        static ContentyType()
        {
            Types = new List<ContentyType>();
        }
        public string Type { get; set; }
        public string Extension { get; set; }

        public static IList<ContentyType> Types { get; set; }

        public static string Get(string file)
        {
            var contentyType = Types.FirstOrDefault(x => x.Extension == System.IO.Path.GetExtension(file));
            return contentyType == null ? string.Empty : contentyType.Type;
        }
    }
}