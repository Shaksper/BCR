using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Interfaces.Impl
{
    /// <summary>
    /// 数据库配置
    /// </summary>
    public class DataBaseConfig
    {
        #region SqlServer链接配置
        /// <summary>
        /// 默认的Sql Server的链接字符串
        /// </summary>
        private static string DefaultSqlConnectionString =  @"Data Source=.;Initial Catalog=test;User ID=sa;Password=sa;";
        public static IDbConnection GetSqlConnection(DBType type,string sqlConnectionString = null)
        {
            if (string.IsNullOrWhiteSpace(sqlConnectionString))
            {
                sqlConnectionString = DefaultSqlConnectionString;
            }
            IDbConnection conn = null;
            switch (type)
            {
                case DBType.mysql:
                    conn=new MySqlConnection(sqlConnectionString);
                    break;
                case DBType.sqlserver:
                    conn = new SqlConnection(sqlConnectionString);
                    break;
                case DBType.sqlite:
                    break;
                default:
                    break;
            }
            
            conn.Open();
            return conn;
        }
        #endregion
    }
}
