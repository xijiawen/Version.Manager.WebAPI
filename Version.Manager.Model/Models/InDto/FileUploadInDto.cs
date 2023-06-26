using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version.Manager.Model.Models.InDto
{
    public class FileUploadInDto
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public string fileName { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        public string versionNo { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public int fileType { get; set; }

        public byte[] fileData { get; set; }

        public int fileSize { get; set; }
    }
}
