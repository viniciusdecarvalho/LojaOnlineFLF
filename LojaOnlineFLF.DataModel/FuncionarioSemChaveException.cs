using System;
using System.Runtime.Serialization;

namespace LojaOnlineFLF.DataModel
{
    [Serializable]
    internal class FuncionarioOuChaveInvalidaException : Exception
    {
        public FuncionarioOuChaveInvalidaException()
            : base("funcionario nao possui chave de acesso cadastrado")
        {
        }

        public FuncionarioOuChaveInvalidaException(string message) : base(message)
        {
        }

        public FuncionarioOuChaveInvalidaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FuncionarioOuChaveInvalidaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}