using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntity
{
    public class FolderTreeNode
    {
        public Guid NodeID { get; set; }
        public string Name { get; set; }
        public Guid FatherNodeID { get; set; }
        public Guid MailConfigID { get; set; }
    }
}
