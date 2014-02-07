using BusinessEntity.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessOperator
{
    public class Checkin2RoomOperator
    {
        public List<BusinessEntity.Model.Checkin2Room> GetRooms(BusinessEntity.Model.Checkin checkin)
        {
            return new Checkin2RoomDAO().GetListByCheckin(checkin);
        }
    }
}
