namespace LojaOnlineFLF.Services
{
    /// <summary>
    /// Servico para operações de conversao de objetos entre a camada da api e outras camadas
    /// </summary>
    public interface IMapperService : IService
    {
        /// <summary>
        /// Converter objeto no tipo informado
        /// </summary>
        /// <typeparam name="TDestination">Tipo a ser recuperado</typeparam>
        /// <param name="source"></param>
        /// <returns>Tipo destino</returns>
        TDestination Convert<TDestination>(object source);

        /// <summary>
        /// Atualizar propriedades do destino, a partir da origem
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source">Objeto origem</param>
        /// <param name="destination">Objeto destino</param>
        /// <returns>Tipo destino</returns>
        TDestination Merge<TSource, TDestination>(TSource source, TDestination destination);
    }
}
