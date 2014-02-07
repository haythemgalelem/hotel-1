using System;
namespace BusinessEntity.Model
{
    /// <summary>
    /// 房间类型
    /// </summary>
    [Serializable]
    public partial class RoomType : EntityBase
    {
        public RoomType()
        { }
        #region Model
        private string _id;
        private string _name;
        private decimal? _price;
        private string _description;
        private string _note;
        private decimal? _hourroomprice;
        private int? _allowhourroom;
        /// <summary>
        /// 
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
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
        public decimal? Price
        {
            set { _price = value; }
            get { return _price; }
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
        public decimal? HourRoomPrice
        {
            set { _hourroomprice = value; }
            get { return _hourroomprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? AllowHourRoom
        {
            set { _allowhourroom = value; }
            get { return _allowhourroom; }
        }
        #endregion Model

        public string AllowHourRoomName
        {
            get {
                return AllowHourRoom == 1 ? "允许" : "不允许";
            }
            set {
                this.AllowHourRoom = value == "允许" ? 1 : 0;
            }
        }
    }
}

