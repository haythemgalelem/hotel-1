using System;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;

namespace BusinessEntity
{
    /// <summary>
    /// 模块：
    /// 作用：该类是 权限 的实体类
    /// 作者：phq
    /// 日期：2011-11-03
    /// 说明：
    /// </summary>
    [Serializable]
    public class LimitsOfAuth : EntityBase
    {
        /// 编号
        private string _FID;
        /// <summary>
        /// 编号,编号
        /// </summary>
        [DisplayName("编号"), Category("1.一般信息"), Description("编号")] 
        public string FID
        {
            get { return _FID; }
            set { _FID = value; }
        }

        //
        /// 权限名称
        private string _AuthorityName;
        /// <summary>
        /// 权限名称,权限名称
        /// </summary>
        [DisplayName("权限名称"), Category("1.一般信息"), Description("权限名称")] 
        public string AuthorityName
        {
            get { return _AuthorityName; }
            set { _AuthorityName = value; }
        }

        //
        /// 父权限
        private string _PID;
        /// <summary>
        /// 父权限,父权限
        /// </summary>
        [DisplayName("父权限"), Category("1.一般信息"), Description("父权限")] 
        public string PID
        {
            get { return _PID; }
            set { _PID = value; }
        }

        //
        /// 备注
        private string _Note;
        /// <summary>
        /// 备注,备注
        /// </summary>
        [DisplayName("备注"), Category("1.一般信息"), Description("备注")] 
        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }

        //
        private string _RoleID;
        /// <summary>
        /// 角色编号
        /// </summary>
        [DisplayName("角色编号"), Category("1.一般信息"), Description("角色编号")] 
        public string RoleID
        {
            get{return this._RoleID;}
            set
            {
                this._RoleID = value;
            }
        }

        //
        private int _IsRoleAuthority;
        /// <summary>
        /// 是否角色权限，仅在客户端使用
        /// </summary>
        public int IsRoleAuthority
        {
            get { return this._IsRoleAuthority; }
            set
            {
                this._IsRoleAuthority = value;
            }
        }
        

    }
}