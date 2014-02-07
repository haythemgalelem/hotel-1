using BusinessEntity.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessOperator
{
    public class CheckinFinanceOperator
    {
        public BusinessEntity.Model.CheckinFinance GetModel(string p)
        {
            return new CheckinFinanceDAO().GetModel(p);
        }
    }
}
