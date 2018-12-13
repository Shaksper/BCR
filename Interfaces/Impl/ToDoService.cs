using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using Models;

namespace Interfaces.Impl
{
    public class ToDoService : IToDoService
    {
        public bool addToDo(SYS_TODOLIST todo, string connstr)
        {
            bool _user = false;
            string sql = $@"INSERT INTO `sys_todolist` (
	`id`,
	`title`,
	`content`,
	`priority`,
	`endtime`,
	`progress`,
	`uid`,
	`createtime`
)
VALUES
	(
		'{todo.ID}',
		'{todo.TITLE}',
		'{todo.CONTENT}',
		'{todo.PRIORITY}',
		NULL,
		'{todo.PROGRESS}',
		'{todo.UID}',
		'{todo.CREATETIME}'
	);";
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(DBType.mysql, connstr))
            {
                var obj = conn.Execute(sql);
                if (obj >= 1)
                {
                    _user = true;
                }
            }
            return _user;
        }

        public bool completeToDo(string id, string connstr)
        {
            bool _user = false;
            string sql = $@"update sys_todolist set endtime='{DateTime.Now.ToString()}',progress=100 where id='{id}'";
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(DBType.mysql, connstr))
            {
                var obj = conn.Execute(sql);
                if (obj >= 1)
                {
                    _user = true;
                }
            }
            return _user;
        }

        public bool CreateEntity(SYS_TODOLIST entity, string connectionString = null)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEntityById(int id, string connectionString = null)
        {
            throw new NotImplementedException();
        }

        public bool editProgress(string id, int progress, string connstr)
        {
            bool _user = false;
            var end =progress==100?$",endtime='{DateTime.Now.ToString()}'": ",endtime=''";
            string sql = $@"update sys_todolist set progress='{progress}' {end} where id='{id}'";
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(DBType.mysql, connstr))
            {
                var obj = conn.Execute(sql);
                if (obj >= 1)
                {
                    _user = true;
                }
            }
            return _user;
        }

        public List<SYS_PRIORITY> getPriority(string connstr)
        {
            List<SYS_PRIORITY> _user = null;
            string sql = $"SELECT * from sys_priority";
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(DBType.mysql, connstr))
            {
                var obj = conn.Query<SYS_PRIORITY>(sql).AsList();
                if (obj != null && obj.Count >= 1)
                {
                    return obj;
                }
            }
            return _user;
        }

        public List<ToDoModel> getToDo(string uid,string connstr)
        {
            List<ToDoModel> _user = null;
            string sql = $@"SELECT t.id ID,t.title TITLE,t.content CONTENT,t.endtime ENDTIME,t.createtime CREATETIME,
t.progress PROGRESS, p.color PRIORITYCOLOR, u.username USERNAME from sys_todolist t
  INNER JOIN sys_priority p on t.priority = p.id
INNER JOIN sys_user u on t.uid = u.id where progress<100";
            if (!string.IsNullOrEmpty(uid))
            {
                sql += $" and t.uid = '{uid}'";
            }
            sql += " ORDER BY priority desc,progress asc";
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(DBType.mysql, connstr))
            {
                var obj = conn.Query<ToDoModel>(sql).AsList();
                if (obj != null && obj.Count >= 1)
                {
                    return obj;
                }
            }
            return _user;
        }

        public IEnumerable<SYS_TODOLIST> RetriveAllEntity(string connectionString = null)
        {
            throw new NotImplementedException();
        }

        public SYS_TODOLIST RetriveOneEntityById(int id, string connectionString = null)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(SYS_TODOLIST entity, string connectionString = null)
        {
            throw new NotImplementedException();
        }
    }
}
