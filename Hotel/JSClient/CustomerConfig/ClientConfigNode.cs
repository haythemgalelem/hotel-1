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
    /// 作用：用户配置,配置文件节点
    /// 作者：phq
    /// 日期：2011-11-03
    /// 说明：
    /// </summary>
    public class ClientConfigNode : ConfigBase
    {
        private string _Key;
        private string _Value;

        /// <summary>
        /// 关键字
        /// </summary>
        [XmlAttribute("Key"), DisplayName("关键字"), Category("1.一般信息"), Description("")]
        public string Key
        {
            set { _Key = value; }
            get { return _Key; }
        }

        /// <summary>
        /// 值
        /// </summary>
        [XmlAttribute("Value"), DisplayName("值"), Category("1.一般信息"), Description("")]
        public string Value
        {
            set { _Value = value; }
            get { return _Value; }
        }
    }
}
