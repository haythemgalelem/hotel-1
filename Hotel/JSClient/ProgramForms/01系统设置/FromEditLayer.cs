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
    public partial class FromEditLayer : FormDlgBase
    {
        public Building currentLayer = null;
        public string father = "";
        public string operateType = "";

        public FromEditLayer()
        {
            InitializeComponent();

            this.Load += FromEditLayer_Load;
        }

        void FromEditLayer_Load(object sender, EventArgs e)
        {
            if (this.operateType == "modify")
            {
                this.cmbLayer.EditValue = this.currentLayer.Layer;
            }
        }

        public override bool FormDlgBaseSave()
        {
            if (currentLayer == null) this.currentLayer = new Building();

            if (this.operateType == "add")
            {
                this.currentLayer.BuildingID = Guid.NewGuid().ToString();
                this.currentLayer.Father = this.father;
                this.currentLayer.Type = "Layer";
                this.currentLayer.IsDel = 0;
            }

            this.currentLayer.Layer = Convert.ToInt32(this.cmbLayer.EditValue);
            this.currentLayer.Name = "第" + this.currentLayer.Layer + "层";

            bool result = ThreadExcute(() =>
            {
                if (operateType == "add")
                {
                    new BuildingOperator().Add(this.currentLayer);
                }
                else if (operateType == "modify")
                {
                    new BuildingOperator().Update(this.currentLayer);
                }
            });

            if (result == true)
            {
                Program.MsgBoxInfo("添加成功");
                return true;
            }
            else
            {
                Program.MsgBoxError("添加失败");
                return false;
            }
        }

        
    }
}
