using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version.Manager.Model.Models.InDto
{
    public class VersionManagerInDto
    {
        /// <summary>
        /// 是否是最新版本（0不是，1是）
        /// </summary>
        public int IsNew { get; set; }

        /// <summary>
        /// 系统名称
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// 系统类型
        /// </summary>
        public int SystemType { get; set; }

        /// <summary>
        /// 是否加入版本管控
        /// </summary>
        public int IsAddVersionManager { get; set; }
    }
}
