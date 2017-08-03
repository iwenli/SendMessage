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
        public static string SID = Host + "ms.php?not_record=1";
        /// <summary>
        /// 妈妈帮首页
        /// </summary>
        public static string Host = @"https://www.mmbang.com/";
        /// <summary>
        /// 获取验证码
        /// </summary>
        public static string VerifyCodeImage = Host + "tools/php_verify/verify.php";

        /// <summary>
        /// 登陆
        /// user_email:
        /// password:
        /// verify_code:
        /// remember:0
        /// </summary>
        public static string Login = Host + "login.php?act=login";

        /// <summary>
        /// 用户首页,参数UID 最小699  最大当前注册用户
        /// </summary>
        public static string UserHomePage = Host + "user/{0}";

        /// <summary>
        /// 妈妈帮地雷，接口调用之前先调用这个，参数1是clickStatID,参数2是时间戳（毫秒）
        /// </summary>
        public static string ClickStart = Host + "click_stat.php?id={0}&_={1}";

        /// <summary>
        /// 验证能否发送私信
        /// </summary>
        public static string CheckCanSend = Host + "message.php?act=checkCanSend";

        /// <summary>
        /// 发送私信
        /// </summary>
        public static string SendMessage = Host + "message.php?act=send";

        /// <summary>
        /// 关注或者取关 参数为userid
        /// </summary>
        public static string Follow = Host + "user/{0}?act=follow";

        /// <summary>
        /// 帮派主页  参数为帮派id
        /// </summary>
        public static string BangHomePage = Host + "bang/{0}";

        /// <summary>
        /// 加入帮派  参数为帮派id
        /// </summary>
        public static string JoinBang = BangHomePage + "?act=join_bang";

        /// <summary>
        /// 发帖  参数为帮派id
        /// </summary>
        public static string SendPosts = BangHomePage + "?act=edit_topic_submit";

        /// <summary>
        /// 发帖来源路径  参数为帮派id
        /// </summary>
        public static string SendPostsReferer = BangHomePage + "?act=edit_topic";

    }
}
