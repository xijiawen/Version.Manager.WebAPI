using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version.Manager.Model.Models.InDto
{
    public class VersionManagerUpdateInDto
    {
        public string Id { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 是否是最新版本
        /// </summary>
        public int IsNew { get; set; }

        /// <summary>
        /// 系统类型Id
        /// </summary>
        public string SystemId { get; set; }
    }
}
