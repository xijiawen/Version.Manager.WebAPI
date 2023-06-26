using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version.Manager.Model.Entitys
{
    [SugarTable("SYSTEM")]
    public class SystemEntity:MyBaseEntity
    {
        ///// <summary>
        ///// 系统类型
        ///// </summary>
        //[SugarColumn(ColumnName = "System_Type", ColumnDataType = "int", ColumnDescription = "系统类型")]
        //public int SystemType { get; set; }

        /// <summary>
        /// 系统名称
        /// </summary>
        [SugarColumn(ColumnName = "SYSTEM_NAME", ColumnDataType = "varchar(80)", ColumnDescription = "系统名称")]
        public string SystemName { get; set; }

        /// <summary>
        /// 系统中文名称
        /// </summary>
        [SugarColumn(ColumnName = "SYSTEM_NAME_CHINESE", ColumnDataType = "varchar(80)", ColumnDescription = "系统中文名称")]
        public string SystemNameChinese { get; set; }

        /// <summary>
        /// 是否加入版本管控
        /// </summary>
        [SugarColumn(ColumnName = "IS_ADD_VERSION_MANAGER", ColumnDataType = "NUMBER(2,0)", ColumnDescription = "是否加入版本管控")]
        public int IsAddVersionManager { get; set; }

        /// <summary>
        /// 系统状态
        /// </summary>
        [SugarColumn(ColumnName = "STATUS", ColumnDataType = "NUMBER(2,0)", ColumnDescription = "系统状态")]
        public int Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnName = "REMARK", ColumnDataType = "varchar(200)", ColumnDescription = "备注")]
        public string Remark { get; set; }

    }
}
