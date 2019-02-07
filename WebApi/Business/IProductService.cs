using System.Collections.Generic;
using WebApi.Domain;

namespace WebApi.Business
{
    public interface IProductService
    {
        Product Get(int id);
        IEnumerable<Product> GetAll();
        Result Insert(Product obj);
        Result Update(Product obj);
        Result Delete(int id);
    }
}
