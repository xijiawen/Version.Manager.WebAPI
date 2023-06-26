using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version.Manager.Model.Models.InDto
{
    public class FileOperateModel
    {
        /// <summary>
        /// 目标文件夹
        /// </summary>
        public string destFile { get; set; }

        /// <summary>
        /// 源文件夹
        /// </summary>
        public string sourceFile { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string fileName { get; set; }
    }
}
