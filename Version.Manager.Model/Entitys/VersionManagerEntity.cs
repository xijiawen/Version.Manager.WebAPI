using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version.Manager.Model.Entitys
{
    [SugarTable("VERSION_MANAGER")]
    public class VersionManagerEntity: MyBaseEntity
    {
        /// <summary>
        /// 版本号
        /// </summary>
        [SugarColumn(ColumnName="VERSION",ColumnDataType = "varchar(20)", ColumnDescription = "版本号")]
        public string Version { get; set; }

        /// <summary>
        /// 是否是最新版本
        /// </summary>
        [SugarColumn(ColumnName = "IS_NEW", ColumnDataType = "NUMBER(2,0)", ColumnDescription = "是否是最新版本,1不是2是")]
        public int IsNew { get; set; }

        /// <summary>
        /// 系统类型Id
        /// </summary>
        [SugarColumn(ColumnName = "SYSTEM_ID", ColumnDataType = "varchar(40)", ColumnDescription = "系统类型Id")]
        public string SystemId { get; set; }

        /// <summary>
        /// 文件ID
        /// </summary>
        [SugarColumn(ColumnName = "FILE_ID", ColumnDataType = "varchar(40)", ColumnDescription = "文件ID")]
        public string FileId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnName = "REMARK", ColumnDataType = "varchar(200)", ColumnDescription = "备注")]
        public string Remark { get; set; }
    }
}
