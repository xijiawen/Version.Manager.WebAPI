using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version.Manager.Model.Models.InDto
{
    public class SystemInDto
    {
        public string Id { get; set; }

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
        public int IsAddVersionManager { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
