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
        /// <param name="userInfo">用户信息</param>
        /// <param name="msg">私信内容</param>
        /// <param name="vc">验证码</param>
        /// <returns></returns>
        public async Task<WebResponseResult> SendMessage(UserInfo userInfo, string msg, string vc = "")
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
            var requestData = new Parameters();
            requestData.Add("user_id", userInfo.UserId);
            requestData.Add("user_name", userInfo.NickName);
            requestData.Add("content", msg);
            if (!vc.IsNullOrEmpty()) {
                requestData.Add("verify_code", vc);
            }
            //如果有验证码 verify_code:yppb5p


            var ctx = NetClient.Create<WebResponseResult>(HttpMethod.Post, ApiList.SendMessage,
                               ApiList.UserHomePage.FormatWith(userInfo.UserId.ToString()),
                               requestData.BuildQueryString(true), contentType: ContentType.FormUrlEncoded);
            ctx.Request.Headers.Set("X-Requested-With", "XMLHttpRequest");
            await ctx.SendAsync();
            if (!ctx.IsValid())
            {
                throw ctx.Exception ?? new Exception("未能提交请求SendMessage");
            }
            return ctx.Result;
        }

        /// <summary>
        /// 关注|取关
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="isRemove">1表示取关 0表示关注</param>
        /// <returns></returns>
        public async Task<bool> Follow(UserInfo userInfo, int isRemove = 0)
        {
            await ClickStart(userInfo.StartClickId + 1 + isRemove);
            var ctx = NetClient.Create<WebResponseResult>(HttpMethod.Get, ApiList.Follow.FormatWith(userInfo.UserId),
                ApiList.UserHomePage.FormatWith(userInfo.UserId.ToString()));

            await ctx.SendAsync();
            if (!ctx.IsValid())
            {
                throw ctx.Exception ?? new Exception("未能提交请求Follow");
            }
            return ctx.Result.success;
        }

        /// <summary>
        ///  加入帮派
        /// </summary>
        /// <param name="bangId">帮派id</param>
        /// <returns></returns>
        public async Task<bool> JoinBang(long bangId)
        {
            var ctx = NetClient.Create<WebResponseResult>(HttpMethod.Get, ApiList.JoinBang.FormatWith(bangId),
                ApiList.BangHomePage.FormatWith(bangId));

            await ctx.SendAsync();
            if (!ctx.IsValid())
            {
                throw ctx.Exception ?? new Exception("未能提交请求JoinBang");
            }
            return ctx.Result.success;
        }

        /// <summary>
        ///  发帖
        /// </summary>
        /// <param name="bangId">帮派id</param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="vc"></param>
        /// <returns></returns>
        public async Task<PostsInfo> SendPosts(long bangId,string title,string content,string vc="")
        {
            var ctx = NetClient.Create<PostsInfo>(HttpMethod.Get, ApiList.SendPosts.FormatWith(bangId),
                ApiList.SendPosts.FormatWith(bangId));
            /*
                title:第一次发帖，不知道成功了会是什么样的
                content:第一次发帖，不知道成功了会是什么样的
                cat:0
                topic_id:0
                tag:
                verify_code:8bycc
                _T_:8982432,143722964,1501774845
             */
            await ctx.SendAsync();
            if (!ctx.IsValid())
            {
                throw ctx.Exception ?? new Exception("未能提交请求JoinBang");
            }
            return ctx.Result;
        }
    }
}
