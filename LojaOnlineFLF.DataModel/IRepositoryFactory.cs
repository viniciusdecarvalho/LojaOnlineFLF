namespace LojaOnlineFLF.DataModel
{
    public interface IRepositoryFactory
    {
        T Create<T>() where T : class;
    }
}