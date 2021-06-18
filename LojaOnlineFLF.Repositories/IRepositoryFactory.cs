namespace LojaOnlineFLF.Repositories
{
    public interface IRepositoryFactory
    {
        T Create<T>() where T : class;
    }
}