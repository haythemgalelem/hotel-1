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
    /// 模块号：权限控制 QX001
    /// 作用：窗体权限
    /// 1.包含窗体权限列表
    /// 2.窗体权限列表的操作
    /// 作者：phq
    /// 日期：2011-11-03
    /// 说明：
    /// </summary>
    public class ControlsAuthority
    {

        private List<LimitsOfAuth> _ControlAuthorityList = new List<LimitsOfAuth>();

        /// <summary>
        /// 用户的权限列表(针对当前控件)
        /// </summary>
        public List<LimitsOfAuth> ControlAuthorityList
        {
            get { return _ControlAuthorityList; }
            set { _ControlAuthorityList = value; }
        }

        private bool _HasBaseOperatorLimits = false;
        /// <summary>
        /// 是否含有基本操作权限
        /// </summary>
        public bool HasBaseOperatorLimits
        {
            get 
            {
                for (int i = 0; i < ControlAuthorityList.Count; i++)
                {
                    if (ControlAuthorityList[i].FID.IndexOf("BO") >= 0)
                    {
                        return true;
                    }
                }
                return _HasBaseOperatorLimits; 
            }
        }


        private bool _HasAddLimits = false;
        /// <summary>
        /// 是否含有增加的权限
        /// </summary>
        public bool HasAddLimits
        {
            get
            {
                for (int i = 0; i < ControlAuthorityList.Count; i++)
                {
                    if (ControlAuthorityList[i].FID.IndexOf("ZJ") >= 0)
                    {
                        return true;
                    }
                }
                return _HasAddLimits;
            }
        }

        private bool _HasModifyLimits = false;
        /// <summary>
        /// 是否含有修改的权限
        /// </summary>
        public bool HasModifyLimits
        {
            get
            {
                for (int i = 0; i < ControlAuthorityList.Count; i++)
                {
                    if (ControlAuthorityList[i].FID.IndexOf("XG") >= 0)
                    {
                        return true;
                    }
                }
                return _HasModifyLimits;
            }
        }




        private bool _HasCheckLimits = false;
        /// <summary>
        /// 是否含有审核权限
        /// </summary>
        public bool HasCheckLimits
        {
            get
            {
                for (int i = 0; i < ControlAuthorityList.Count; i++)
                {
                    if (ControlAuthorityList[i].FID.IndexOf("SH") >= 0)
                    {
                        return true;
                    }
                }
                return _HasCheckLimits;
            }
        }


        private bool _HasBalanceLimits = false;
        /// <summary>
        /// 是否含有结算权限
        /// </summary>
        public bool HasBalanceLimits
        {
            get 
            {
                for (int i = 0; i < ControlAuthorityList.Count; i++)
                {
                    if (ControlAuthorityList[i].FID.IndexOf("JS") >= 0)
                    {
                        return true;
                    }
                }
                return _HasBalanceLimits;
            }
        }


        private bool _HasSearchLimits = false;
        /// <summary>
        /// 是否含有查询权限
        /// </summary>
        public bool HasSearchLimits
        {
            get
            {
                for (int i = 0; i < ControlAuthorityList.Count; i++)
                {
                    if (ControlAuthorityList[i].FID.IndexOf("CX") >= 0)
                    {
                        return true;
                    }
                } 
                return _HasSearchLimits;
            }
        }

          private bool _HasDeleteLimits = false;
        /// <summary>
        /// 是否含有删除权限
        /// </summary>
        public bool HasDeleteLimits
        {
            get
            {
                for (int i = 0; i < ControlAuthorityList.Count; i++)
                {
                    if (ControlAuthorityList[i].FID.IndexOf("SC") >= 0)
                    {
                        return true;
                    }
                }
                return _HasDeleteLimits;
            }
        }

        /// <summary>
        /// 是否含有导入权限
        /// </summary>
        public bool HasImportLimits
        {
            get
            {
                for (int i = 0; i < ControlAuthorityList.Count; i++)
                {
                    if (ControlAuthorityList[i].FID.IndexOf("DR") >= 0)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// 是否含有调动权限
        /// </summary>
        public bool HasTransferLimits
        {
            get
            {
                for (int i = 0; i < ControlAuthorityList.Count; i++)
                {
                    if (ControlAuthorityList[i].FID.IndexOf("DD") >= 0)//diaodon dd
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// 是否含有交单权限
        /// </summary>
        public bool HasSubmitBillLimits
        {
            get
            {
                for (int i = 0; i < ControlAuthorityList.Count; i++)
                {
                    if (ControlAuthorityList[i].FID.IndexOf("JD") >= 0) 
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// 是否含有交款权限
        /// </summary>
        public bool HasSubmitMoneyLimits
        {
            get
            {
                for (int i = 0; i < ControlAuthorityList.Count; i++)
                {
                    if (ControlAuthorityList[i].FID.IndexOf("JK") >= 0)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// 初始化权限列表
        /// </summary>
        /// <param name="ControlID">权限ID</param>
        public void InitAuthorityList(string ControlID)
        {
            this.ControlAuthorityList = new ControlsAuthorityOperater().GetAuthorityListByControlID(ControlID);
        }
    
    }
}
