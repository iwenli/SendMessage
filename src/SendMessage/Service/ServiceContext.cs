using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMessage.Service
{
    /// <summary>
    /// 服务状态上下文
    /// </summary>
    class ServiceContext
    {
        public ServiceContext()
        {
            Session = new Session();
            VerifyCodeService = new VerifyCodeService(this);
            UserService = new UserService(this);
        }

        /// <summary>
        /// 获得当前的会话状态
        /// </summary>
        public Session Session { get; private set; }
        /// <summary>
        /// 获得当前的验证码服务
        /// </summary>
        public VerifyCodeService VerifyCodeService { get; private set; }
        /// <summary>
        /// 获得用户信息的服务
        /// </summary>
        public UserService UserService { get; private set; }
    }
}

