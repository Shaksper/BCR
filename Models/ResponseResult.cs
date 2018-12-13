using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    /// <summary>
    /// 响应结果类
    /// </summary>
    public class ResponseResult
    {
        /// <summary>
        /// 状态(0-default, 1-success, -1-error)
        /// </summary>
        public int Status
        {
            get;
            set;
        }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string Message
        {
            get;
            set;
        }

        /// <summary>
        /// 消息额外数据
        /// </summary>
        public object ExtraData
        {
            get;
            set;
        }

        /// <summary>
        /// 响应消息封装类
        /// </summary>
        /// <param name="Status">状态:1-成功；0-缺省; -1失败</param>
        /// <param name="Message">消息内容</param>
        /// <returns></returns>
        public static ResponseResult Default(string message = null)
        {
            var result = new ResponseResult();
            result.Status = 0;
            result.Message = message;

            return result;
        }

        /// <summary>
        /// 响应消息封装类
        /// </summary>
        /// <param name="Status">状态:1-成功；0-缺省; -1失败</param>
        /// <param name="Message">消息内容</param>
        /// <returns></returns>
        public static ResponseResult Success(string message = null)
        {
            var result = new ResponseResult();
            result.Status = 1;
            result.Message = message;
            return result;
        }

        /// <summary>
        /// 响应消息封装类
        /// </summary>
        /// <param name="Status">状态:1-成功；0-缺省; -1失败</param>
        /// <param name="Message">消息内容</param>
        /// <returns></returns>
        public static ResponseResult Error(string errorMessage, int status = -1)
        {
            var result = new ResponseResult();
            result.Status = status;
            result.Message = errorMessage;
            return result;
        }

        public static ResponseResult Deserialize(string message)
        {
            var result = JsonSerializer.DeserializeFromString<ResponseResult>(message);
            return result;
        }
    }

    /// <summary>
    /// 响应消息类(泛型)
    /// </summary>
    public class ResponseResult<T> where T : class
    {
        /// <summary>
        /// 状态
        /// </summary>
        public int Status
        {
            get;
            set;
        }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string Message
        {
            get;
            set;
        }

        /// <summary>
        /// 返回的对象
        /// </summary>
        public T Data
        {
            get;
            set;
        }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages
        {
            get;
            set;
        }

        /// <summary>
        /// 总行数
        /// </summary>
        public int TotalRowsCount
        {
            get;
            set;
        }

        /// <summary>
        /// 响应消息封装类
        /// </summary>
        ///  <param name="Code">状态:1-成功; 0-状态缺省;小于0-失败</param>
        /// <param name="Message">消息内容</param>
        /// <returns></returns>
        public static ResponseResult<T> Default()
        {
            var result = new ResponseResult<T>();
            result.Data = null;
            result.Status = 0;
            result.Message = string.Empty;

            return result;
        }

        /// <summary>
        /// 响应消息封装类
        /// </summary>
        ///  <param name="Code">状态:1-成功; 0-状态缺省;小于0-失败</param>
        /// <param name="Message">消息内容</param>
        /// <returns></returns>
        public static ResponseResult<T> Success(T t, string message = "")
        {
            var result = new ResponseResult<T>();
            result.Data = t;
            result.Status = 1;
            result.Message = message;
            return result;
        }
        /// <summary>
        /// Http 响应消息封装类
        /// </summary>
        /// <param name="Code">状态:1-成功;; 0-状态缺省;小于0-失败</param>
        /// <param name="Message">消息内容</param>
        /// <returns></returns>
        public static ResponseResult<T> Error(string message = "", int status = -1)
        {
            var result = new ResponseResult<T>();
            result.Data = null;
            result.Status = status;
            result.Message = message;

            return result;
        }

        /// <summary>
        /// Http 响应消息反序列化类
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static ResponseResult<T> Deserialize(string message)
        {
            var response = JsonSerializer.DeserializeFromString<ResponseResult<T>>(message);
            return response;
        }
    }
    /// <summary>
    /// 响应消息类(泛型，附带额外数据返回)
    /// </summary>
    public class ResponseResult<T, ExtraT> where T : class where ExtraT : class
    {
        /// <summary>
        /// 状态
        /// </summary>
        public int Status
        {
            get;
            set;
        }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string Message
        {
            get;
            set;
        }
        /// <summary>
        /// 额外的数据
        /// </summary>
        public ExtraT ExtraData
        {
            get;
            set;
        }

        /// <summary>
        /// 实体数据
        /// </summary>
        public T Data
        {
            get;
            set;
        }
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages
        {
            get;
            set;
        }

        /// <summary>
        /// 总行数
        /// </summary>
        public int TotalRowsCount
        {
            get;
            set;
        }

        /// <summary>
        /// 响应消息封装类
        /// </summary>
        ///  <param name="Code">状态:1-成功; 0-状态缺省;小于0-失败</param>
        /// <param name="Message">消息内容</param>
        /// <returns></returns>
        public static ResponseResult<T, ExtraT> Default()
        {
            var result = new ResponseResult<T, ExtraT>();
            result.ExtraData = null;
            result.Data = null;
            result.Status = -1;
            result.Message = string.Empty;
            return result;
        }
        /// <summary>
        /// 响应消息封装类
        /// </summary>
        ///  <param name="Code">状态:1-成功; 0-状态缺省;小于0-失败</param>
        /// <param name="Message">消息内容</param>
        /// <returns></returns>
        public static ResponseResult<T, ExtraT> Success(T t, ExtraT extraT, string message = "")
        {
            var result = new ResponseResult<T, ExtraT>();
            result.ExtraData = extraT;
            result.Data = t;
            result.Status = 1;
            result.Message = message;
            return result;
        }
        /// <summary>
        /// Http 响应消息封装类
        /// </summary>
        /// <param name="Code">状态:1-成功; 0-状态缺省;小于0-失败</param>
        /// <param name="Message">消息内容</param>
        /// <returns></returns>
        public static ResponseResult<T, ExtraT> Error(string message = "", int Status = -1)
        {
            var result = new ResponseResult<T, ExtraT>();
            result.ExtraData = null;
            result.Data = null;
            result.Status = Status;
            result.Message = message;

            return result;
        }

        /// <summary>
        /// Http 响应消息反序列化类
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static ResponseResult<T, ExtraT> Deserialize(string message)
        {
            var response = JsonSerializer.DeserializeFromString<ResponseResult<T, ExtraT>>(message);
            return response;
        }
    }
}
