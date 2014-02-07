using BusinessEntity.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessOperator
{
    public class CustomerOperator
    {
        public List<BusinessEntity.Model.Customer> GetList()
        {
            return new CustomerDAO().GetList();
        }

        public BusinessEntity.Model.Customer GetModel(string id)
        {
            return new CustomerDAO().GetModel(id);
        }
    }
}
