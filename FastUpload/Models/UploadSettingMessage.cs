namespace FastUpload.Models
{
    /// <summary>
    /// Upload setting message
    /// </summary>
    public class UploadSettingMessage
    {
        /// <summary>
        /// Initialize new instance of class <see cref="UploadSettingMessage"/>
        /// </summary>
        public UploadSettingMessage()
        {
            FileSizeExceed = "The file {0} exceeds limit allowed of {1} by file.";
            ExtensionInvalid = "The extension of file {0} is invalid. The extensions are allowed {1}.";
        }

        /// <summary>
        /// Get or set file size exceed
        /// </summary>
        public string FileSizeExceed { get; set; }

        /// <summary>
        /// Get or set extension invalid
        /// </summary>
        public string ExtensionInvalid { get; set; }
    }
}