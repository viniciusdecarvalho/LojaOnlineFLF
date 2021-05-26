using System;
using System.Runtime.Serialization;

namespace LojaOnlineFLF.DataModel
{
    [Serializable]
    internal class FuncionarioDesligadoOuInativoException : Exception
    {
        public FuncionarioDesligadoOuInativoException()
            : base("funcionario desligado ou inativo")
        {
        }

        public FuncionarioDesligadoOuInativoException(string message) : base(message)
        {
        }

        public FuncionarioDesligadoOuInativoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FuncionarioDesligadoOuInativoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}