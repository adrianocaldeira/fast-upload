namespace FastUpload.Models
{
    public class UploadSettingMessage
    {
        public UploadSettingMessage()
        {
            FileSizeExceed = "The file {0} exceeds limit allowed of {1} by file.";
            ExtensionInvalid = "The extension of file {0} is invalid. The extensions are allowed {1}.";
        }
        public string FileSizeExceed { get; set; }
        public string ExtensionInvalid { get; set; }
    }
}