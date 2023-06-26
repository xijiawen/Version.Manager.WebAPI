using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version.Manager.Model.Entitys;

namespace Version.Manager.Service.Services
{
    public class DBCreate
    {//配置数据连接串确保mysql能工作     UserManage数据库此时并不存在 
        public static string DB_ConnectionString 
            = "Data Source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = 172.20.170.39)(PORT = 1521)))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = d1mpdb)));User ID=d1mpadm;Password=Mp#0328;";
        public static string DB_SqlserverConnectionString { get; set; }
        public static SqlSugarClient db
        {
            get => new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = DB_ConnectionString,
                DbType = DbType.Oracle,
                IsAutoCloseConnection = true,
                //  InitKeyType = InitKeyType.SystemTable, //已建立数据库和表配置此属性
                // IsShardSameThread = true

                InitKeyType = InitKeyType.Attribute  // 一定要配置此属性 ，否则生成数据库会报错
            }
            );

        }

        public static void createDB()
        {
            db.DbMaintenance.CreateDatabase(); //创建数据库

            db.CodeFirst.InitTables(
                typeof(Version.Manager.Model.Entitys.VersionManagerEntity),
                typeof(Version.Manager.Model.Entitys.SystemEntity),
                typeof(Version.Manager.Model.Entitys.FileManagerEntity)
                );

        }
    }
}
