using BusinessEntity.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessOperator
{
    public class LostOperator
    {
        public void Update(BusinessEntity.Model.Lost lost)
        {
            new LostDAO().Update(lost);
        }

        public void Add(BusinessEntity.Model.Lost currentLost)
        {
            new LostDAO().Add(currentLost);
        }

        public List<BusinessEntity.Model.Lost> GetList()
        {
            return new LostDAO().GetList();
        }
    }
}
