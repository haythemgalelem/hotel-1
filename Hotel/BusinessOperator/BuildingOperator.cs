
using BusinessEntity.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessOperator
{
    public class BuildingOperator
    {
        public List<BusinessEntity.Model.Building> GetList()
        {
            return new BuildingDAO().GetList();
        }

        public void Add(BusinessEntity.Model.Building building)
        {
            new BuildingDAO().Add(building);
        }

        public void Update(BusinessEntity.Model.Building building)
        {
            new BuildingDAO().Update(building);
        }

        public void Del(List<BusinessEntity.Other.RoomTreeModel> builds, List<BusinessEntity.Other.RoomTreeModel> rooms)
        {
            new BuildingDAO().Delete(builds, rooms);
        }
    }
}
