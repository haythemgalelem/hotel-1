using System;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Client.CustomerConfig
{
    /// <summary>
    /// 模块号：CC0003(用户配置)
    /// 作用：用户配置客户端应用配置类
    /// 作者：phq
    /// 日期：2011-11-03
    /// 说明：
    /// </summary>
    public class ClientAppConfig : ConfigBase
    {
        private List<ClientConfigNode> _NodeList = new List<ClientConfigNode>();//配置文件列表
        private List<ClientConfigNode> _UsedUserControls = new List<ClientConfigNode>();//曾经使用过的组件列表
        private List<ClientConfigNode> _UsedUserName = new List<ClientConfigNode>();//曾经使用过用户名

        /// <summary>
        /// 配置文件列表
        /// </summary>
        [XmlElement("AppConfigNode"), Browsable(false)]
        public List<ClientConfigNode> NodeList
        {
            get { return _NodeList; }
            set { _NodeList = value; }
        }

        


        /// <summary>
        /// 曾经使用过的组件列表
        /// </summary>
        [XmlElement("UsedUserControl"), Browsable(false)]
        public List<ClientConfigNode> UsedUserControls
        {
            get { return _UsedUserControls; }
            set { _UsedUserControls = value; }
        }

     

        /// <summary>
        /// 曾经使用过的用户名
        /// </summary>
        [XmlElement("UsedUserName"), Browsable(false)]
        public List<ClientConfigNode> UsedUserNames
        {
            get { return _UsedUserName; }
            set { _UsedUserName = value; }
        }



        /// <summary>
        /// 获取配置文件的值
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="attribute">属性名</param>
        /// <returns></returns>
        public string GetKeyValue(string key)
        {
            for (int i = 0; i < NodeList.Count; i++)
            {
                if (NodeList[i].Key == key)
                {
                    return NodeList[i].Value;
                }
            }
            return "";
        }
  
        /// <summary>
        /// 设置配置文件的值
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="attribute">属性名</param>
        /// <returns></returns>
        public void SetKeyValue(string key,string Value)
        {
            bool exit = false;
            for (int i = 0; i < NodeList.Count; i++)
            {
                if (NodeList[i].Key == key)
                {
                    NodeList[i].Value = Value;
                    exit = true;
                    break;
                }
            }
            if (!exit)
            {
                ClientConfigNode node = new ClientConfigNode();
                node.Key = key;
                node.Value = Value;
                NodeList.Add(node);
            }
        }
        /// <summary>
        /// 增加曾经用过的用户控件节点
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="attribute">属性名</param>
        /// <returns></returns>
        public void AddUsedUserControls(string tag, string caption)
        {
            bool exit = false;
            for (int i = 0; i < UsedUserControls.Count; i++)
            {
                if (UsedUserControls[i].Key == tag)
                {
                    UsedUserControls.RemoveAt(i);//删除原先已经访问的组件，便于重新访问排在前面
                    exit = true;
                    break;
                }
            }
            //if (!exit)
            //{
                ClientConfigNode node = new ClientConfigNode();
                node.Key = tag;
                node.Value = caption;
                UsedUserControls.Add(node);
                if (UsedUserControls.Count > 12)
                {
                    UsedUserControls.RemoveAt(0);
                }
            //}
        }

        /// <summary>
        /// 增加使用过的用户名
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public void AddUsedUserName(string userName)
        {
            for (int i = 0; i < UsedUserNames.Count; i++)
            {
                if (UsedUserNames[i].Value == userName)
                {
                    UsedUserNames.RemoveAt(i);
                    break;
                }
            }
            ClientConfigNode node = new ClientConfigNode();
            node.Key = "UserName";
            node.Value = userName;
            UsedUserNames.Add(node);
            if (UsedUserNames.Count > 6)
            {
                UsedUserNames.RemoveAt(0);
            }
        }

        /// <summary>
        /// 删除所有使用过的用户
        /// </summary>
        public void DeleteAllUser()
        {
            this.UsedUserNames.Clear();
        }

    }
}
