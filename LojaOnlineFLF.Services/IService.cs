namespace LojaOnlineFLF.Services
{
    public interface IService
    {
        string ServiceName => this.GetType().Name;
    }
}