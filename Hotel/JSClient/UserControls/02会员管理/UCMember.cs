using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BusinessOperator;
using BusinessEntity.Model;
using Client.ProgramForms;
using Client.UserControls._02会员管理;
using Client.ProgramForms._02会员管理;

namespace Client.UserControls
{
    public partial class UCMember : UserControlBase, IUserControl
    {

        private List<Member> arr_Members = null;

        public UCMember()
        {
            InitializeComponent();

            //双击编辑
            this.gdMember.DoubleClick += gdMember_DoubleClick;
            //右键菜单
            this.gvMember.Click += gvMember_Click;
            //菜单充值
            this.menuRecharge.Click += menuRecharge_Click;
            //按钮充值
            this.btnCharge.ItemClick += btnCharge_ItemClick;
            //菜单挂失
            this.menuLost.Click += menuLost_Click;
            //按钮挂失
            this.btnLost.ItemClick += btnLost_ItemClick;
            //按钮补卡
            this.btnReCard.ItemClick += btnReCard_ItemClick;
            //菜单补卡
            this.menuReCard.Click += menuReCard_Click;
            //按钮注销
            this.btnCancelCard.ItemClick += btnCancelCard_ItemClick;
            //菜单注销
            this.menuCancelCard.Click += menuCancelCard_Click;
            //按钮续卡
            this.btnKeepCard.ItemClick += btnKeepCard_ItemClick;
            //菜单续卡
            this.menuKeepCard.Click += menuKeepCard_Click;
            //按钮设置密码
            this.btnPwd.ItemClick += btnPwd_ItemClick;
            //菜单设置密码
            this.menuPwd.Click += menuPwd_Click;


        }

        void menuPwd_Click(object sender, EventArgs e)
        {
            try
            {
                Pwd();
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }

        void btnPwd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Pwd();
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }

        void menuKeepCard_Click(object sender, EventArgs e)
        {
            try
            {
                KeepCard();
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }

        void btnKeepCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                KeepCard();
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }

        void menuCancelCard_Click(object sender, EventArgs e)
        {
            try
            {
                CancelCard();
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }

        void btnCancelCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                CancelCard();
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }

        void menuReCard_Click(object sender, EventArgs e)
        {
            try
            {
                ReCard();
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }

        void btnReCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                ReCard();
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }

        void menuLost_Click(object sender, EventArgs e)
        {
            try
            {
                Lost();
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }

        void btnLost_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Lost();
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }

        
        void btnCharge_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Charge();
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }

        void menuRecharge_Click(object sender, EventArgs e)
        {
            try
            {
                Charge();
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }

        void gvMember_Click(object sender, EventArgs e)
        {

            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
                menu.Show(me.Location);
        }

        void gdMember_DoubleClick(object sender, EventArgs e)
        {
            Modify();
        }

        #region 实现接口
        public void Init()
        {
            InitData();
        }

        public void Add()
        {
            FormEditMember form = new FormEditMember();
            form.operateType = "add";

            if (form.ShowDialog() == DialogResult.Yes)
            {
                this.arr_Members.Add(form.currentMember);
                this.gdMember.RefreshDataSource();
            }
        }

        public void Delete()
        {
            this.gvMember.FocusedColumn = null;

            List<Member> willDel = new List<Member>();
            StringBuilder buf = new StringBuilder();

            foreach (Member m in this.arr_Members)
            {
                if (m.Choose)
                {
                    willDel.Add(m);
                    buf.Append(m.MemberName + "\n");
                }
            }

            if (Program.MsgBoxYesNo("你确定要删除以下会员吗？\n" + buf.ToString()) == DialogResult.Yes)
            {
                 bool result = ThreadExcute(()=> {
                     new MemberOperator().Del(willDel);
                 });

                 if (result == true)
                 {
                     foreach (Member m in willDel)
                     {
                         this.arr_Members.Remove(m);
                     }

                     this.gdMember.RefreshDataSource();
                 }
            }
        }

        public void Modify()
        {
            int index = this.gvMember.GetFocusedDataSourceRowIndex();
            if (index < 0)
            {
                Program.MsgBoxInfo("请选中数据行");
                return;
            }

            FormEditMember form = new FormEditMember();
            form.operateType = "modify";
            form.currentMember = this.arr_Members[index];
            if (form.ShowDialog() == DialogResult.Yes)
            {
                this.arr_Members[index] = form.currentMember;
                this.gdMember.RefreshDataSource();
            }
        }

        public void Up()
        {
            throw new NotImplementedException();
        }

        public void Down()
        {
            throw new NotImplementedException();
        }

        public void Search()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Check()
        {
            throw new NotImplementedException();
        }

        public void SetModify()
        {
            throw new NotImplementedException();
        }

        public void SetAdd()
        {
            throw new NotImplementedException();
        }

        public void SetDelete()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void PreSave()
        {
            throw new NotImplementedException();
        }

        public void LoadData()
        {
            throw new NotImplementedException();
        }

        public void Refresh()
        {
            InitData();
        }
        #endregion

        #region 方法


        private void InitData()
        {
            bool result = ThreadExcute(() =>
            {
                this.arr_Members = new MemberOperator().GetList();
            });

            if (result)
            {
                this.gdMember.DataSource = this.arr_Members;
                this.gdMember.RefreshDataSource();
            }
        }

        /// <summary>
        /// 充值
        /// </summary>
        private void Charge()
        {
            Member m = null;
            if ((m = GetFocusData()) != null)
            {
                FormCharge form = new FormCharge();
                form.currentMember = m;

                if (form.ShowDialog() == DialogResult.Yes)
                {
                    this.arr_Members[this.arr_Members.FindIndex(delegate(Member other)
                    {
                        if (other.MemberID == m.MemberID)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    })] = m;


                    this.gdMember.RefreshDataSource();
                }
            }
        }

        /// <summary>
        /// 挂失
        /// </summary>
        private void Lost()
        {
            Member m = GetFocusData();
            if (m == null)
            {
                Program.MsgBoxInfo("请选中数据行");
                return;
            }
            FormEditLost form = new FormEditLost();
            form.currentMember = m;

            if (form.ShowDialog() == DialogResult.Yes)
            {
                this.arr_Members[this.arr_Members.FindIndex(delegate(Member other)
                {
                    if (other.MemberID == m.MemberID)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                })] = m;

                this.gdMember.RefreshDataSource();
            }
            
        }


        /// <summary>
        /// 补卡
        /// </summary>
        private void ReCard()
        {
            Member m = GetFocusData();
            if (m == null)
            {
                Program.MsgBoxInfo("请选中数据行");
                return;
            }
            FormReCard form = new FormReCard();
            form.currentMember = m;

            if (form.ShowDialog() == DialogResult.Yes)
            {
                this.arr_Members[this.arr_Members.FindIndex(delegate(Member other)
                {
                    if (other.MemberID == m.MemberID)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                })] = m;

                this.gdMember.RefreshDataSource();
            }
        }

        /// <summary>
        /// 注销卡
        /// </summary>
        private void CancelCard()
        {
            Member m = GetFocusData();
            if (m == null)
            {
                Program.MsgBoxInfo("请选中数据行");
                return;
            }
            if (Program.MsgBoxYesNo("您确定要注销卡号为：" + m.MemberCardID + " " + "用户为：" + m.MemberName + " 的会员卡吗？") == DialogResult.Yes)
            {
                m.Status = "注销";
                bool result = ThreadExcute(() =>
                {
                    new MemberOperator().Update(m);
                });

                Program.MsgBoxInfo("注销成功");

                this.arr_Members[this.arr_Members.FindIndex(delegate(Member other)
                {
                    if (other.MemberID == m.MemberID)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                })] = m;

                this.gdMember.RefreshDataSource();
            }
        }

        /// <summary>
        /// 续卡
        /// </summary>
        private void KeepCard()
        {
            Member m = GetFocusData();
            if (m == null)
            {
                Program.MsgBoxInfo("请选中数据行");
                return;
            }
            if (Program.MsgBoxYesNo("您确定要续卡卡号为：" + m.MemberCardID + " " + "用户为：" + m.MemberName + " 的会员卡吗？") == DialogResult.Yes)
            {
                m.Status = "正常";
                bool result = ThreadExcute(() =>
                {
                    new MemberOperator().Update(m);
                });

                Program.MsgBoxInfo("续卡成功");

                this.arr_Members[this.arr_Members.FindIndex(delegate(Member other)
                {
                    if (other.MemberID == m.MemberID)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                })] = m;

                this.gdMember.RefreshDataSource();
            }
        }

        /// <summary>
        /// 设置密码
        /// </summary>
        private void Pwd()
        {
            Member m = GetFocusData();
            if (m == null)
            {
                Program.MsgBoxInfo("请选中数据行");
                return;
            }

            FormSetPwd form = new FormSetPwd();
            form.currentMember = m;

            if (form.ShowDialog() == DialogResult.Yes)
            {

            }
        }


        private Member GetFocusData()
        {
            int index = this.gvMember.GetFocusedDataSourceRowIndex();

            if (index < 0)
            {
                return null;
            }

            return this.arr_Members[index];
        }


        #endregion

        private void gdMember_Click(object sender, EventArgs e)
        {

        }
    }
}
