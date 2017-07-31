using ControlExs;
using FSLib.Network.Http;
using HtmlAgilityPack;
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

            Init();
        }

        void Init()
        {
           
            


            this.btnSearch.Click +=  (s, e) =>
            {
                string url = @"https://www.mmbang.com/user/{0}";  //最小699  最大当前注册用户
                //var rtx = _context.Session.NetClient.Create<HtmlDocument>(HttpMethod.Get, url.FormatWith(txtUid.Text.Trim()), "https://www.mmbang.com/bang/1");
                //await rtx.SendAsync();
                //if (rtx.IsValid())
                //{
                //    AppendLog(txtLog, rtx.Result.);
                //}
                HtmlWeb htmlWeb = new HtmlWeb();
                var document = htmlWeb.Load(url.FormatWith(txtUid.Text.Trim()));
                AppendLog(txtLog, document.ToString());
            };
        }
    }
}
