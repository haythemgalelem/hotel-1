using BusinessEntity.Model;
using BusinessOperator;
using Client.CommonForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client.ProgramForms
{
    public partial class FormEditBuilding : FormDlgBase
    {
        public Building currentBuilding = null;
        public string operateType = "add";
        public string father = "";


        public FormEditBuilding()
        {
            InitializeComponent();
            //窗体加载
            this.Load += FormEditBuilding_Load;
        }

        void FormEditBuilding_Load(object sender, EventArgs e)
        {
            if (operateType == "modify")
            {
                this.txtBuildingName.Text = currentBuilding.Name;
                this.txtDescription.Text = currentBuilding.Description;
                this.txtNote.Text = currentBuilding.Note;
            }
        }

        public override bool FormDlgBaseSave()
        {
            if (this.currentBuilding == null) this.currentBuilding = new Building();

            if (this.txtBuildingName.Text.Trim() == "")
            {
                Program.MsgBoxError("请输入名称");
                return false;
            }

            if (this.operateType == "add")
            {
                this.currentBuilding.BuildingID = Guid.NewGuid().ToString();
                this.currentBuilding.IsDel = 0;
            }

            this.currentBuilding.Name = this.txtBuildingName.Text.Trim();
            this.currentBuilding.Description = this.txtDescription.Text.Trim();
            this.currentBuilding.Note = this.txtNote.Text.Trim();
            this.currentBuilding.Father = this.father;
            this.currentBuilding.Type = "Building";

            bool result = ThreadExcute(() =>
            {
                if (this.operateType == "add")
                    new BuildingOperator().Add(this.currentBuilding);
                else if (this.operateType == "modify")
                    new BuildingOperator().Update(this.currentBuilding);
            });

            if (result == true)
            {
                Program.MsgBoxInfo("保存成功");
                return true;
            }
            else
            {
                Program.MsgBoxError("保存失败");
                return false;
            }
        }
    }
}
