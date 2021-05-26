namespace LojaOnlineFLF.DataModel
{
    public interface IRepositoryFactory
    {
        IFuncionariosRepository CreateFuncionarios();

        IAcessosRepository CreateAcessos();
    }
}