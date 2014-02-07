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
    /// 作用：系统消息保存
    /// 作者：phq
    /// 日期：2011-11-03
    /// 说明：
    /// </summary>
    public class SysMessage : ConfigBase
    {
        private List<SysMessageNode> _NodeList = new List<SysMessageNode>();//配置文件列表

        /// <summary>
        /// 系统消息列表
        /// </summary>
        [XmlElement("SysMessageNode"), Browsable(false)]
        public List<SysMessageNode> NodeList
        {
            get { return _NodeList; }
            set { _NodeList = value; }
        }

        /// <summary>
        /// 获取最大ID
        /// </summary>
        /// <returns>最大ID</returns>
        public int getMaxID()
        {
            int id = 0;
            for (int i = 0; i < this._NodeList.Count; i++)
            {
                if (_NodeList[i].Key > id)
                {
                    id = _NodeList[i].Key;
                }
            }
            return id;
        }

        /// <summary>
        /// 删除过期的数据
        /// </summary>
        public void DeleteOrderMessage()
        {
            for (int i = 0; i < this.NodeList.Count; i++)
            {
                //hrj20110203删除
                //if (this.NodeList[i].ValidDate<=DateTime.Now)
                //{
                    NodeList.RemoveAt(i);
                    i--;
                //}
            }
        }

        /// <summary>
        /// 增加一个新的消息记录到消息记录系统中
        /// </summary>
        /// <param name="msg">消息记录对象</param>
        //public void AddNewMessage(Messages msg)
        //{
        //    SysMessageNode smd = new SysMessageNode();
        //    smd.Content = msg.Message;
        //    smd.Key = msg.MessageNO;
        //    smd.NoticePeople = msg.Publisher;
        //    smd.NoticeTime = msg.PublisheTime;
        //    smd.ValidDate = msg.ValidDate;
        //    this.NodeList.Insert(0,smd);
        //}
    }
}
