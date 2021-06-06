using System;
using System.Threading.Tasks;

namespace LojaOnlineFLF.Utils
{
    public static class Objects
    {
        public static void CheckArgumentNonNull(object nonNull, string paramName, string message = null)
        {
            if (nonNull is null)
            {
                throw new ArgumentNullException(paramName, message);
            }
        }

        public static Task<TResult> Try<TResult>(Func<Task<TResult>> function, string mensagem)
        {
            return Task.Run<TResult>(async () =>
            {
                try
                {
                    return await function.Invoke();
                }
                catch (Exception e)
                {
                    throw new Exception(mensagem, e);
                }
            });
        }
    }
}
