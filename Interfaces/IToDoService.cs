using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IToDoService : IBaseBusiness<SYS_TODOLIST>
    {
        /// <summary>
        /// 添加待办
        /// </summary>
        /// <param name="todo"></param>
        /// <param name="connstr"></param>
        /// <returns></returns>
        bool addToDo(SYS_TODOLIST todo,string connstr);
        /// <summary>
        /// 修改进度
        /// </summary>
        /// <param name="id"></param>
        /// <param name="progress"></param>
        /// <param name="connstr"></param>
        /// <returns></returns>
        bool editProgress(string id, int progress, string connstr);
        /// <summary>
        /// 完成
        /// </summary>
        /// <param name="id"></param>
        /// <param name="connstr"></param>
        /// <returns></returns>
        bool completeToDo(string id, string connstr);
        List<SYS_PRIORITY> getPriority(string connstr);
        /// <summary>
        /// 待办列表
        /// </summary>
        /// <param name="connstr"></param>
        /// <returns></returns>
        List<ToDoModel> getToDo(string uid, string connstr);
    }
}
