using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class BALCart : BALProduct
    {
        public string CartId { get; set; }        
        public List<CustomerCart> CartJsonData { get; set; }
        public string CartJsonstring { get; set; }
    }

    public class CustomerCart
    {
        public string ProductId { get; set; }
        public string ProductQty { get; set; }
        public string OfferId { get; set; }
        public string OfferType { get; set; }
        public string ProductMrp { get; set; }
        public string ProductPrice { get; set; }
        public string ProductBillPrice { get; set; }
        public string ProductDiscountDescr { get; set; }
        public string ProductConditionalOfferId { get; set; }
    }
}
