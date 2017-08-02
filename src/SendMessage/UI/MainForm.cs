using ControlExs;
using FSLib.Network.Http;
using HtmlAgilityPack;
using SendMessage.Common;
using SendMessage.Common.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendMessage.UI
{
    partial class MainForm : FormBase
    {
        public MainForm()
        {
            InitializeComponent();
            _context = new Service.ServiceContext();
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitToolbar();
            Init();
        }
        #region 状态栏和工具栏事件

        void InitToolbar()
        {
            tsExit.Click += (s, e) => Close();
            tsLogin.Enabled = !(tsLogout.Enabled = _context.Session.IsLogined);
            tsLogin.Click += (s, e) => new Login(_context).ShowDialog(this);
            tsLogout.Click += (s, e) => _context.Session.Logout();

            //捕捉登录状态变化事件，在登录状态发生变化的时候重设登录状态
            _context.Session.IsLoginedChanged += (s, e) =>
            {
                tsLogin.Enabled = !(tsLogout.Enabled = _context.Session.IsLogined);
                tsLogin.Text = _context.Session.IsLogined ? string.Format("已登录为【{0} ({1})】", _context.Session.LoginInfo.DisplayName, _context.Session.LoginInfo.UserName) : "登录(&I)";
            };
        }

        #endregion

        void Init()
        {
            this.btnSearch.Click += async (s, e) =>
            {
                try
                {
                    var info = await _context.UserService.GetUserInfo(txtUid.Text.Trim());
                    AppendLog(txtLog, info.ToString());
                    //var ctx = _context.Session.NetClient.Create<string>(HttpMethod.Get, ApiList.UserHomePage.FormatWith(txtUid.Text.Trim()), "https://www.mmbang.com/bang/1");
                    //await ctx.SendAsync();
                    //if (ctx.IsValid())
                    //{
                    //    var doc = ctx.Result;
                    //    txtLog.Text =  ctx.Result;
                    //}
                }
                catch (Exception ex)
                {
                    AppendLog(txtLog, ex.Message);
                }
            };

            txtMsg.TextChanged += (s, e) => this.btnSend.Enabled = txtMsg.Text.Trim().Length > 4;

            btnSend.Click += async (s, e) =>
            {
                try
                {
                    var info = await _context.UserService.GetUserInfo(txtUid.Text.Trim());
                    var result = await _context.ActionService.SendMessage(info, txtMsg.Text);
                    AppendLog(txtLog, result.success ? "发送成功(" + result.message + ")" : "发送失败：" + result.message);
                }
                catch (Exception ex)
                {
                    AppendLog(txtLog, ex.Message);
                }
            };
        }
    }
}
