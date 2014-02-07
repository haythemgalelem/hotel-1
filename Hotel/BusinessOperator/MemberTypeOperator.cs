using BusinessEntity.DAL;
using BusinessEntity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessOperator
{
    public class MemberTypeOperator
    {
        public List<BusinessEntity.Model.MemberType> GetList()
        {
            return new MemberTypeDAO().GetList();
        }

        public void Save(BusinessEntity.Model.MemberType currentMemberType)
        {
            new MemberTypeDAO().Add(currentMemberType);
        }

        public void Update(BusinessEntity.Model.MemberType currentMemberType)
        {
            new MemberTypeDAO().Update(currentMemberType);
        }

        public bool Del(List<BusinessEntity.Model.MemberType> willDel)
        {
            StringBuilder buf = new StringBuilder();
            foreach (MemberType m in willDel)
            {
                buf.Append("'" + m.MemberTypeID + "',");
            }
            buf.Remove(buf.Length - 1, 1);

            return new MemberTypeDAO().DeleteList(buf.ToString());
        }
    }
}
