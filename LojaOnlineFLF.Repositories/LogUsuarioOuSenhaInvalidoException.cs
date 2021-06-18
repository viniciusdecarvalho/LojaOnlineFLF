using System;
using System.Runtime.Serialization;

namespace LojaOnlineFLF.Repositories
{
    [Serializable]
    internal class LogUsuarioOuSenhaInvalidoException : Exception
    {
        public LogUsuarioOuSenhaInvalidoException()
            : base("usuario e/ou senha invalidos")
        {
        }

        public LogUsuarioOuSenhaInvalidoException(string message) : base(message)
        {
        }

        public LogUsuarioOuSenhaInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LogUsuarioOuSenhaInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}