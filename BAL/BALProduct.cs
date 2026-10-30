using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class BALProduct : BALShippingAddress
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string CategoryID { get; set; }
        public string SubcategoryID { get; set; }
        public string GroupHeaderID { get; set; }
        public string GroupTypeID { get; set; }
        public string SubGroupHeaderID { get; set; }
        public string ProductIDs { get; set; }
    }
}
