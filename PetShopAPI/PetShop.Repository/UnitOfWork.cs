using PetShop.Repository.IRepository;

namespace PetShop.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(PetShopDbContext context)
        {
            Dogs = new DogsRepository(context);
        }
        public IDogsRepository Dogs { get; private set; }
    }
}
