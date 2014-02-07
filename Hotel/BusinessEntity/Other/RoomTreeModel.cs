using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntity.Other
{
    public class RoomTreeModel
    {
        public string NodeID { get; set; }
        public string NodeName { get; set; }
        public string Father { get; set; }
        public string Type { get; set; } //Building & Layer & Room
        public bool Choose { get; set; }
    }
}
