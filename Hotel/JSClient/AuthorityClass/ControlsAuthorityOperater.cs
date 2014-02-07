using System;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using BusinessEntity;

namespace Client
{
    /// <summary>
    /// 模块号：权限控制 QX002
    /// 作用：窗体权限操作类
    /// 作者：phq
    /// 日期：2011-11-03
    /// 说明：
    /// </summary>
    public class ControlsAuthorityOperater
    {

        private List<LimitsOfAuth> _ControlAuthorityList = new List<LimitsOfAuth>();

        /// <summary>
        /// 根据控件的编码获取控件的权限
        /// </summary>
        /// <param name="ControlID">控件的编码(即控件导航按钮的Tag值)</param>
        /// <returns>当前用户对于该控件可使用的权限列表，如果没任何权限，返回空列表</returns>
        public List<LimitsOfAuth> GetAuthorityListByControlID(string ControlID)
        {
            List<LimitsOfAuth> temp = new List<LimitsOfAuth>();
            //for (int i = 0; i < Program.CurrentEmployee.Authority.Count; i++)
            //{
            //    if (Program.CurrentEmployee.Authority[i].FID.StartsWith(ControlID))
            //    {
            //        temp.Add(Program.CurrentEmployee.Authority[i]);
            //    }
            //}
            return temp;
        }

    }
}
