using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Interfaces.Impl
{
    public class RoomService : IRoomService
    {/// <summary>
    /// 获取会议室预定情况
    /// </summary>
    /// <param name="area"></param>
    /// <returns></returns>
        public List<AreaBook> AreaBook(int areaid, string connectionString)
        {
            List<AreaBook> books = new List<AreaBook>();
            string sql = $@"SELECT b.starttime,b.endtime,b.`status`,b.meetname,u.username,r.`name` roomname 
from sys_roominfo r
LEFT JOIN sys_bookinfo b on b.roomid=r.id 
LEFT JOIN sys_user u on b.uid=u.id
LEFT JOIN sys_area a on r.area=a.id 
where  a.id={areaid}
 ORDER BY starttime";
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(DBType.mysql, connectionString))
            {
                var obj = conn.Query<AreaBook>(sql).AsList();
                if (obj !=null&&obj.Count>=1)
                {
                    books = obj;
                }
            }
            return books;

        }

        public bool CreateEntity(SYS_ROOMINFO entity, string connectionString = null)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEntityById(int id, string connectionString = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SYS_ROOMINFO> RetriveAllEntity(string connectionString = null)
        {
            throw new NotImplementedException();
        }

        public SYS_ROOMINFO RetriveOneEntityById(int id, string connectionString = null)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(SYS_ROOMINFO entity, string connectionString = null)
        {
            throw new NotImplementedException();
        }
    }
}
