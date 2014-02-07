using System;
namespace BusinessEntity.Model
{
    /// <summary>
    /// 楼信息
    /// </summary>
    [Serializable]
    public partial class Building
    {
        public Building()
        { }
        #region Model
        private string _buildingid;
        private string _name;
        private string _description;
        private string _note;
        private string _type;
        private int? _layer;
        private string _father;
        private int? _isdel;
        /// <summary>
        /// 
        /// </summary>
        public string BuildingID
        {
            set { _buildingid = value; }
            get { return _buildingid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Note
        {
            set { _note = value; }
            get { return _note; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Layer
        {
            set { _layer = value; }
            get { return _layer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Father
        {
            set { _father = value; }
            get { return _father; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsDel
        {
            set { _isdel = value; }
            get { return _isdel; }
        }
        #endregion Model

    }
}

