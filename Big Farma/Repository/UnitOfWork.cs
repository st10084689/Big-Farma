using Big_Farma.Data;
using Big_Farma.Repository.IRepository;

namespace Big_Farma.Repository
{

    public class UnitOfWork : IUnitOfWork

    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            category = new CategoryRepository(_db);
            product = new ProductRepository(_db);
        }

        public ICategoryRepository category { get; private set; }

        public IProductRepository product { get; private set; }

        public void Save()
        {
            _db.SaveChanges();

        }
    }
}
