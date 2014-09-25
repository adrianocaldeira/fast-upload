namespace FastUpload.Models
{
    public class UploadSetting
    {
        public UploadSetting()
        {
            LimitFileSize = 4000000; //4MB
            Extensions = "*";
            Message = new UploadSettingMessage();
        }
        public string Directory { get; set; }
        public int LimitFileSize { get; set; }
        public string Extensions { get; set; }
        public UploadSettingMessage Message { get; set; }
    }
}