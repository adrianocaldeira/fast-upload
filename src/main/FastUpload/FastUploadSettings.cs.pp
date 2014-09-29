using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace $rootnamespace$
{
    /// <summary>
    /// Settings
    /// </summary>
    public class FastUploadSettings
    {
        /// <summary>
        /// Get storage path
        /// </summary>
        public static string StoragePath = ConfigurationManager.AppSettings["FastUploadSettings.StoragePath"];

        /// <summary>
        /// Get tokens
        /// </summary>
        public static IList<string> Tokens = ConfigurationManager.AppSettings["FastUploadSettings.Tokens"].Split(';').ToList();

        /// <summary>
        /// Get domains
        /// </summary>
        public static IList<string> Domains = ConfigurationManager.AppSettings["FastUploadSettings.Domains"].Split(';').ToList();
    }
}