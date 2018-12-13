using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ISystemService:IBaseBusiness<SYS_USER>
    {
        /// <summary>
        /// 验证用户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="connstr"></param>
        /// <returns></returns>
        SYS_USER AuthUser(string username,string password,string connstr);
        /// <summary>
        /// 获取会议室信息
        /// </summary>
        /// <returns></returns>
        List<SYS_ROOMINFO> GetRoomInfo(string connectionString = null);
        bool IsStop(string roomid,string connectionString = null);
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="pwd"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        bool editUserPwd(string id, string pwd,string connectionString = null);
        /// <summary>
        /// 预约
        /// </summary>
        /// <param name="book"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        bool BookRoom(SYS_BOOKINFO book, string connectionString = null);
        /// <summary>
        /// 验证会议时间
        /// </summary>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        bool AuthTime(string roomid, DateTime starttime, DateTime endtime, string connectionString = null);

        List<SYS_AREA> getArea(string connectionString);
        List<SYS_ROOMINFO> getRoom(string connectionString);
        List<SYS_USER> getUser(string connectionString);
        List<SYS_BOOKINFO> getBook(string connectionString);
        bool addArea(SYS_AREA area,string connectionString);
        bool addRoom(SYS_ROOMINFO room,string connectionString);
        bool addUser(SYS_USER room,string connectionString);
        bool delBook(int id,string connectionString);
    }
}
