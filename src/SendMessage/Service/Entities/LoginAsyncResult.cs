using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMessage.Service.Entities
{
    public class LoginAsyncResult
    {
        /// <summary>
        /// 登陆结果确认
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// 登陆提示语
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 获得登录是否成功
        /// </summary>
        public bool IsSuceess { get { return success; } }
    }
}
