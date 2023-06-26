using Microsoft.Extensions.Configuration;
using SqlSugar;

namespace Version.Manager.Service.Services
{
    public sealed class DBContext
    {
        private static SqlSugarClient db;
        private static SqlSugarClient db1;
        private static readonly object locker = new object();// 定义一个标识确保线程同步
        private DBContext() { }
        public static SqlSugarClient GetContext()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
            IConfigurationRoot root = builder.Build();
            if (db == null)
            {
                lock (locker)
                {
                    if (db == null)
                    {
                        db = new SqlSugarClient(new ConnectionConfig()
                        {
                            ConnectionString = root["OrcelDbConnection"],
                            DbType = DbType.Oracle,
                            IsAutoCloseConnection = true,//自动释放
                            InitKeyType = InitKeyType.SystemTable,
                            MoreSettings = new ConnMoreSettings()
                            {
                                IsAutoToUpper = false //禁用自动转成大写表 5.1.3.41-preview04
                            }
                        },
                        db =>
                        {
                            //(A)全局生效配置点
                            //调试SQL事件，可以删掉
                            db.Aop.OnLogExecuting = (sql, pars) =>
                            {
                                Console.WriteLine(sql);//输出sql,查看执行sql
                                                       //5.0.8.2 获取无参数化 SQL 
                                                       //UtilMethods.GetSqlString(DbType.SqlServer,sql,pars)
                            };

                        });
                    }
                }
            }
            return db;
        }
        public static SqlSugarClient GetContextOrcel()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
            IConfigurationRoot root = builder.Build();
            if (db1 == null)
            {
                lock (locker)
                {
                    if (db1 == null)
                    {
                        db1 = new SqlSugarClient(new ConnectionConfig()
                        {
                            ConnectionString = "Data Source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = 172.20.170.39)(PORT = 1521)))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = d1mpdb)));User ID=d1mpadm;Password=Mp#0328;",
                            DbType = SqlSugar.DbType.Oracle,
                            IsAutoCloseConnection = true,//自动释放,
                            InitKeyType = InitKeyType.SystemTable,
                            MoreSettings = new ConnMoreSettings()
                            {
                                IsAutoToUpper = false //禁用自动转成大写表 5.1.3.41-preview04
                            }
                        },
                        db1 =>
                        {
                            //(A)全局生效配置点
                            //调试SQL事件，可以删掉
                            db1.Aop.OnLogExecuting = (sql, pars) =>
                            {
                                Console.WriteLine(sql);//输出sql,查看执行sql
                                                       //5.0.8.2 获取无参数化 SQL 
                                                       //UtilMethods.GetSqlString(DbType.SqlServer,sql,pars)
                            };

                        });
                    }
                }
            }
            return db1;
        }
    }
}
