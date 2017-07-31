﻿using System;
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
        /// 响应的错误信息
        /// </summary>
        public string msg { get; private set; }

        /// <summary>
        /// api类型
        /// </summary>
        public string type { get; private set; }

        /// <summary>
        /// 获得响应的错误信息
        /// </summary>
        /// <returns></returns>
        public string GetErrorMessage()
        {
            return msg == null || msg.Length == 0 ? "" : msg.JoinAsString("; ");
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
        /// 响应的错误信息
        /// </summary>
        public string msg { get; private set; }

        /// <summary>
        /// api类型
        /// </summary>
        public string type { get; private set; }

        /// <summary>
        /// 获得响应的错误信息
        /// </summary>
        /// <returns></returns>
        public string GetErrorMessage()
        {
            return msg == null || msg.Length == 0 ? "" : msg.JoinAsString("; ");
        }
    }
}
