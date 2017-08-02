using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMessage.Service.Entities
{
    /// <summary>
    /// 用户信息
    /// </summary>
    class UserInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId { set; get; }
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadPic { set; get; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { set; get; }
        /// <summary>
        /// 所在地
        /// </summary>
        public string Location { set; get; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime? RegDate { set; get; }
        /// <summary>
        /// 当前等级
        /// </summary>
        public int? Level { set; get; }
        /// <summary>
        /// 幸福豆数量
        /// </summary>
        public double? BeansNumber { set; get; }
        /// <summary>
        /// 宝宝
        /// </summary>
        public List<BabyInfo> Babys { set; get; }
        /// <summary>
        /// 动态
        /// </summary>
        public List<ParticipatorInfo> Participators { set; get; }
        /// <summary>
        /// 初始点击ID  私信用  关注+1  取关+2
        /// </summary>
        public string StartClickId { set; get; }

        public UserInfo()
        {
            Babys = new List<BabyInfo>();
        }

        public override string ToString()
        {
            //A辉辉妈妈 发私信 关注
            //来自: 浙江 嘉兴
            //注册: 2016 - 01 - 13 18:18
            //幸福豆子0颗 用户等级:Lv.2
            StringBuilder userSb = new StringBuilder();
            userSb.AppendFormat("用户：{0}({1}){2}", NickName, UserId, Environment.NewLine);
            userSb.AppendFormat("来自：{0}{1}", Location, Environment.NewLine);
            userSb.AppendFormat("注册时间：{0}{1}", RegDate, Environment.NewLine);
            userSb.AppendFormat("幸福豆子{0}颗 用户等级:Lv.{1}{2}", BeansNumber ?? 0, Level ?? 0, Environment.NewLine);
            return userSb.ToString();
        }
    }

    /// <summary>
    /// 宝宝信息
    /// </summary>
    class BabyInfo
    {
        /// <summary>
        /// 是否出生
        /// </summary>
        public bool IsBorn
        {
            get
            {
                return DateTime.Now > BirthDate;
            }
        }
        /// <summary>
        /// 如果出生则为生日，未出生则为预产期
        /// </summary>
        public DateTime BirthDate { set; get; }

        public override string ToString()
        {
            TimeSpan span = IsBorn ? DateTime.Now.Subtract(BirthDate)
                : BirthDate.Subtract(DateTime.Now);
            return IsBorn ? "宝宝已经{0}岁{1}天了[生日：{2}]".FormatWith(span.TotalDays / 365, span.TotalDays % 365, BirthDate.ToString("yyyy-MM-dd")) :
                "宝宝还有{0}天就出生了[预产期：{1}]".FormatWith(span.TotalDays, BirthDate.ToString("yyyy-MM-dd"));
        }
    }

    /// <summary>
    /// 动态信息
    /// </summary>
    class ParticipatorInfo
    {
        /// <summary>
        /// 动态内容
        /// </summary>
        public string Value { set; get; }
        /// <summary>
        /// 参加的帮派URL
        /// </summary>
        public string FromUrl { set; get; }
        /// <summary>
        /// 参与的话题URL
        /// </summary>
        public string InUrl { set; get; }
    }
}
