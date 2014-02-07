using System;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Client.CustomerConfig
{ /// <summary>
    /// 模块号：CC0004(用户配置)
    /// 作用：用户配置类根节点
    /// 作者：phq
    /// 日期：2011-11-03
    /// 说明：
    /// </summary>
    public class UserConfig : ConfigBase
    {

        private ClientAppConfig _AppConfig = null;
        private SysMessage _SysMessage = null;



        /// <summary>
        /// 客户端应用程序配置
        /// </summary>
        public ClientAppConfig AppConfig
        {
            get { return _AppConfig; }
            set { _AppConfig = value; }
        }

        /// <summary>
        /// 系统消息列表
        /// </summary>
        public SysMessage SysMessage
        {
            get { return _SysMessage; }
            set { _SysMessage = value; }
        }


        /// <summary>
        /// 加载应用程序配置文件
        /// </summary>
        /// <param name="Path"></param>
        public void LoadAppConfig(string path)
        {
            if (File.Exists(path))
            {
                AppConfig = new ClientAppConfig();
                AppConfig = (ClientAppConfig)AppConfig.Deserialize(path);
            }
            else
            {
                AppConfig = new ClientAppConfig();
                AppConfig.Serialize(path);
            }
        }

        /// <summary>
        /// 加载应用程序配置文件
        /// </summary>
        /// <param name="Path"></param>
        public void LoadSysMessage(string path)
        {
            if (File.Exists(path))
            {
                SysMessage = new SysMessage();
                SysMessage = (SysMessage)SysMessage.Deserialize(path);
            }
            else
            {
                SysMessage = new SysMessage();
                SysMessage.Serialize(path);
            }
        }


        /// <summary>
        /// 保存应用程序配置文件
        /// </summary>
        /// <param name="Path"></param>
        public void SaveAppConfig(string path)
        {
            if (AppConfig != null)
            {
                AppConfig.Serialize(path);
            }
            else
            {
                AppConfig = new ClientAppConfig();
                AppConfig.Serialize(path);
            }
        }

        /// <summary>
        /// 保存系统消息列表
        /// </summary>
        /// <param name="Path"></param>
        public void SaveSysMessage(string path)
        {
            if (SysMessage != null)
            {
                SysMessage.Serialize(path);
            }
            else
            {
                SysMessage = new SysMessage();
                SysMessage.Serialize(path);
            }
        }

    }
}
