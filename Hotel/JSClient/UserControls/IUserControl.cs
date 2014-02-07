using System;
using System.Collections.Generic; 
using System.Text;

namespace Client.UserControls
{
    /// <summary>
    /// 所用用户控件接口
    /// </summary>
    public interface IUserControl
    {
        /// <summary>
        /// 初始化
        /// </summary>
        void Init();
        /// <summary>
        /// 新增
        /// </summary>
        void Add();
        /// <summary>
        /// 删除
        /// </summary>
        void Delete();
        /// <summary>
        /// 修改
        /// </summary>
        void Modify();
        /// <summary>
        /// 上移
        /// </summary>
        void Up();
        /// <summary>
        /// 下移
        /// </summary>
        void Down();

        /// <summary>
        /// 查询
        /// </summary>
        void Search();
        /// <summary>
        /// 刷新
        /// </summary>
        void Refresh();

        /// <summary>
        /// 保存
        /// </summary>
        void Save();
        /// <summary>
        /// 审核
        /// </summary>
        void Check();

        /// <summary>
        /// 设置修改
        /// </summary>
        void SetModify();

        /// <summary>
        /// 设置新增
        /// </summary>
        void SetAdd();

        /// <summary>
        /// 设置删除
        /// </summary>
        void SetDelete();
        
        void Clear();//清除数据
        void PreSave();//预保存
        void LoadData();//加载数据
    }
}
