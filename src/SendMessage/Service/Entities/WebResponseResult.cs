using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMessage.Service.Entities
{
    /// <summary>
    /// 服务器数据响应基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class WebResponseResult<T>
    {
        /// <summary>
        /// 状态
        /// </summary>
        public bool success { get; private set; }

        /// <summary>
        /// 数据
        /// </summary>
        public T[] Data { get; private set; }

        /// <summary>
        /// 响应的信息,发送私信成功返回发送的信息条数
        /// </summary>
        public string message { get; private set; }

        /// <summary>
        /// 获得响应的错误信息
        /// </summary>
        /// <returns></returns>
        public string GetErrorMessage()
        {
            return message == null || message.Length == 0 ? "" : message.JoinAsString("; ");
        }
    }

    /// <summary>
    /// 服务器数据响应基类
    /// </summary>
    class WebResponseResult
    {
        /// <summary>
        /// 状态
        /// </summary>
        public bool success { get; private set; }

        /// <summary>
        /// 响应的信息,发送私信成功返回发送的信息条数
        /// </summary>
        public string message { get; private set; }
        /// <summary>
        /// 大于1表示验证码错误次数（标志着请求需要获取验证码）
        /// </summary>
        public int verify_code_error { get; private set; }
        /// <summary>
        /// 获得响应的错误信息
        /// </summary>
        /// <returns></returns>
        public string GetErrorMessage()
        {
            return message == null || message.Length == 0 ? "" : message.JoinAsString("; ");
        }
    }
}
