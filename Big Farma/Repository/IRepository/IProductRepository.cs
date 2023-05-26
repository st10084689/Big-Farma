using Big_Farma.Models;


namespace Big_Farma.Repository.IRepository
{
        public interface IProductRepository : IRepository<Product>
        {
            void Update(Product obj);

        }
    }

