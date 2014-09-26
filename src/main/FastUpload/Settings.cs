using System.Configuration;

namespace FastUpload
{
    /// <summary>
    /// Settings
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Get storage path
        /// </summary>
        public static string StoragePath = ConfigurationManager.AppSettings["Settings.StoragePath"];
    }
}