using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstDb.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }

        //public string Supplier {  get; set; }

        public int Quantity { get; set; }

        public DateTime Date { get; set; }
    }
}
