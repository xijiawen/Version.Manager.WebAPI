using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version.Manager.Model
{
    public class MyBaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(ColumnName="ID",ColumnDataType = "varchar(40)", IsPrimaryKey = true)]
        public string Id { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [SugarColumn(ColumnName = "CREATER_USER", ColumnDataType = "varchar(40)",ColumnDescription ="创建人")]
        public string CreateUser { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        [SugarColumn(ColumnName = "UPDATE_USER", ColumnDataType = "varchar(40)", ColumnDescription = "更新人")]
        public string UpdateUser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(ColumnName = "CREATE_TIME", ColumnDataType = "DATE", ColumnDescription = "创建时间")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [SugarColumn(ColumnName = "UPDATE_TIME", ColumnDataType = "DATE", ColumnDescription = "更新时间")]
        public DateTime UpdateTime { get; set; }
    }
}
