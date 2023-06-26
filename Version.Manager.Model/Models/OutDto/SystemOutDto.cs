using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version.Manager.Model.Models.OutDto
{
    public class SystemOutDto:MyBaseEntity
    {
        /// <summary>
        /// 系统名称
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// 系统中文名称
        /// </summary>
        public string SystemNameChinese { get; set; }

        /// <summary>
        /// 是否加入版本管控
        /// </summary>
        public bool IsAddVersionManager { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
