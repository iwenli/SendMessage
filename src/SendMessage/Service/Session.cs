using FSLib.Network.Http;
using SendMessage.Common;
using SendMessage.Network;
using SendMessage.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SendMessage.Service
{
    /// <summary>
    /// 表示当前的登录会话，以及一些必须的状态信息。
    /// </summary>
    class Session
    {
        bool _isLogined;

        public Session()
        {
            NetClient = new NetClient();
        }

        /// <summary>
        /// 获得当前使用的网络对象，每个网络对象都是会话关联的。
        /// </summary>
        public NetClient NetClient { get; private set; }

        LoginInfo _loginInfo;
        /// <summary>
        /// 获得当前的登录信息
        /// </summary>
        public LoginInfo LoginInfo
        {
            get { return _loginInfo; }
            private set { _loginInfo = value; }
        }


        /// <summary>
        /// 获得当前是否已经登录
        /// </summary>
        public bool IsLogined
        {
            get { return _isLogined; }
            private set
            {
                if (_isLogined == value)
                    return;

                _isLogined = value;
                OnIsLoginedChanged();
            }
        }

        /// <summary>
        /// 登录状态发生变化
        /// </summary>
        public event EventHandler IsLoginedChanged;

        /// <summary>
        /// 引发 <see cref="IsLoginedChanged" /> 事件
        /// </summary>
        protected virtual void OnIsLoginedChanged()
        {
            var handler = IsLoginedChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        /// <summary>
        /// 注销登录
        /// </summary>
        public void Logout()
        {
            LoginInfo = null;
            NetClient = new NetClient();
            IsLogined = false;

        }

        /// <summary>
        /// 登录。如果返回异常则说明登录失败
        /// </summary>
        /// <param name="verifyPoints"></param>
        /// <returns></returns>
        public async Task<Exception> LoginAsync(string username, string password, string verifycode)
        {
            IsLogined = false;
            LoginInfo = new LoginInfo()
            {
                UserName = username,
                Password = password
            };
            var loginData = new
            {
                user_email = username,
                password = password,
                verify_code = verifycode,
                remember = 0
            };

            //登录
            var ctx = NetClient.Create<LoginAsyncResult>(HttpMethod.Post, ApiList.Login, ApiList.Host, loginData);
            await ctx.SendAsync();

            if (!ctx.IsValid())
            {
                return ctx.Exception ?? new Exception("未能提交请求");
            }
            if (!ctx.Result.IsSuceess)
            {
                return new Exception(ctx.Result.message);
            }

            //登录好了。等等。。我们好像想拿到显示的中文名？
            //所以多加一个请求吧。
            var realNameCtx = NetClient.Create<string>(HttpMethod.Get, ApiList.Host, ApiList.Host);
            await realNameCtx.SendAsync();
            if (realNameCtx.IsValid())
            {
                _loginInfo.UserId = Convert.ToInt64(new Regex("(?<= var user_id = ).+?(?=;)").Match(realNameCtx.Result).Value);
                LoginInfo.DisplayName = new Regex("(?<=class=\"login-name\">).+?(?=<br />欢迎回到妈妈帮</p>)").Match(realNameCtx.Result).Value;
            }
            //这里失败了我们就随便起个名字，嗯。
            if (LoginInfo.DisplayName.IsNullOrEmpty())
                LoginInfo.DisplayName = "路人甲";

            IsLogined = true;
            return null;
        }
    }
}
