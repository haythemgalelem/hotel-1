using BusinessEntity.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessOperator
{
    public class ReserveOperator
    {
        public List<BusinessEntity.Model.Reserve> GetList()
        {
            return new ReserveDAO().GetList();
        }

        public void Add(BusinessEntity.Model.Reserve currentReserve)
        {
            new ReserveDAO().AddTran(currentReserve);
        }

        public void Update(BusinessEntity.Model.Reserve currentReserve)
        {
            new ReserveDAO().UpdateTran(currentReserve);
        }

        public List<BusinessEntity.Model.Room> GetRooms(BusinessEntity.Model.Reserve currentReserve)
        {
            List<string> ids = new ReserveDAO().GetRoomIDsByReserveID(currentReserve.ReserveID);
            return new RoomDAO().GetListByIDs(ids);
        }
    }
}
