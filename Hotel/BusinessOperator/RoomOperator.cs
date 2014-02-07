using BusinessEntity.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessOperator
{
    public class RoomOperator
    {
        public void Add(BusinessEntity.Model.Room room)
        {
            new RoomDAO().Add(room);
        }

        public void Update(BusinessEntity.Model.Room room)
        {
            new RoomDAO().Update(room);
        }

        public List<BusinessEntity.Model.Room> GetList()
        {
            return new RoomDAO().GetList();
        }

        public void Del(List<BusinessEntity.Other.RoomTreeModel> rooms)
        {
            throw new NotImplementedException();
        }
    }
}
