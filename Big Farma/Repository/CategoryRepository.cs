using Big_Farma.Data;
using Big_Farma.Models;
using Big_Farma.Repository.IRepository;

namespace Big_Farma.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Category obj)
        {
            _db.Update(obj);
        }
    }
}
