using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Client.CommonForms;
using DevExpress.XtraEditors;
using DevExpress.Utils.About;
using System.IO;
using System.Drawing;
using System.Configuration; 
using DevExpress.LocalizationCHS; 
using System.Diagnostics;
using BusinessEntity;
using BusinessEntity.Model;

namespace Client
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool flag = false;            
            try
            {
                 System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out flag);//用于判断是否已经有程序实例在运行
                 if (flag)
                 {
                     //=====界面，UI汉化=================
                     System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
                     System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("zh-CN");
                     DevExpress.LocalizationCHS.DevExpressXtraGridLocalizationCHS.CreateDefaultLocalizer();
                     DevExpress.XtraEditors.Controls.Localizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraEditorsLocalizationCHS();
                     DevExpress.XtraGrid.Localization.GridLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraGridLocalizationCHS();
                     //===========皮肤====================
                     //DevExpress.Utils.AppearanceObject.DefaultFont = new Font("宋体", 9);
                     DevExpress.UserSkins.BonusSkins.Register();
                     DevExpress.UserSkins.OfficeSkins.Register();

                     DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.SkinProject).Assembly);
                     DevExpress.Skins.SkinManager.EnableFormSkins();
                     dflook_All = new DevExpress.LookAndFeel.DefaultLookAndFeel();
                     if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "FOSOYO.ini"))
                     {
                         DevExpress.FOSOYO.LookAndFeelSettings.Load("FOSOYO.ini");
                     }
                     else
                     {
                         dflook_All.LookAndFeel.SetSkinStyle("Office 2010 Silver");//默认苹果皮肤风格McSkin/Office 2010 Silver
                     }
                     //加载配置文件
                     try
                     {
                         Program.LoadConfigFile();
                     }
                     catch (Exception ee)
                     {
                         MessageBox.Show("无法加载配置文件！\n错误信息：" + ee);
                     }
                     Form_Progress = new FormProgressing();
                  
                     Application.Run(new ProgramForms.Formlogin());
                     // 释放 System.Threading.Mutex 一次
                     mutex.ReleaseMutex();
                 }
                 else
                 {
                     MsgBoxInfo("程序已经在运行!");
                     Environment.Exit(1);
                 }
            }
            catch (Exception e)
            {
                MessageBox.Show("加载程序集过程中发现错误！\n错误信息：" + e);
            }
        } 

        public static int UPDATE_MINUTE=30;//更新系统时间间隔,分钟
        public static ProgramForms.FormMain m_FormMain = null;
        public static CustomerConfig.UserConfig m_UserConfig = null;
        public static DevExpress.LookAndFeel.DefaultLookAndFeel dflook_All;
        public static FormProgressing Form_Progress = null;
        public static List<DataDictionary> currentDataDicionaryList = new List<DataDictionary>();//当前字典列表
        public static DateTime lastLoadDataDictionaryTime = new DateTime();//最后次加载字典时间
        public static DateTime lastLoadEmployeeTime = new DateTime();//最后次加载员工时间
        public static DateTime lastLoadCompanyTime = new DateTime();//最后次加载企业时间
        public static DateTime lastLoadGroupTime = new DateTime();//最后次加载分组时间
        public static DateTime lastLoadGroupMemberTime = new DateTime();//最后次加载分组成员时间 
        public static Operator currentOperate = null;

        //public static User currentUser = null;
        

        public static string fileServerUrl = "http://27.151.127.13:8888/JSMS";//文件服务器地址
         
        public static bool IsReStart = false;
        private static string msgBoxTitle = "系统提示:";

        #region 方法(公共)
        /// <summary>
        /// 获取配置文件中常量的值(app.config)
        /// </summary>
        /// <param name="txt_ConstName">常量的名称</param>
        public static string GetConst(string txt_ConstName)
        {
            try
            {
                return ConfigurationSettings.AppSettings[txt_ConstName].ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 将bool值转换为string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string BoolToString(bool value)
        {
            if (value)
            {
                return "是";
            }
            else
            {
                return "否";
            }
        }

        /// <summary>
        /// 加载用户配置文件
        /// </summary>
        public static void LoadConfigFile()
        {
            m_UserConfig = new Client.CustomerConfig.UserConfig();

            //加载客户端应用程序配置
            m_UserConfig.LoadAppConfig(Application.StartupPath + GetConst("AppConfigPath"));
            m_UserConfig.LoadSysMessage(Application.StartupPath + GetConst("SysMessagePath"));

        }

        public static void SaveConfig()
        {
            if (m_UserConfig != null)
            {
                m_UserConfig.SaveAppConfig(Application.StartupPath + GetConst("AppConfigPath"));
                m_UserConfig.SysMessage.DeleteOrderMessage();
                m_UserConfig.SaveSysMessage(Application.StartupPath + GetConst("SysMessagePath"));
            }
        }

        #endregion

        #region 方法(提示窗口)
        /// <summary>
        /// 提示框，错误提示信息
        /// </summary>
        /// <param name="message"></param>
        public static void MsgBoxError(Exception e)
        {
            try
            {
                string msg = e.Message + "\n详细信息如下：\n" + e.StackTrace;


                FormMessageBox m_form = new FormMessageBox();
                XtraMessageBoxArgs xe = new XtraMessageBoxArgs(null, msg, msgBoxTitle, new DialogResult[] { DialogResult.OK }, null, 0);
                m_form.ShowMessageBoxDialog(xe);
                RightLog(e);
            }
            catch
            { }
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="e"></param>
        public static void RightLog(Exception e)
        {

            //if (!Directory.Exists(Application.StartupPath + "/ErrLog"))
            //{
            //    Directory.CreateDirectory(Application.StartupPath + "/ErrLog");
            //}
            //FileStream fs = null;
            //if (File.Exists(Application.StartupPath + "/ErrLog/" + DateTime.Now.Date.ToShortDateString() + ".err"))
            //{
            //    fs = File.Open(Application.StartupPath + "/ErrLog/" + DateTime.Now.Date.ToShortDateString() + ".err", FileMode.Append);
            //}
            //else
            //{
            //    fs = File.Open(Application.StartupPath + "/ErrLog/" + DateTime.Now.Date.ToShortDateString() + ".err", FileMode.OpenOrCreate);
            //}
            //StreamWriter sw = new StreamWriter(fs);
            //try
            //{

            //    sw.WriteLine("/********************************");
            //    sw.WriteLine("时间：" + DateTime.Now.ToString());
            //    sw.Write(e.Message);
            //    sw.Flush();
            //}
            //catch
            //{

            //}
            //finally
            //{
            //    sw.Close();
            //    sw = null;
            //    fs.Close();
            //    fs = null;
            //}
        }


       
        /// <summary>
        /// 提示框，错误提示信息
        /// </summary>
        /// <param name="message"></param>
        public static void MsgBoxError(string txt)
        {
            try
            {
                FormMessageBox m_form = new FormMessageBox();
                XtraMessageBoxArgs xe = new XtraMessageBoxArgs(null, txt, msgBoxTitle, new DialogResult[] { DialogResult.OK }, null, 0);
                m_form.ShowMessageBoxDialog(xe);
                RightLog(new Exception(txt));
            }
            catch
            { }
        }

        /// <summary>
        /// 提示框，错误提示信息
        /// </summary>
        /// <param name="txt">提示框显示文本</param>
        /// <param name="caption">提示框名称</param>
        public static void MsgBoxError(string txt, string caption)
        {
            try
            {
                FormMessageBox m_form = new FormMessageBox();
                XtraMessageBoxArgs xe = new XtraMessageBoxArgs(null, txt, caption, new DialogResult[] { DialogResult.OK }, null, 0);
                m_form.ShowMessageBoxDialog(xe);
            }
            catch
            {
            }
        }

        /// <summary>
        /// 提示框，提示信息
        /// </summary>
        /// <param name="txt">提示框显示文本</param>
        public static void MsgBoxInfo(string txt)
        {
            try
            {
                FormMessageBox m_form = new FormMessageBox();
                XtraMessageBoxArgs xe = new XtraMessageBoxArgs(null, txt, msgBoxTitle, new DialogResult[] { DialogResult.OK }, null, 0);
                m_form.ShowMessageBoxDialog(xe);
            }
            catch
            { }
        }

        /// <summary>
        /// 提示框(是Yes，否No，取消Cancel)
        /// </summary>
        /// <param name="txt">提示框显示文本</param>
        public static DialogResult MsgBoxYesNoCancel(string txt)
        {
            try
            {
                FormMessageBox m_form = new FormMessageBox();
                XtraMessageBoxArgs xe = new XtraMessageBoxArgs(null, txt, msgBoxTitle, new DialogResult[] { DialogResult.Yes, DialogResult.No, DialogResult.Cancel }, null, 0);
                return m_form.ShowMessageBoxDialog(xe);

            }
            catch
            {
                return DialogResult.Cancel;
            }
        }

        /// <summary>
        /// 提示框(是Yes,否No)
        /// </summary>
        /// <param name="txt">提示框显示文本</param>
        public static DialogResult MsgBoxYesNo(string txt)
        {
            try
            {
                FormMessageBox m_form = new FormMessageBox();
                XtraMessageBoxArgs xe = new XtraMessageBoxArgs(null, txt, msgBoxTitle, new DialogResult[] { DialogResult.Yes, DialogResult.No }, null, 0);
                return m_form.ShowMessageBoxDialog(xe);
            }
            catch
            {
                return DialogResult.No;
            }
        }

        /// <summary>
        /// 提示框，警告信息
        /// </summary>
        /// <param name="txt">提示框显示文本</param>
        public static void MsgBoxWarn(string txt)
        {
            try
            {
                FormMessageBox m_form = new FormMessageBox();
                XtraMessageBoxArgs xe = new XtraMessageBoxArgs(null, txt, msgBoxTitle, new DialogResult[] { DialogResult.OK }, null, 0);
                m_form.ShowMessageBoxDialog(xe);
            }
            catch
            {

            }
        }

        /// <summary>
        /// 提示框，警告信息
        /// </summary>
        /// <param name="txt">提示框显示文本,没有权限</param>
        public static void MsgBoxHasNoRight()
        {
            try
            {
                FormMessageBox m_form = new FormMessageBox();
                XtraMessageBoxArgs xe = new XtraMessageBoxArgs(null, "您没有该权限，请与系统管理员联系！", msgBoxTitle, new DialogResult[] { DialogResult.OK }, null, 0);
                m_form.ShowMessageBoxDialog(xe);
            }
            catch
            {
            }
        }
        #endregion

    }
}
