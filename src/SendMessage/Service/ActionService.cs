using FSLib.Network.Http;
using SendMessage.Common;
using SendMessage.Common.Extension;
using SendMessage.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SendMessage.Service
{
    /// <summary>
    /// 发送信息 关注等操作服务
    /// </summary>
    class ActionService : ServiceBase
    {
        //每分钟发送一次请求
        //https://www.mmbang.com/user_news.php?user_id=17126538&not_record=1&timestamp=2017722123


        public ActionService(ServiceContext context) : base(context)
        {
        }

        /// <summary>
        /// 执行私信、关注、取关操作的前缀操作
        /// </summary>
        /// <param name="startId"></param>
        /// <returns></returns>
        async Task ClickStart(string startId)
        {
            var ctx = NetClient.Create<WebResponseResult>(HttpMethod.Get,
                ApiList.ClickStart.FormatWith(startId, DateTime.Now.ToJsTicks()));

            await ctx.SendAsync();
        }

        /// <summary>
        /// 验证是否可以发私信
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public async Task<WebResponseResult> CheckCanSend(UserInfo userInfo)
        {
            var ctx = NetClient.Create<WebResponseResult>(HttpMethod.Get, ApiList.CheckCanSend,
                ApiList.UserHomePage.FormatWith(userInfo.UserId.ToString()));

            await ctx.SendAsync();
            if (!ctx.IsValid())
            {
                throw ctx.Exception ?? new Exception("未能提交请求CheckCanSend");
            }
            return ctx.Result;
        }

        /// <summary>
        /// 发送私信
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<WebResponseResult> SendMessage(UserInfo userInfo, string msg)
        {
            try
            {
                await ClickStart(userInfo.StartClickId);
                var checkCanSendResult = await CheckCanSend(userInfo);
                if (!checkCanSendResult.success)
                {
                    return checkCanSendResult;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            var requestData = new
            {
                user_id = userInfo.UserId.ToString(),
                user_name = Uri.EscapeDataString(userInfo.NickName),
                content = msg
            };
            //如果有验证码 verify_code:yppb5p


            var ctx = NetClient.Create<WebResponseResult>(HttpMethod.Post, ApiList.SendMessage,
                               ApiList.UserHomePage.FormatWith(userInfo.UserId.ToString()),
                               requestData,contentType:ContentType.FormUrlEncoded); 
            ctx.Request.Headers.Set("X-Requested-With", "XMLHttpRequest");
           await ctx.SendAsync();
            if (!ctx.IsValid())
            {
                throw ctx.Exception ?? new Exception("未能提交请求SendMessage");
            }
            return ctx.Result;
        }

    }
}
