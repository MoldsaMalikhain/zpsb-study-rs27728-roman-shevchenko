using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BarCode { get; set; }

        private Decimal price;
        public Decimal Price
        {
            get
            {
                return Decimal.Round(price, 2);
            }
            set
            {
                price = value;
            }
        }
    }
}
