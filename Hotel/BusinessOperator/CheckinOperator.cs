using BusinessEntity.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessOperator
{
    public class CheckinOperator
    {
        public List<BusinessEntity.Model.Checkin> GetList()
        {
            return new CheckinDAO().GetList();
        }

        public bool Add(BusinessEntity.Model.Checkin currentCheckin)
        {
            return new CheckinDAO().AddTran(currentCheckin);
        }

        public bool Update(BusinessEntity.Model.Checkin currentCheckin)
        {
            throw new NotImplementedException();
        }
    }
}
