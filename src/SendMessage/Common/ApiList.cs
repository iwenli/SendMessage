using SendMessage.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMessage.Common
{
    /// <summary>
    /// 创业赚钱接口
    /// </summary>
    class ApiList
    {
        //TODO:暂时未研究透彻COOKIE加载顺序
        /// <summary>
        /// 获取SID 
        /// </summary>
        public static string SID = @"https://www.mmbang.com/ms.php?not_record=1";
        /// <summary>
        /// 妈妈帮首页
        /// </summary>
        public static string Host = @"https://www.mmbang.com/";
        /// <summary>
        /// 获取验证码
        /// </summary>
        public static string VerifyCodeImage = @"https://www.mmbang.com/tools/php_verify/verify.php";

        /// <summary>
        /// 登陆
        /// user_email:
        /// password:
        /// verify_code:
        /// remember:0
        /// </summary>
        public static string Login = @"https://www.mmbang.com/login.php?act=login";

        /// <summary>
        /// 用户首页,参数UID 最小699  最大当前注册用户
        /// </summary>
        public static string UserHomePage = @"https://www.mmbang.com/user/{0}";
    }
}
