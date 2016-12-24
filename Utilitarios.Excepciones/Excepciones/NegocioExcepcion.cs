using System;
using System.Runtime.Serialization;

namespace Utilitarios.Excepciones
{
    [SerializableAttribute]
    public class NegocioException : Exception, ISerializable
    {
        public NegocioException()
        {
        }

        public NegocioException(string mensaje)
            : base(mensaje)
        {
        }

        public NegocioException(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }

        protected NegocioException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
