using FSLib.Network.Http;
using SendMessage.Common;
using SendMessage.Common.Extension;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMessage.Service
{
    /// <summary>
	/// 验证码服务
	/// </summary>
    class VerifyCodeService : ServiceBase
    {
        public VerifyCodeService(ServiceContext context) : base(context)
        {
        }

        /// <summary>
        /// 加载验证码
        /// </summary>
        /// <param name="type">验证码类型</param>
        /// <returns></returns>
        public async Task<Image> LoadVerifyCodeImage(VerifyCodeType type = VerifyCodeType.Login)
        {
            
            var ctx = Session.NetClient.Create<Image>(HttpMethod.Get,ApiList.VerifyCodeImage);
            await ctx.SendAsync();
            return ctx.Result;
        }

        ///// <summary>
        ///// 校验验证码
        ///// </summary>
        ///// <param name="type">验证码类型</param>
        ///// <param name="points">验证码点位置</param>
        ///// <returns></returns>

        //public async Task<bool> CheckVerifyCode(VerifyCodeType type, params Point[] points)
        //{
        //    var randType = "sjrand";

        //    //为了准确起见，我们使用真正的引用页
        //    var urlRefer = "https://kyfw.12306.cn/otn/login/init";

        //    if (type == VerifyCodeType.SubmitOrder)
        //    {
        //        randType = "randp";
        //        urlRefer = "https://kyfw.12306.cn/otn/confirmPassenger/initDc";
        //    }

        //    var ctx = Session.NetClient.Create<WebResponseResult<VerifyCodeCheckResult>>(
        //                                                                                    HttpMethod.Post,
        //                                                                                "https://kyfw.12306.cn/otn/passcodeNew/checkRandCodeAnsyn",
        //                                                                                urlRefer,
        //                                                                                new
        //                                                                                {
        //                                                                                    randCode = points.Select(s => s.X + "," + s.Y).JoinAsString(","),
        //                                                                                    rand = randType
        //                                                                                }
        //        );

        //    await ctx.SendTask();

        //    return ctx.IsValid() && ctx.Result.Data.Result == 1;
        //}

    }

    /// <summary>
    /// 验证码类型
    /// </summary>
    enum VerifyCodeType
    {
        /// <summary>
        /// 登录验证码
        /// </summary>
        Login = 0,
        /// <summary>
        /// 注册
        /// </summary>
        Register = 1

    }
}
