using FSLib.Network.Http;
using SendMessage.Common;
using SendMessage.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendMessage.UI
{
    partial class Login : FormBase
    {
        public Login(ServiceContext context) : base(context)
        {
            InitializeComponent();
            this.Load += Login_Load;
        }

        void Login_Load(object sender, EventArgs e)
        {
            if (_context.Session.NetClient.CookieContainer.Count == 0)
            {
                var cookie = @"referer=https%3A%2F%2Fwww.mmbang.com%2F; UM_distinctid=15d9e8e84b95d-08aa4e3dce3e3f-8383667-1fa400-15d9e8e84bafb; sid=3270616094; skey=65940503; last_vt=1501603723; Hm_lvt_680ac5fedca30f7b2a9190575593f2eb=1501600631; Hm_lpvt_680ac5fedca30f7b2a9190575593f2eb=1501604704; CNZZDATA30062626=cnzz_eid%3D386834952-1501602482-https%253A%252F%252Fwww.mmbang.com%252F%26ntime%3D1501602482; PHPSESSID=656guj4polknpigniuu5603vj7";
                _context.Session.NetClient.ImportCookies(cookie, new Uri(ApiList.Host));
            }
            this.Text = "登录到妈妈帮";
            btnOK.Click += btnOk_Click;
        }
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnOk_Click(object sender, EventArgs e)
        {
            var username = txtUserName.Text;
            var password = txtPassword.Text;

            if (username.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                IM("输入用户名和密码哦！");
                return;
            }
            var vcdlg = new RequireVcDlg(_context);
            if (vcdlg.ShowDialog(this) != DialogResult.OK)
                return;

            var result = await _context.Session.LoginAsync(username, password, vcdlg.VerifyCode);
            if (result == null)
            {
                Close();
                return;
            }
            EM("登录失败：" + result.Message);
        }
    }
}
