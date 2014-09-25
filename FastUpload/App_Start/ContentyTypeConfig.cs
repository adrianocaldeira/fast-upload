using System.Collections.Generic;
using Newtonsoft.Json;

namespace FastUpload
{
    public class ContentyTypeConfig
    {
        public static void RegisterTypes(string file)
        {
            ContentType.Types = JsonConvert.DeserializeObject<List<ContentType>>(System.IO.File.ReadAllText(file));
        }
    }
}