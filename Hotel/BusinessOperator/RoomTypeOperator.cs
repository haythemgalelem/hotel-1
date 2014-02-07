using BusinessEntity.DAL;
using BusinessEntity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessOperator
{
    public class RoomTypeOperator
    {
        public List<BusinessEntity.Model.RoomType> GetList()
        {
            return new RoomTypeDAO().GetList();
        }

        public bool Del(List<BusinessEntity.Model.RoomType> willDel)
        {
            StringBuilder buf = new StringBuilder();

            foreach (RoomType m in willDel)
            {
                buf.Append("'");
                buf.Append(m.ID);
                buf.Append("'");
                buf.Append(",");
            }
            buf.Remove(buf.Length - 1, 1);

            return new RoomTypeDAO().DeleteList(buf.ToString());
        }

        public void Update(RoomType roomType)
        {
            new RoomTypeDAO().Update(roomType);
        }

        public void Add(RoomType roomType)
        {
            new RoomTypeDAO().Add(roomType);
        }

        public RoomType GetModel(string id)
        {
            return new RoomTypeDAO().GetModel(id);
        }
    }
}
