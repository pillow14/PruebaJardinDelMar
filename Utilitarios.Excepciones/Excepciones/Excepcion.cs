using System;
using System.Runtime.Serialization;

namespace Utilitarios.Excepciones
{
    [SerializableAttribute]
    public class Excepcion : Exception, ISerializable
    {
        public Excepcion()
        {
        }

        public Excepcion(string mensaje)
            : base(mensaje)
        {
        }

        public Excepcion(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }

        protected Excepcion(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
