using System;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;

namespace Client.CustomerConfig
{

        /// <summary>
        /// 模块号：CC0001(用户配置)
        /// 作用：用户配置基类
        /// 作者：phq
        /// 日期：2011-11-03
        /// 说明：
        /// </summary>
        public class ConfigBase
        {

            /// <summary>
            /// 将对象序列化成XML文件
            /// </summary>
            /// <param name="path">文件路径</param>
            public void Serialize(string p_Path)
            {
                try
                {
                    if (!Directory.Exists(Path.GetDirectoryName(p_Path)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(p_Path));
                    }
                    XmlSerializer xls = new XmlSerializer(this.GetType());
                    FileStream fs = new FileStream(p_Path, FileMode.Create);
                    xls.Serialize(fs, this);
                    fs.Close();
                    fs = null;
                    xls = null;
                }
                catch
                {
                    Exception e = new Exception("ERROR-C00001 无法将对象写入文件");
                    throw e;
                }
            }

            /// <summary>
            /// 将XML文件反序列化成对象
            /// </summary>
            /// <param name="path">文件路径</param>
            /// <returns>返回工程对象</returns>
            public ConfigBase Deserialize(string p_Path)
            {
                try
                {
                    XmlSerializer xls = new XmlSerializer(this.GetType());
                    FileStream fs = new FileStream(p_Path, FileMode.Open);
                    ConfigBase pb = (ConfigBase)xls.Deserialize(fs);
                    fs.Close();
                    fs = null;
                    xls = null;
                    return pb;
                }
                catch
                {
                    Exception e = new Exception("ERROR-C00002 无法从文件中读取对象");
                    throw e;
                }
            }

            /// <summary>
            /// 生成深副本
            /// </summary>
            /// <returns>返回深副本</returns>
            public ConfigBase Copy()
            {
                XmlSerializer xs = new XmlSerializer(this.GetType());
                MemoryStream ms = new MemoryStream();
                xs.Serialize(ms, this);
                ms.Position = 0;
                ConfigBase tep = (ConfigBase)xs.Deserialize(ms);
                return tep;
            }
        }
  }
 
