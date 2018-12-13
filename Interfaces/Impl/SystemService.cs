using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using Models;

namespace Interfaces.Impl
{
    public class SystemService : ISystemService
    {
        public bool addArea(SYS_AREA area, string connectionString)
        {
            bool _user = false;
            string sql = $@"INSERT INTO `sys_area` ( `name`, `abbreviation`)
VALUES
	(
		'{area.NAME}',
'{area.ABBREVIATION}'
	);";
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(DBType.mysql, connectionString))
            {
                var obj = conn.Execute(sql);
                if (obj >=1)
                {
                    _user = true;
                }
            }
            return _user;
        }

        public bool addRoom(SYS_ROOMINFO room, string connectionString)
        {
            bool _user = false;
            string sql = $@"INSERT INTO `bcr`.`sys_roominfo` ( `name`, `area`, `status`) VALUES
	(
		'{room.NAME}',{room.AREA},{room.STATUS});";
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(DBType.mysql, connectionString))
            {
                var obj = conn.Execute(sql);
                if (obj >= 1)
                {
                    _user = true;
                }
            }
            return _user;
        }

        public bool addUser(SYS_USER room, string connectionString)
        {
            bool _user = false;
            string sql = $@"INSERT INTO `sys_user` (
`id`,
	`username`,
	`password`,
	`email`,
	`area`,
	`updatetime`
)
VALUES
	(
'{room.ID}',
		'{room.USERNAME}',
		'{room.PASSWORD}',
		'{room.EMAIL}',
		{room.AREA},
		'{DateTime.Now}'
	);";
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(DBType.mysql, connectionString))
            {
                var obj = conn.Execute(sql);
                if (obj >= 1)
                {
                    _user = true;
                }
            }
            return _user;
        }

        public bool AuthTime(string roomid,DateTime starttime, DateTime endtime, string connectionString = null)
        {
            bool _user = false;
            string sql = $@"SELECT count(1) num from sys_bookinfo where roomid='{roomid}' and 
(('{starttime}' >= starttime and '{starttime}' < endtime)
or('{endtime}'> starttime and '{endtime}' <= endtime)
or ('{starttime}'<starttime and '{endtime}'>endtime))";
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(DBType.mysql, connectionString))
            {
                var obj = conn.ExecuteScalar<int>(sql);
                if (obj == 0)
                {
                    _user = true;
                }
            }
            return _user;
        }

        public SYS_USER AuthUser(string username, string password, string connstr)
        {
            SYS_USER _user = null;
            string sql = $"SELECT * from sys_user where username='{username}' and `password`='{password}'";
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(DBType.mysql, connstr))
            {
                var obj=conn.Query<SYS_USER>(sql).AsList();
                if (obj!=null&&obj.Count>=1)
                {
                    _user = (SYS_USER)obj[0];
                }
            }
            return _user;
        }

        public bool BookRoom(SYS_BOOKINFO book, string connectionString = null)
        {
            bool _user = false;
            string sql = $@"INSERT INTO `sys_bookinfo` (
	`roomid`,
	`starttime`,
	`endtime`,
	`status`,
	`uid`,
	`meetname`
)
VALUES
	(
		'{book.ROOMID}',
		'{book.STARTTIME}',
		'{book.ENDTIME}',
		'{book.STATUS}',
		'{book.UID}',
		'{(book.MEETNAME)}'
	);";
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(DBType.mysql, connectionString))
            {
                var obj = conn.Execute(sql);
                if (obj >=1)
                {
                    _user = true;
                }
            }
            return _user;
        }

        public bool CreateEntity(SYS_USER entity, string connectionString = null)
        {
            throw new NotImplementedException();
        }

        public bool delBook(int id, string connectionString)
        {
            bool _user = false;
            string sql = $@"DELETE from sys_bookinfo where id='{id}'";
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(DBType.mysql, connectionString))
            {
                var obj = conn.Execute(sql);
                if (obj >= 1)
                {
                    _user = true;
                }
            }
            return _user;
        }

        public bool DeleteEntityById(int id, string connectionString = null)
        {
            throw new NotImplementedException();
        }

        public bool editUserPwd(string id,string pwd, string connectionString = null)
        {
            bool _user = false;
            string sql = $@"update sys_user set `password`='{pwd}' where id='{id}'";
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(DBType.mysql, connectionString))
            {
                var obj = conn.Execute(sql);
                if (obj >= 1)
                {
                    _user = true;
                }
            }
            return _user;
        }

        /// <summary>
        /// 获取区域信息
        /// </summary>
        /// <returns></returns>
        public List<SYS_AREA> getArea(string connectionString)
        {
            List<SYS_AREA> _user = null;
            string sql = $"SELECT * from sys_area";
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(DBType.mysql, connectionString))
            {
                var obj = conn.Query<SYS_AREA>(sql).AsList();
                if (obj != null && obj.Count >= 1)
                {
                    return obj;
                }
            }
            return _user;
        }

        public List<SYS_BOOKINFO> getBook(string connectionString)
        {
            List<SYS_BOOKINFO> _user = null;
            string sql = $"SELECT * from sys_bookinfo";
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(DBType.mysql, connectionString))
            {
                var obj = conn.Query<SYS_BOOKINFO>(sql).AsList();
                if (obj != null && obj.Count >= 1)
                {
                    return obj;
                }
            }
            return _user;
        }

        public List<SYS_ROOMINFO> getRoom(string connectionString)
        {
            List<SYS_ROOMINFO> _user = null;
            string sql = $"SELECT * from sys_roominfo";
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(DBType.mysql, connectionString))
            {
                var obj = conn.Query<SYS_ROOMINFO>(sql).AsList();
                if (obj != null && obj.Count >= 1)
                {
                    return obj;
                }
            }
            return _user;
        }

        public List<SYS_ROOMINFO> GetRoomInfo(string connectionString = null)
        {
            List<SYS_ROOMINFO> _user = null;
            string sql = $"SELECT * from sys_roominfo where `status`=1";
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(DBType.mysql, connectionString))
            {
                var obj = conn.Query<SYS_ROOMINFO>(sql).AsList();
                if (obj != null && obj.Count >= 1)
                {
                    return obj;
                }
            }
            return _user;
        }

        public List<SYS_USER> getUser(string connectionString)
        {
            List<SYS_USER> _user = null;
            string sql = $"SELECT * from sys_user where area!=0";
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(DBType.mysql, connectionString))
            {
                var obj = conn.Query<SYS_USER>(sql).AsList();
                if (obj != null && obj.Count >= 1)
                {
                    return obj;
                }
            }
            return _user;
        }

        /// <summary>
        /// 判断会议室是否停用
        /// </summary>
        /// <param name="roomid"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public bool IsStop(string roomid, string connectionString = null)
        {
            bool _user = false;
            string sql = $"SELECT `status` from sys_roominfo where id='{roomid}'";
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(DBType.mysql, connectionString))
            {
                var obj = conn.ExecuteScalar<int>(sql);
                if (obj == 0)
                {
                    _user = true;
                }
            }
            return _user;
        }

        public IEnumerable<SYS_USER> RetriveAllEntity(string connectionString = null)
        {
            throw new NotImplementedException();
        }

        public SYS_USER RetriveOneEntityById(int id, string connectionString = null)
        {
            SYS_USER _USER;
            string sql = $"SELECT * from sys_user where id='{id}'";
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(DBType.mysql, connectionString))
            {
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                object obj=cmd.ExecuteScalar();
                _USER = (SYS_USER)obj;
            }
            return _USER;
        }

        public bool UpdateEntity(SYS_USER entity, string connectionString = null)
        {
            throw new NotImplementedException();
        }
    }
}
