using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Data;
using WebApi.Domain;

namespace WebApi.Business
{
    public class ProductService: IProductService
    {
        private AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public Product Get(int id)
        {
            return _context.Product.Where(
                p => p.Id.Equals(id)).FirstOrDefault();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Product
                .OrderBy(p => p.Description).ToList();
        }

        public Result Insert(Product obj)
        {
            Result result = Validate(obj);
            result.Action = ResultAction.Insert;

            if (result.Notifications.Count == 0)
            {
                _context.Product.Add(obj);
                _context.SaveChanges();
            }

            return result;
        }

        public Result Update(Product obj)
        {
            Result result = Validate(obj);
            result.Action = ResultAction.Update;

            if (result.Notifications.Count == 0)
            {
                Product product = Get(obj.Id);

                if (product == null)
                {
                    result.AddNotification("Produto não encontrado");
                }
                else
                {
                    product.Description = obj.Description;
                    product.Price = obj.Price;
                    _context.SaveChanges();
                }
            }

            return result;
        }

        public Result Delete(int id)
        {
            Result result = new Result
            {
                Action = ResultAction.Delete
            };

            Product obj = Get(id);
            if (obj == null)
            {
                result.AddNotification("Produto não encontrado");
            }
            else
            {
                _context.Product.Remove(obj);
                _context.SaveChanges();
            }

            return result;
        }

        private Result Validate(Product obj)
        {
            var result = new Result();
            if (obj == null)
            {
                result.AddNotification("Preencha os Dados do Produto.");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(obj.Description))
                {
                    result.AddNotification("Preencha a Descrição do Produto.");
                }
                if (obj.Price <= 0)
                {
                    result.AddNotification("O Preço do Produto deve ser maior do que zero.");
                }
            }

            return result;
        }
    }
}