using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Net;
using Common;

namespace Client.CommonForms
{
    ///<summary> 
    ///模块编号： 
    ///作用：下载附件
    ///作者：phq
    ///编写日期：2012-03-19
    ///</summary> 
    public partial class FormDownloadAttach : FormBase
    {
        #region 初始化
        public FormDownloadAttach()
        {
            InitializeComponent();
            InitEvent();
        }
        /// <summary>
        /// 初始化事件
        /// </summary>
        private void InitEvent()
        {
            client = new WebClient();
            //下载进度变化
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            //下载完成
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_downloadFileCompleted);
            //窗体加载
            this.Load += new System.EventHandler(this.FormDownloadPicture_Load);
            //取消
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            //窗体关闭，释放资源
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDownloadPicture_FormClosed);
        }

        #endregion

        #region 属性
        private WebClient client = null;
        /// <summary>
        /// 附件名称（包括扩展名）
        /// </summary>
        public string attachName = "";
        /// <summary>
        /// 待下载附件的网址
        /// </summary>
        public string attachDownloadURL = "";
        private string downLoadedPath = "";
        private bool isDirectOpen = false;//是否直接打开

        #endregion
        #region 方法
        #endregion

        #region 事件

        /// <summary>
        /// 下载进度变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                this.prog_Bar.EditValue = e.ProgressPercentage;
                Application.DoEvents();
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }

        }
        /// <summary>
        /// 数据下载完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void client_downloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                //下载downloadDataAsync传递过来的用户定义对象
                byte[] dataByte = (byte[])e.UserState;
                //AsyncCompletedEventArgs.Error属性,获取一个值，该值指示异步操作期间发生的错误
                if (e.Error == null)
                {
                    if (this.isDirectOpen)//直接打开
                    {
                        try//尝试打开
                        {
                            System.Diagnostics.Process.Start(this.downLoadedPath);
                        }
                        catch
                        {
                            Program.MsgBoxInfo("无法自动打开，请尝试下载后，手动打开！");
                        }
                        finally
                        {
                            this.Close();
                        }
                    }
                    else if (Program.MsgBoxYesNo("下载完成！立即打开吗？") == DialogResult.Yes)
                    {
                        try//尝试打开
                        {
                            System.Diagnostics.Process.Start(this.downLoadedPath);
                        }
                        catch
                        {
                            Program.MsgBoxInfo("无法自动打开，请尝试手动打开！");
                        }

                    }
                    this.Close();
                }
                else
                {
                    throw e.Error;
                }
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);

            }
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormDownloadPicture_Load(object sender, EventArgs e)
        {
            try
            {   //文件扩展名
                string fileNameExt = this.attachName.Substring(attachName.LastIndexOf(".") + 1);//文件扩展名               
                System.Windows.Forms.DialogResult dialogResult = Program.MsgBoxYesNoCancel("您直接打开文件吗？\r\n是(Yes):直接打开\r\n否(No):下载\r\n取消(Cancel):取消");
                if (dialogResult == DialogResult.Yes)
                {
                    string tempFilePath = Environment.GetEnvironmentVariable("Temp") + "\\JSMS\\";
                    try
                    {
                        if (!System.IO.Directory.Exists(tempFilePath))
                            System.IO.Directory.CreateDirectory(tempFilePath);
                    }
                    catch (Exception ex)
                    {
                        throw new HotelException(string.Format("创建临时文件夹失败!{0}", ex));
                    }
                    this.downLoadedPath = tempFilePath + this.attachName;
                    this.isDirectOpen = true;
                    FilesUtil.DownloadDataAsync(client, this.attachDownloadURL, this.downLoadedPath);
                    
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.saveFileDialog1.Filter = "下载文件(*." + fileNameExt + ")|*." + fileNameExt;
                    this.saveFileDialog1.FileName = this.attachName;
                    if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        this.downLoadedPath = this.saveFileDialog1.FileName;
                        FilesUtil.DownloadDataAsync(client, this.attachDownloadURL, this.saveFileDialog1.FileName);
                    }
                    else
                    {
                        this.Close();
                    }

                }
                else
                {
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);

            }


        }
        /// <summary>
        /// 窗体关闭，释放资源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormDownloadPicture_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.Dispose();

            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);

            }
        }
        #endregion
    }
}