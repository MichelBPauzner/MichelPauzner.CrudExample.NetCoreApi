using System;

namespace WebApi.Domain
{
    public class Product
    {
        public Product()
        {
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
