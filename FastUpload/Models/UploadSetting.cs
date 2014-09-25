namespace FastUpload.Models
{
    public class UploadSetting
    {
        public UploadSetting()
        {
            LimitFileSize = 4194304; //4MB
            Extensions = "*";
        }
        public string Directory { get; set; }
        public int LimitFileSize { get; set; }
        public string Extensions { get; set; }
    }
}