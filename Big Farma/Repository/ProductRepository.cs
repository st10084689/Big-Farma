using Big_Farma.Data;
using Big_Farma.Models;
using Big_Farma.Repository.IRepository;

namespace Big_Farma.Repository
{
        public class ProductRepository : Repository<Product>, IProductRepository
        {
            private readonly ApplicationDbContext _db;

            public ProductRepository(ApplicationDbContext db) : base(db)
            {
                _db = db;
            }

            public void Update(Product obj)
            {
            var objFromDb = _db.Products.FirstOrDefault(u => u.ID == obj.ID);
                if (objFromDb != null)
            {
                objFromDb.ProductName = obj.ProductName;
                objFromDb.ProductDescription = obj.ProductDescription;
                objFromDb.Price = obj.Price;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.ApplicationIdentity = obj.ApplicationIdentity;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
    }