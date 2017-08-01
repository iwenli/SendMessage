﻿using ControlExs;
using SendMessage.Common;
using SendMessage.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SendMessage.Common.Extension;

namespace SendMessage.UI
{
    /// <summary>
    /// 抽象窗口基类
    /// </summary>
    partial class FormBase : Form
    {
        /// <summary>
        /// 获得当前的上下文
        /// </summary>
        public ServiceContext _context;

        public FormBase(ServiceContext serviceContext) : this()
        {
            _context = serviceContext;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public FormBase()
        {
            InitializeComponent();
        }


        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormBase
            // 
            this.ClientSize = new System.Drawing.Size(574, 360);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBase";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.Text = ConstParams.APP_NAME + "V{0} PowerBy:{1}".FormatWith(ConstParams.Version, ConstParams.APP_AUTHOR);
        }

        #region 内部函数
        /// <summary>
        /// 追加警告
        /// </summary>
        /// <param name="txtLog"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        protected void AppendLogWarning(RichTextBox txtLog, string message, params object[] args)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action(() =>
                {
                    AppendLog(txtLog, Color.Violet, message, args);
                }));
                return;
            }
            AppendLog(txtLog, Color.Violet, message, args);
        }
        /// <summary>
        /// 追加错误信息
        /// </summary>
        /// <param name="txtLog"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        protected void AppendLogError(RichTextBox txtLog, string message, params object[] args)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action(() =>
                {
                    AppendLog(txtLog, Color.Red, message, args);
                }));
                return;
            }
            AppendLog(txtLog, Color.Red, message, args);
        }
        /// <summary>
        /// 添加日志 定义颜色
        /// </summary>
        /// <param name="txtLog"></param>
        /// <param name="fontColor"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void AppendLog(RichTextBox txtLog, Color fontColor, string message, params object[] args)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action(() =>
                {
                    AppendLog(txtLog, fontColor, message, args);
                }));
                return;
            }
            txtLog.SelectionColor = fontColor;
            AppendLog(txtLog, message, args);
        }
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        protected void AppendLog(RichTextBox txtLog, string message, params object[] args)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action(() =>
                {
                    AppendLog(txtLog, message, args);
                }));
                return;
            }
            string timeL = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txtLog.AppendText(timeL + " => ");
            if (args == null || args.Length == 0)
            {
                txtLog.AppendText(message);
            }
            else
            {
                txtLog.AppendText(string.Format(message, args));
            }
            txtLog.AppendText(Environment.NewLine);
            txtLog.ScrollToCaret();
        }

        /// <summary>
        /// 显示提示
        /// </summary>
        /// <param name="msg">提示内容</param>
        protected void SM(string msg)
        {
            MessageBox.Show(msg, ConstParams.APP_NAME);
        }
        /// <summary>
        /// 显示错误内容
        /// </summary>
        /// <param name="msg">错误内容</param>
        protected void EM(string msg)
        {
            MessageBox.Show(msg, ConstParams.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// 显示信息提示
        /// </summary>
        /// <param name="msg">错误内容</param>
        protected void IM(string msg)
        {
            MessageBox.Show(msg, ConstParams.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 显示提示，带ye和no提示的
        /// </summary>
        /// <param name="msg">错误内容</param>
        protected DialogResult SMYN(string msg)
        {
            return MessageBox.Show(msg, ConstParams.APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }

        #endregion

       
    }
}
