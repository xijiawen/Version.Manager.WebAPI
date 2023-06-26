using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version.Manager.Model.Entitys
{
    [SugarTable("FILE_MANAGER")]
    public class FileManagerEntity:MyBaseEntity
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        [SugarColumn(ColumnName = "FILE_NAME", ColumnDataType = "varchar(100)", 
            ColumnDescription = "文件名称")]
        public string FileName { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        [SugarColumn(ColumnName = "FILE_TYPE", ColumnDataType = "varchar(100)",
            ColumnDescription = "文件类型",IsNullable=true)]
        public string? FileType { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        [SugarColumn(ColumnName = "VERSION", ColumnDataType = "varchar(100)",
            ColumnDescription = "版本",IsNullable=true)]
        public string? Version { get; set; }

        /// <summary>
        /// 文件存放路径(绝对路径)
        /// </summary>
        [SugarColumn(ColumnName = "FILE_PATH", ColumnDataType = "varchar(200)",
            ColumnDescription = "文件存放路径(绝对路径)")]
        public string FilePath { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        [SugarColumn(ColumnName = "FILE_SIZE", ColumnDataType = "NUMBER(10,0)",
            ColumnDescription = "文件大小")]
        public int FileSize { get; set; }
    }
}
