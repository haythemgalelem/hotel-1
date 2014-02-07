using System;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;

namespace BusinessEntity
{
    /// <summary>
    /// ģ�飺
    /// ���ã������� Ȩ�� ��ʵ����
    /// ���ߣ�phq
    /// ���ڣ�2011-11-03
    /// ˵����
    /// </summary>
    [Serializable]
    public class LimitsOfAuth : EntityBase
    {
        /// ���
        private string _FID;
        /// <summary>
        /// ���,���
        /// </summary>
        [DisplayName("���"), Category("1.һ����Ϣ"), Description("���")] 
        public string FID
        {
            get { return _FID; }
            set { _FID = value; }
        }

        //
        /// Ȩ������
        private string _AuthorityName;
        /// <summary>
        /// Ȩ������,Ȩ������
        /// </summary>
        [DisplayName("Ȩ������"), Category("1.һ����Ϣ"), Description("Ȩ������")] 
        public string AuthorityName
        {
            get { return _AuthorityName; }
            set { _AuthorityName = value; }
        }

        //
        /// ��Ȩ��
        private string _PID;
        /// <summary>
        /// ��Ȩ��,��Ȩ��
        /// </summary>
        [DisplayName("��Ȩ��"), Category("1.һ����Ϣ"), Description("��Ȩ��")] 
        public string PID
        {
            get { return _PID; }
            set { _PID = value; }
        }

        //
        /// ��ע
        private string _Note;
        /// <summary>
        /// ��ע,��ע
        /// </summary>
        [DisplayName("��ע"), Category("1.һ����Ϣ"), Description("��ע")] 
        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }

        //
        private string _RoleID;
        /// <summary>
        /// ��ɫ���
        /// </summary>
        [DisplayName("��ɫ���"), Category("1.һ����Ϣ"), Description("��ɫ���")] 
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
        /// �Ƿ��ɫȨ�ޣ����ڿͻ���ʹ��
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