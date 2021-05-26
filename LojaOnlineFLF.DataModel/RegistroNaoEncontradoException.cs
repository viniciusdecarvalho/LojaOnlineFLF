using System;
using System.Runtime.Serialization;

namespace LojaOnlineFLF.DataModel
{
    [Serializable]
    internal class RegistroNaoEncontradoException : Exception
    {
        public RegistroNaoEncontradoException()
        {
        }

        public RegistroNaoEncontradoException(string message) : base(message)
        {
        }

        public RegistroNaoEncontradoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RegistroNaoEncontradoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}