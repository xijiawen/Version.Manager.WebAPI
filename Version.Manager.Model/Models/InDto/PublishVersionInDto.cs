using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version.Manager.Model.Models.InDto
{
    public class PublishVersionInDto
    {
        /// <summary>
        /// 系统类型
        /// </summary>
        public string SystemId { get; set; }

        /// <summary>
        /// 当前版本
        /// </summary>
        public string CurrentVersion { get; set; } 

        /// <summary>
        /// 版本
        /// </summary>
        public string Version { get; set; } 

        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        public int FileSize { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set;}
    }
}
