using BusinessEntity.DAL;
using BusinessEntity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessOperator
{
    public class MemberOperator
    {
        public List<BusinessEntity.Model.Member> GetList()
        {
            return new MemberDAO().GetList();
        }

        public bool Del(List<BusinessEntity.Model.Member> willDel)
        {
            StringBuilder buf = new StringBuilder();

            foreach (Member m in willDel)
            {
                buf.Append("'");
                buf.Append(m.MemberID);
                buf.Append("'");
                buf.Append(",");
            }
            buf.Remove(buf.Length - 1, 1);

            return new MemberDAO().DeleteList(buf.ToString());
        }

        public void Add(Member member)
        {
            new MemberDAO().Add(member);
        }

        public void Update(Member member)
        {
            new MemberDAO().Update(member);
        }

        public void Charge(Member currentMember, double money)
        {
            currentMember.Balance = Convert.ToDecimal(money);
            Update(currentMember);
        }
    }
}
