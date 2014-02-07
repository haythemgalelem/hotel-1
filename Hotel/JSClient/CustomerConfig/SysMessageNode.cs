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
    /// 模块号：CC0002(用户配置)
    /// 作用：系统消息，记录系统消息节点
    /// 作者：phq
    /// 日期：2011-11-03
    /// 说明：
    /// </summary>
    public class SysMessageNode : ConfigBase
    {
        private int _Key;
        private string _Content;
        private string _NoticePeople;
        private DateTime _ValidDate;

        /// <summary>
        /// 有效日期
        /// </summary>
        public DateTime ValidDate
        {
            get { return _ValidDate; }
            set { _ValidDate = value; }
        }

        /// <summary>
        /// 发布人
        /// </summary>
        public string NoticePeople
        {
            get { return _NoticePeople; }
            set { _NoticePeople = value; }
        }
        private DateTime _NoticeTime;

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime NoticeTime
        {
            get { return _NoticeTime; }
            set { _NoticeTime = value; }
        }

        /// <summary>
        /// 关键字
        /// </summary>
        [XmlAttribute("Key"), DisplayName("关键字"), Category("1.一般信息"), Description("")]
        public int Key
        {
            set { _Key = value; }
            get { return _Key; }
        }

        /// <summary>
        /// 值
        /// </summary>
        [XmlAttribute("Content"), DisplayName("值"), Category("1.一般信息"), Description("")]
        public string Content
        {
            set { _Content = value; }
            get { return _Content; }
        }
    }
}
