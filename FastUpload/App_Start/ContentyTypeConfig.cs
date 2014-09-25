using System.Collections.Generic;

namespace FastUpload
{
    public class ContentyTypeConfig
    {
        public static void RegisterTypes(string file)
        {
            ContentyType.Types = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ContentyType>>(System.IO.File.ReadAllText(file));
        }
    }
}