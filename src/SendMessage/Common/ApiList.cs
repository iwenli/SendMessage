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

        /// <summary>
        /// 妈妈帮地雷，接口调用之前先调用这个，参数1是clickStatID,参数2是时间戳（毫秒）
        /// </summary>
        public static string ClickStart = @"https://www.mmbang.com/click_stat.php?id={0}&_={1}";
        
        /// <summary>
        /// 验证能否发送私信
        /// </summary>
        public static string CheckCanSend = @"https://www.mmbang.com/message.php?act=checkCanSend";

        /// <summary>
        /// 发送私信
        /// </summary>
        public static string SendMessage = @"https://www.mmbang.com/message.php?act=send";
    }
}
