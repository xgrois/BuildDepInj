using System;
namespace BuildDepInj
{
    public class ServiceDescriptor
    {
        public ServiceDescriptor(object anyObj, ServiceLifetime lifetime)
        {
            Obj = anyObj;
            CType = anyObj.GetType();
            Lifetime = lifetime;
        }

        public ServiceDescriptor(System.Type anyTypeOfT, ServiceLifetime lifetime)
        {
            CType = anyTypeOfT;
            Lifetime = lifetime;
        }

        public ServiceDescriptor(System.Type anyTypeOfI, System.Type anyTypeOfT, ServiceLifetime lifetime)
        {
            IType = anyTypeOfI;
            CType = anyTypeOfT;
            Lifetime = lifetime;
        }


        public System.Type IType { get; } // Interface
        public System.Type CType { get; } // Class
        public object Obj { get; set; } // Instance (sould not be created in this class)

        public ServiceLifetime Lifetime { get; } // Kind of lifetime

    }
}