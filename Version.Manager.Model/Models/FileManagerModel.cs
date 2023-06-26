namespace Version.Manager.Model.Models
{
    public class FileManagerModel : MyBaseEntity
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public string? FileType { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        public string? Version { get; set; }

        /// <summary>
        /// 文件存放路径(绝对路径)
        /// </summary>
        public string FilePath { get; set; }
    }
}
