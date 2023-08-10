using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMFundamentalsDapper.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public string Status { get; set; }

        [Computed]
        public DateTime CreatedDate 
        { 
            get 
            {
                return DateTime.Now;
            }
        }

        public DateTime UpdatedDate { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public override string? ToString()
        {
            return $"ID: {Id}, Status: {Status}, CreatedDate: {CreatedDate}, UpdatedDate: {UpdatedDate},\n\t Product: {Product}";
        }
    }
}
