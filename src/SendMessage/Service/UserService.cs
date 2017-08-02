using FSLib.Network.Http;
using SendMessage.Common;
using SendMessage.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SendMessage.Service
{
    class UserService : ServiceBase
    {
        public UserService(ServiceContext context) : base(context)
        {
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public async Task<UserInfo> GetUserInfo(string uid)
        {
            UserInfo userInfo  = null;
            try
            {
                userInfo =  await GetMMBangUser(uid);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return userInfo;
        }

        async Task<UserInfo> GetMMBangUser(string uid)
        {
            var ctx =NetClient.Create<string>(HttpMethod.Get, ApiList.UserHomePage.FormatWith(uid));
            await ctx.SendAsync();
            if (!ctx.IsValid())
            {
                throw ctx.Exception;
            }
            if (ctx.Result.IndexOf("用户不存在") > -1) {
                throw new Exception("用户不存在");
            }
            if (uid != new Regex("(?<=<a href='/user/)\\d+?(?=' title='返回个人中心首页')").Match(ctx.Result).Value.Trim()) {
                throw new Exception("识别用户错误");
            }

            UserInfo userInfo = new UserInfo() { UserId = Convert.ToInt64(uid) };
            userInfo.StartClickId = new Regex("(?<=MMBangStat.statClickAction\\(\")\\d+(?=\")").Match(ctx.Result).Value.Trim();
            userInfo.NickName = new Regex("(?<=<div class='big_title text_pink' id='home_title' style='margin-left:12px;'>)[\\s\\S]+?(?=\n<a)")
                .Match(ctx.Result).Value.Trim();
            userInfo.HeadPic = new Regex("(?<=<img src=').+?(?=' style='width:100px; height:100px;' id='user_home_avatar)")
               .Match(ctx.Result).Value.Trim();
            userInfo.Location = new Regex("(?<=来自:)[\\s\\S]+?(?=<br />)").Match(ctx.Result).Value.Trim();
            userInfo.RegDate = Convert.ToDateTime( new Regex("(?<=注册:)[\\s\\S]+?(?=<br />)").Match(ctx.Result).Value.Trim());
            userInfo.BeansNumber = Convert.ToDouble(new Regex("(?<=幸福豆子<span class='score_number' >).+?(?=</span>)")
                .Match(ctx.Result).Value.Trim());
            userInfo.Level = Convert.ToInt32(new Regex("(?<=用户等级:<span class='score_number' >Lv.).+?(?=</span>)")
                .Match(ctx.Result).Value.Trim());
            return userInfo;
        }
    }
}
