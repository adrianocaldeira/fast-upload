namespace FastUpload.Models
{
    /// <summary>
    ///     Upload setting
    /// </summary>
    public class UploadSetting
    {
        /// <summary>
        ///     Initialize new instance of class <see cref="UploadSetting" />
        /// </summary>
        public UploadSetting()
        {
            LimitFileSize = 4000000; //4MB
            Extensions = "*";
            Message = new UploadSettingMessage();
        }

        /// <summary>
        ///     Get or set directory
        /// </summary>
        public string Directory { get; set; }

        /// <summary>
        /// Get or set token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        ///     Get or set limit file siz
        /// </summary>
        public int LimitFileSize { get; set; }

        /// <summary>
        ///     Get or set extensions
        /// </summary>
        public string Extensions { get; set; }

        /// <summary>
        /// Get or set target origin domain
        /// </summary>
        public string TargetOrigin { get; set; }

        /// <summary>
        ///     Get or set <see cref="UploadSettingMessage" />
        /// </summary>
        public UploadSettingMessage Message { get; set; }
    }
}