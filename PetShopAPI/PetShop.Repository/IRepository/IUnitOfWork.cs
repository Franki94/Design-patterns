namespace PetShop.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IDogsRepository Dogs { get; }
    }
}
