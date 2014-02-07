using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections; 
namespace BusinessEntity
{
    public class CustomIDNode
    {
        private int fid;
        private string name;
        private string nodeType;
        private int array;

        private int pid;

        /// <summary>
        /// 节点编号
        /// </summary>
        public int Fid
        {
            get { return fid; }
            set { fid = value; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// 节点类型
        /// </summary>
        public string NodeType
        {
            get { return nodeType; }
            set { nodeType = value; }
        }
        /// <summary>
        /// 节点排序
        /// </summary>
        public int Array
        {
            get { return array; }
            set { array = value; }
        }
        /// <summary>
        /// 父id
        /// </summary>
        public int Pid
        {
            get { return pid; }
            set { pid = value; }
        }
    }

    public class CustomStrNode
    {
        private string fid;
        private string name;
        private string nodeType;
        private int array;

        private string pid;

        /// <summary>
        /// 节点编号
        /// </summary>
        public string Fid
        {
            get { return fid; }
            set { fid = value; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// 节点类型
        /// </summary>
        public string NodeType
        {
            get { return nodeType; }
            set { nodeType = value; }
        }
        /// <summary>
        /// 节点排序
        /// </summary>
        public int Array
        {
            get { return array; }
            set { array = value; }
        }
        /// <summary>
        /// 父id
        /// </summary>
        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }
    }

    /// <summary>
    /// 用于物料核价物料的树形插入(主信息+明细)
    /// </summary>
    public class MaterialCostMaterialNode
    {
        private string mcmfid;
        private string mcmpid;
        private string name;
        private int _materialtypeid;
        private int _materialid;
        private string _materialtype;
        private string _materialcode;
        private string _materialname;
        private int? _supplierid;
        private string _supplier;
        private string _unit;
        private decimal? _perqty;
        private decimal? _requireqty;


        private decimal? _price;
        private decimal? _wastepercent;
        private decimal? _wasterequireqty;

        private decimal? _wasteamount;
        private decimal? _storeqty;
        private decimal? _buyqty;
        private decimal? _buyamount;
        private decimal? _buyprice;
        private string _note;
        private string nodeType;
        private int array;
        /// <summary>
        /// 以下是明细
        /// </summary>
        private string _detailmaterialcolorcode;
        private string _detailmaterialsizecode;
        private decimal _detailperqty;
        private decimal _detailrequireqty;
        private decimal _detailprice;
        private decimal _detailwastepercent;
        private decimal _detailwasterequireqty;
        private decimal _detailwasteamount;
        private decimal _detailstoreqty;
        private decimal _detailbuyqty;
        private decimal _detailbuyamount;
        private decimal _detailbuyprice;
        private string _detailnote;
        private int _saleID;
        private int _operateID;

        public int OperateID
        {
            get { return _operateID; }
            set { _operateID = value; }
        }
        private DateTime _operateTime;

        public DateTime OperateTime
        {
            get { return _operateTime; }
            set { _operateTime = value; }
        }
        private string _noteType;

        public string NoteType
        {
            get { return _noteType; }
            set { _noteType = value; }
        }
        public int SaleID
        {
            get { return _saleID; }
            set { _saleID = value; }
        }
        private int _styleID;

        public int StyleID
        {
            get { return _styleID; }
            set { _styleID = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string DetailMaterialColorCode
        {
            set { _detailmaterialcolorcode = value; }
            get { return _detailmaterialcolorcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DetailMaterialSizeCode
        {
            set { _detailmaterialsizecode = value; }
            get { return _detailmaterialsizecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal DetailPerQty
        {
            set { _detailperqty = value; }
            get { return _detailperqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal DetailRequireQty
        {
            set { _detailrequireqty = value; }
            get { return _detailrequireqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal DetailPrice
        {
            set { _detailprice = value; }
            get { return _detailprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal DetailWastePercent
        {
            set { _detailwastepercent = value; }
            get { return _detailwastepercent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal DetailWasteRequireQty
        {
            set { _detailwasterequireqty = value; }
            get { return _detailwasterequireqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal DetailWasteAmount
        {
            set { _detailwasteamount = value; }
            get { return _detailwasteamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal DetailStoreQty
        {
            set { _detailstoreqty = value; }
            get { return _detailstoreqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal DetailBuyQty
        {
            set { _detailbuyqty = value; }
            get { return _detailbuyqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal DetailBuyAmount
        {
            set { _detailbuyamount = value; }
            get { return _detailbuyamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal DetailBuyPrice
        {
            set { _detailbuyprice = value; }
            get { return _detailbuyprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DetailNote
        {
            set { _detailnote = value; }
            get { return _detailnote; }

        }

        /// <summary>
        /// 节点编号
        /// </summary>
        public string MCMFid
        {
            get { return mcmfid; }
            set { mcmfid = value; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// 节点类型
        /// </summary>
        public string NodeType
        {
            get { return nodeType; }
            set { nodeType = value; }
        }
        /// <summary>
        /// 节点排序
        /// </summary>
        public int Array
        {
            get { return array; }
            set { array = value; }
        }
        /// <summary>
        /// 父id
        /// </summary>
        public string MCMPid
        {
            get { return mcmpid; }
            set { mcmpid = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int MaterialTypeID
        {
            set { _materialtypeid = value; }
            get { return _materialtypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int MaterialID
        {
            set { _materialid = value; }
            get { return _materialid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MaterialType
        {
            set { _materialtype = value; }
            get { return _materialtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MaterialCode
        {
            set { _materialcode = value; }
            get { return _materialcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MaterialName
        {
            set { _materialname = value; }
            get { return _materialname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SupplierID
        {
            set { _supplierid = value; }
            get { return _supplierid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Supplier
        {
            set { _supplier = value; }
            get { return _supplier; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Unit
        {
            set { _unit = value; }
            get { return _unit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PerQty
        {
            set { _perqty = value; }
            get
            {
                if (_perqty == 0)
                    return null;
                return _perqty;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? RequireQty
        {
            set { _requireqty = value; }
            get
            {
                if (_requireqty == 0)
                    return null;
                return _requireqty;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Price
        {
            set { _price = value; }
            get
            {
                if (_price == 0)
                    return null;
                return _price;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? WastePercent
        {
            set { _wastepercent = value; }
            get
            {
                if (_wastepercent == 0)
                    return null;
                return _wastepercent;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? WasteRequireQty
        {
            set { _wasterequireqty = value; }
            get
            {
                if (_wasterequireqty == 0)
                    return null;
                return _wasterequireqty;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? WasteAmount
        {
            set { _wasteamount = value; }
            get
            {
                if (_wasteamount == 0)
                    return null;
                return _wasteamount;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? StoreQty
        {
            set { _storeqty = value; }
            get
            {
                if (_storeqty == 0)
                    return null;
                return _storeqty;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? BuyQty
        {
            set { _buyqty = value; }
            get
            {
                if (_buyqty == 0)
                    return null;
                return _buyqty;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? BuyAmount
        {
            set { _buyamount = value; }
            get
            {
                if (_buyamount == 0)
                    return null;
                return _buyamount;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? BuyPrice
        {
            set { _buyprice = value; }
            get
            {
                if (_buyprice == 0)
                    return null;
                return _buyprice;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Note
        {
            set { _note = value; }
            get { return _note; }
        }

    }



}
