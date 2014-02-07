using BusinessEntity.Model;
using DataAccessLayer.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessOperator
{
    public class OperatorOperate
    {
        public List<BusinessEntity.Model.Operator> GetList()
        {
            return new OperatorDAO().GetList();
        }

        public void Add(BusinessEntity.Model.Operator p)
        {
            new OperatorDAO().Add(p);
        }

        public void Update(BusinessEntity.Model.Operator p)
        {
            new OperatorDAO().Update(p);
        }

        public bool Del(List<BusinessEntity.Model.Operator> willDel)
        {
            bool result = false;
            foreach(Operator o in willDel) 
            {
                result = new OperatorDAO().Delete(o.OperateID_);
            }

            return result;
        }

        public Operator Vertify(string p1, string p2)
        {
            return new OperatorDAO().Verify(p1, p2);
        }
    }
}
