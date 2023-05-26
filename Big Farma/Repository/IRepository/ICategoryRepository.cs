using Big_Farma.Models;


namespace Big_Farma.Repository.IRepository
{
        public interface ICategoryRepository: IRepository<Category>
        {
            void Update(Category obj);
        }
    }

