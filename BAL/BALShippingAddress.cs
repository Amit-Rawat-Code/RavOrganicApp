using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class BALShippingAddress : BALCustomer
    {
        public string AddressId { get; set; }
        public string PesronName { get; set; }
        public string AddressName { get; set; }
        public string AddressType { get; set; }
        public string IsDefaultAddress { get; set; }
        public string AddressContactNo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string Country { get; set; }
    }
}
