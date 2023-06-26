using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version.Manager.Model.Entitys
{
    [SugarTable("TT_FILE")]
    public class MESFileEntity
    {

        /// <summary>
        /// id
        /// </summary>
        [SugarColumn(ColumnName = "TT_FILE_ID", IsPrimaryKey =true, IsIdentity = true,ColumnDataType = "NUMBER(10,0)",
            ColumnDescription = "id")]
        public int ttFileId { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        [SugarColumn(ColumnName = "FILE_TYPE", ColumnDataType = "NUMBER(10,0)",
            ColumnDescription = "文件类型")]
        public int fileType { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
        [SugarColumn(ColumnName = "FILE_NAME", ColumnDataType = "varchar(120)",
            ColumnDescription = "文件名")]
        public string fileName { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        [SugarColumn(ColumnName = "VERSION_NO", ColumnDataType = "varchar(120)",
            ColumnDescription = "版本")]
        public string versionNo { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        [SugarColumn(ColumnName = "FILE_URL", ColumnDataType = "varchar(100)",
            ColumnDescription = "文件路径")]
        public string fileUrl { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnName = "COMMENTS", ColumnDataType = "varchar(200)",
            ColumnDescription = "备注")]
        public string comments { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [SugarColumn(ColumnName = "CREATE_USER", ColumnDataType = "varchar(40)", ColumnDescription = "创建人")]
        public string createUser { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        [SugarColumn(ColumnName = "UPDATE_USER", ColumnDataType = "varchar(40)", ColumnDescription = "更新人")]
        public string updateUser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(ColumnName = "CREATE_DATE", ColumnDataType = "DATE", ColumnDescription = "创建时间")]
        public DateTime createDate { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [SugarColumn(ColumnName = "UPDATE_DATE", ColumnDataType = "DATE", ColumnDescription = "更新时间")]
        public DateTime updateDate { get; set; }

    }
}
