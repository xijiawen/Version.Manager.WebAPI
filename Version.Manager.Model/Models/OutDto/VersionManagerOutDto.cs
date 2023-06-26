using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version.Manager.Model.Models.OutDto
{
    public class VersionManagerOutDto
    {
        /// <summary>
        /// 版本表主键
        /// </summary>
        public string Id { get; set; }

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
        public string SystemId { get; set; }

        /// <summary>
        /// 是否加入版本管控
        /// </summary>
        public int IsAddVersionManager { get; set; }
        public string Version { get; set; }
    }
}
